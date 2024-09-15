using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Latin_Squares.BiGraph;

namespace Latin_Squares
{
    public class BiGraph
    {
        public enum VertexType
        {
            Row,
            Col
        }
        public enum EdgeState
        {
            KNOWN,
            VISITED,
            UNVISITED
        }

        public static char[,] data;
        public int n;
        public int unknownCount;
        public HashSet<char> alphabet;
        private Vertex[] rows;
        private Vertex[] cols;
        private Edge[,] edges;
        private PriorityQueue<Vertex, int> VertexQueue;
        private LinkedList<Edge> EdgeLL;

        public BiGraph(int inN, char[,] inData)
        {
            n = inN;
            unknownCount = n * n;
            alphabet = new HashSet<char>();
            InitAlphabet();
            rows = new Vertex[n];
            cols = new Vertex[n];
            data = new char[n, n];
            edges = new Edge[n, n];
            data = inData;
            VertexQueue = new PriorityQueue<Vertex, int>();
            EdgeLL = new LinkedList<Edge>();

            // create the row and column verticies 
            for (int i = 0; i < n; i++)
            {
                rows[i] = new Vertex(this, i, VertexType.Row);
                cols[i] = new Vertex(this, i, VertexType.Col);
            }

            // create the edges for each cell
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    AddEdge(rows[i], cols[j], data[i, j]);
                }

