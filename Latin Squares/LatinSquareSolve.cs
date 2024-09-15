using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Latin_Squares
{
    public partial class LatinSquareSolve : UserControl
    {
        public BiGraph graph;
        public static DataGrid data;
        private string graphText;
        private int n;
        bool partialSquare = true;
        public LatinSquareSolve()
        {
            InitializeComponent();
        }

        public void Init(int n, DataGrid dataGrid)
        {
            this.n = n;
            graph = new BiGraph(n, dataGrid.data);
            data = new DataGrid(n);
            graphText = graph.ToString();
            dataGridView.ColumnCount = n;
            dataGridView.RowCount = n;
            // setup grid cell widths
            for (int i = 0; i < n; i++)
            {
                dataGridView.Columns[i].Width = 20;
            }
            UpdateData();

        }
        public void ClearText()
        {
            graphText = "";
        }
        public string GetGraphText()
        {
            return graphText;
        }

        public void UpdateData()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (BiGraph.data[i, j] == ' ') partialSquare = true;
                    dataGridView.Rows[i].Cells[j].Value = BiGraph.data[i, j];
                    data.data[i, j] = BiGraph.data[i, j];
                }
            }
        }

        private void btn_Validate_Click_1(object sender, EventArgs e)
        {
            int errorCount = 0;
            bool valid = data.Validate(partialSquare, errorCount);
            if (valid)
            {
                if (partialSquare)
                {
                    System.Windows.Forms.MessageBox.Show("Valid Partial Latin Square.");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Valid Complete Latin Square.");
                }
            }
            else
            {
                if (partialSquare)
                {
                    System.Windows.Forms.MessageBox.Show("InValid Partial Square!");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("InValid Complete Square!");
                }

            }
            lbl_ErrorCount.Text = errorCount.ToString() + " errors found!";
        }
    }
}
