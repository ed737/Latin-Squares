using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latin_Squares
{
    public class DataGrid : IEnumerable<char>
    {
       
        public char[,] data;
        private int n;
        public Queue<char> charQueue = new();
        public DataGrid(int inN)
        {
            n = inN;
            data = new char[n, n];
            PopulateCharQueue();
            PopulateIdentity();
        }
        public void PopulateCharQueue()
        {
            // Create list of characters up to order N
            for (int i = 0; i < n; i++)
            {
                charQueue.Enqueue((char)(i + 65));
            }
        }
        public void PopulateIdentity()
        {
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    data[i, j] = charQueue.ElementAt(j);
                }
                charQueue.Enqueue(charQueue.Dequeue());
            }
        }

        public char[] GetRow(int i)
        {
            return Enumerable.Range(0, n).Select(x => data[i, x]).ToArray();
        }
        public void SetRow(int rIndex, char[] inRow)
        {
            for (int i = 0; i < n; i++)
            {
                data[rIndex, i] = inRow[i];
            }
        }

        public char[] GetColumn(int i)
        {
            return Enumerable.Range(0, n).Select(x => data[x, i]).ToArray();
        }

        public void SetColumn(int cIndex, char[] inColumn)
        {
            for (int i = 0; i < n; i++)
            {
                data[i, cIndex] = inColumn[i];
            }
        }

        public void SwapRows(int a, int b)
        {
            char[] temp = GetRow(a);
            SetRow(a, GetRow(b));
            SetRow(b, temp);

        }
        public void SwapColumns(int a, int b)
        {
            char[] temp = GetColumn(a);
            SetColumn(a, GetColumn(b));
            SetColumn(b, temp);

        }
        public bool Validate(bool partialValidation, int errorCount)
        {
            bool result = true;
            HashSet<char> set = new HashSet<char>();
            // validate Rows:
            for (int i = 0; i < n; i++)
            {
                set.Clear();
                for (int m = 0; m < n; m++)
                {
                    set.Add(charQueue.ElementAt(m));
                }
                for (int j = 0; j < n; j++)
                {
                    if (set.Contains(data[i, j]))
                    {
                        set.Remove(data[i, j]);
                    }

                    else
                    {
                        if (data[i, j] != ' ')
                        {
                            errorCount++;
                            result = false;
                        }
                    }
                }

                if (!partialValidation)
                {
                    if (set.Count != 0)
                    {
                        errorCount++;
                        result = false;
                    }
                }
            }
            // Validate Columns:
            for (int i = 0; i < n; i++)
            {
                set.Clear();
                for (int m = 0; m < n; m++)
                {
                    set.Add(charQueue.ElementAt(m));
                }
                for (int j = 0; j < n; j++)
                {
                    if (set.Contains(data[j, i]))
                    {
                        set.Remove(data[j, i]);
                    }

                    else
                    {
                        if (data[j, i] != ' ')
                        {
                            errorCount++;
                            result = false;
                        }
                    }
                }

                if (!partialValidation)
                {
                    if (set.Count != 0)
                    {
                        errorCount++;
                        result = false;
                    }
                }

            }
            return result;
        }
        public void Invalidate(int i, int j)
        {
            char c = data[i, j];
            data[i + 1, j] = c;

        }
        public void ClearCell(int i, int j)
        {
            data[i, j] = ' ';
        }
        override
        public string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < n; i++)
            {
                s += "{ ";
                for (int j = 0; j < n; j++)
                {
                    s += data[i, j] + " ";
                }
                s += "}\r\n";
            }
            return s;
        }

        public IEnumerator<char> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