                // Priority queue verticies by count of available chars in Vertex charset
                VertexQueue.Enqueue(rows[i], rows[i].vertexAvailableChars.Count);
                VertexQueue.Enqueue(cols[i], cols[i].vertexAvailableChars.Count);
            }
            //DebugPrintVertexState();
            DebugPrintVertexQueueState();
            Debug.WriteLine("\r\nUnknown Count = " + unknownCount);
        }
        public void PopulateLinkedList()
        {
            while (VertexQueue.Count > 0)
            {
                var v = VertexQueue.Dequeue();
                var eq = v.edgeQueue;
                while (eq.Count > 0)
                {
                    var e = eq.Dequeue();
                    if (e.state != EdgeState.KNOWN)
                    {
                        LinkedListNode<Edge> n = new LinkedListNode<Edge> (e);
                        EdgeLL.AddLast(n);
                    }
                }
            }
        }
        public int UpdateUnknownCount()
        {
            int temp = 0;
            for (int i = 0; i < n; i++) 
            {
                for(int j = 0; j < n; j++)
                {
                    if (data[i, j] == ' ')
                    {
                        temp++;
                    }
                }
            }
            return temp;
        }
        public void UpdateData()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    data[i, j] = edges[i, j].GetValue();
                }
            }
        }
        private void AddEdge(Vertex inRow, Vertex inColumn, char inValue)
        {
            Edge e = new Edge(this, inRow, inColumn, inValue);
            edges[e.row.Index(), e.col.Index()] = e;
        }
        private void InitAlphabet()
        {
            string s = "";
            for (int i = 0; i < n; i++)
            {
                s += (char)(i + 65) + " ";
                alphabet.Add((char)(i + 65));
            }
            Debug.WriteLine("Alphabet = " + s);
        }
        public bool IsValid(Edge e, char c)
        {
            return e.row.vertexAvailableChars.Contains(c) && e.col.vertexAvailableChars.Contains(c);
        }
        /******************************************
        *  Solve Methods
        * *****************************************/
       
        private bool DFS_Recurse(LinkedListNode<Edge> e)
        {
            unknownCount = UpdateUnknownCount();
            if (unknownCount < 0)
            {
                Debug.WriteLine("Exit Recurse unkownCount = 0");
                return true;
            }

            e.Value.GetAvailableChars();
            foreach (char c in e.Value.GetAvailableChars())
            {
                e.Value.GetAvailableChars();
                if (IsValid(e.Value, c))
                {
                    Debug.WriteLine("Setting E[" + e.Value.row.Index() + ", " + e.Value.col.Index() + ", to " + c);
                    unknownCount--;
                    e.Value.GetAvailableChars().Remove(c);
                    data[e.Value.row.Index(), e.Value.col.Index()] = c;
                    e.Value.SetValue(c);
                    e.Value.GetAvailableChars();
                    if (e.Next == null)
                    {
                        Debug.WriteLine("Exit Recurse e.Next == null");
                        return false;
                    }
                    if (DFS_Recurse(e.Next))
                    {
                        Debug.WriteLine("Exit Recurse IsValid == true");
                        return true;
                    }
                }
                else
                {
                    Debug.WriteLine("Resetting E[" + e.Value.row.Index() + ", " + e.Value.col.Index() + ", to " + ' ');
                    unknownCount++;
                    e.Value.GetAvailableChars().Add(c);
                    data[e.Value.row.Index(), e.Value.col.Index()] = ' ';
                    e.Value.col.vertexAvailableChars.Add(c);
                    e.Value.row.vertexAvailableChars.Add(c);
                    e.Value.GetAvailableChars();
                    if (e.Previous != null)
                    {
                        DFS_Recurse(e.Previous);
                    }
                    else if (e.Next != null)
                    {
                        DFS_Recurse(e.Next);
                    }
                    else
                    {
                        Debug.WriteLine("Exit recurse Edge List is empty!");
                        return false;
                    }
                }
            }
            Debug.WriteLine("Exit Recurse Fallthrough");
            if (e.Next != null)
            {
                DFS_Recurse(e.Next);
            }
            if (unknownCount < 10)
            {
                
                Debug.WriteLine(" Unknown count = " + unknownCount);
                DebugPrintData();
            }
            return false;
        }
        private bool DFS()
        {
            PopulateLinkedList();

            bool solved = false;
            int count = unknownCount;
            if (EdgeLL.First != null)
            {
                solved = DFS_Recurse(EdgeLL.First);
            }
            return solved;
        }
        
        public void Solve()
        {
            //DebugPrintVertexState();
            Debug.WriteLine("Enter DFS() Unknown count  = " + unknownCount);
            DFS();
            DebugPrintData();
        }

        override
        public string ToString()
        {
            string s = "";
            foreach(Vertex v in rows) { s += v.ToString(); }
            s += "\r\n\r\n";
            return s;
        }

        /******************************************
        *  Debug Methods
        * *****************************************/
        private void DebugPrintVertexQueueState()
        {
            string s = "";
            var temp = VertexQueue.UnorderedItems.ToList();
            Debug.WriteLine("\r\n\r\n***    Vertex Queue State:   ***\r\n");
            foreach (var v in temp)
            {
                s += Enum.GetName(v.Element.type) + " " + v.Element.Index() + " Priority = " + v.Priority + "\r\n";
            }
            Debug.WriteLine(s + "\r\n***    End Vertex Queue State:   ***\r\n\r\n");
        }
        private void DebugPrintEdgeLL()
        {
            Debug.WriteLine("***    EdgeLL:     ***");
            foreach (Edge e in EdgeLL)
            {
                Debug.WriteLine(e.ToString());
            }
            Debug.WriteLine("***    End EdgeLL:     ***");
        }

        private void DebugPrintVertexState()
        {
            Debug.WriteLine("\r\n\r\n***    Vertex CharSet State:   ***\r\n");
            for (int i = 0; i < n; i++)
            {
                rows[i].DebugPrintVertexCharSet();
                cols[i].DebugPrintVertexCharSet();
            }
            Debug.WriteLine("\r\n***    End Vertex CharSet State:   ***\r\n\r\n");

            Debug.WriteLine("\r\n\r\n***    Vertex EdgeList State:   ***\r\n");
            for (int i = 0; i < n; i++)
            {
                rows[i].DebugPrintVertexEdgeList();
                cols[i].DebugPrintVertexEdgeList();
            }
            Debug.WriteLine("\r\n\r\n***    Vertex EdgeList State:   ***\r\n");

        }

        private void DebugPrintData()
        {
            // create the edges for each cell
            Debug.WriteLine("\r\nData:");
            string s = "";
            for (int i = 0; i < n; i++)
            {
                s = "[ ";
                for (int j = 0; j < n; j++)
                {
                    s += data[i, j] + " ";
                }
                s += "]";
                Debug.WriteLine(s);
            }
            
        }
    }

    /******************************************
    *  Vertex Class
    * *****************************************/
    public class Vertex
    {
        private BiGraph super;
        public VertexType type;
        private int index;
        public HashSet<char> vertexAvailableChars;
        public PriorityQueue<Edge, int> edgeQueue;
        private List<Edge> edgeList;

        public Vertex(BiGraph inSuper, int inIndex, VertexType inVertexType)
        {
            super = inSuper;
            vertexAvailableChars = new HashSet<char>(super.alphabet);
            edgeQueue = new();
            edgeList = [];
            index = inIndex;
            type = inVertexType;
        }
        public void AddEdge(Edge edge)
        {
            if(type == VertexType.Row)
            {
                for(int i = 0; i < super.n; i++)
                {
                    if (data[index, i] != ' ')
                    {
                        vertexAvailableChars.Remove(data[index, i]);
                    }
                } 
            }
            else
            {
                for (int i = 0; i < super.n; i++)
                {
                    if (data[i, index] != ' ')
                    {
                        vertexAvailableChars.Remove(data[i, index]);
                    }
                }
            }
            edgeQueue.Enqueue(edge, edge.GetAvailableCharCount());
            edgeList.Add(edge);
        }
        public int Index()
        {
            return index;
        }
        public void DebugPrintVertexEdgeList()
        {
            Debug.WriteLine("Edges in " + Enum.GetName(typeof(VertexType), type) + " " + this.Index() + ":");
            foreach(Edge edge in edgeList)
            {
                Debug.WriteLine(edge.ToString());
            }
        }
        public void DebugPrintVertexCharSet()
        {
            string s = "";
            foreach (char c in vertexAvailableChars) { s += c + " "; }
            Debug.WriteLine("CharSet of V[" + Enum.GetName(type) + index + "]: { " + s + "}");
        }
        override
        public string ToString()
        {
            string s = "R" + index + ": ";
            foreach (Edge e in edgeList) s += e.ToString();
            s += "\r\n";
            return s;
        }
    }

    /******************************************
    *  Edge Class
    * *****************************************/
    public class Edge
    {
        private BiGraph super;
        private char value;
        public EdgeState state;
        private HashSet<char> availableChars;

        public Vertex row { get; set; }
        public Vertex col { get; set; }

        public Edge(BiGraph inSuper, Vertex inRow, Vertex inCol, char inValue)
        {
            super = inSuper;
            availableChars = new HashSet<char>(super.alphabet);
            value = inValue; 
            row = inRow;
            col = inCol;

            if (value != ' ')
            {
                state = EdgeState.KNOWN;
                super.unknownCount--;
            }
            else
            {
                state = EdgeState.UNVISITED;
            }
            UpdateAvailableChars();
            row.AddEdge(this);
            col.AddEdge(this);
        }
        public void DebugPrintEdgeCharSet()
        {
            string s = "";
            foreach(char c in availableChars) {s += c + " "; }
            Debug.WriteLine("CharSet of E[" + row.Index() + ", " + col.Index() + "]: { " + s + "}");
        }
        public int GetAvailableCharCount() { UpdateAvailableChars(); return availableChars.Count; }
        private void UpdateAvailableChars()
        {
            availableChars.IntersectWith(row.vertexAvailableChars.Intersect(col.vertexAvailableChars));
        }
        public HashSet<char> GetAvailableChars()
        {
            UpdateAvailableChars();
            return availableChars;
        }
        public void RemoveChar(char inChar)
        {
            availableChars.Remove(inChar);
            UpdateAvailableChars();
        }
        public void AddChar(char inChar)
        {
            availableChars.Add(inChar);
            UpdateAvailableChars();
        }
        public char GetValue()
        {
            return value;
        }
        public void SetValue(char inValue)
        {
            switch (state)
            {
                case EdgeState.KNOWN:
                    Debug.WriteLine("Attempted to Set Value of known edge in BiGraph Edge Class!");
                    break;
                case EdgeState.UNVISITED:
                    value = inValue;
                    state = EdgeState.VISITED;
                    row.vertexAvailableChars.Remove(inValue);
                    col.vertexAvailableChars.Remove(inValue);
                    UpdateAvailableChars();
                    break;
                case EdgeState.VISITED:
                    value = inValue;
                    row.vertexAvailableChars.Remove(inValue);
                    col.vertexAvailableChars.Remove(inValue);
                    UpdateAvailableChars();
                    break;
                default:
                    Debug.WriteLine("Edge with undefined state in BiGraph Edge Class!");
                    break;
            }
            UpdateAvailableChars();
        }
        override
        public string ToString()
        {
            return "E[C" + col.Index() + ", V='" + value + "']";
        }
    }
}

