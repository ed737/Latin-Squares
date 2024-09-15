using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Latin_Squares
{
    public partial class LatinSquareGenerate : UserControl
    {
        private int n;
        private DataGrid data;
        private Random rand = new Random();
        private NumericUpDown nud_RemoveCellsCount;
        private Button btn_ClearCells;
        private Button btn_Invalidate;
        private Button btn_Validate;
        private Button btn_Randomize;
        private Button btn_SwapColumn;
        private Button btn_SwapRow;
        private Button btn_Reset;
        private bool partialSquare = false;

        public LatinSquareGenerate(){
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            dataGridView = new DataGridView();
            nud_RemoveCellsCount = new NumericUpDown();
            btn_ClearCells = new Button();
            btn_Invalidate = new Button();
            btn_Validate = new Button();
            btn_Randomize = new Button();
            btn_SwapColumn = new Button();
            btn_SwapRow = new Button();
            btn_Reset = new Button();
            ((ISupportInitialize)dataGridView).BeginInit();
            ((ISupportInitialize)nud_RemoveCellsCount).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AccessibleRole = AccessibleRole.None;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.NullValue = " ";
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeight = 20;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = " ";
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.Enabled = false;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ImeMode = ImeMode.Disable;
            dataGridView.Location = new Point(10, 10);
            dataGridView.Margin = new Padding(10);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 20;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = " ";
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowTemplate.DefaultCellStyle.BackColor = SystemColors.Control;
            dataGridView.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView.RowTemplate.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = SystemColors.Control;
            dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
            dataGridView.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridView.RowTemplate.Height = 20;
            dataGridView.RowTemplate.ReadOnly = true;
            dataGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView.ScrollBars = ScrollBars.None;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.ShowCellErrors = false;
            dataGridView.ShowCellToolTips = false;
            dataGridView.ShowEditingIcon = false;
            dataGridView.ShowRowErrors = false;
            dataGridView.Size = new Size(526, 526);
            dataGridView.TabIndex = 3;
            dataGridView.TabStop = false;
            // 
            // nud_RemoveCellsCount
            // 
            nud_RemoveCellsCount.Location = new Point(223, 578);
            nud_RemoveCellsCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nud_RemoveCellsCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_RemoveCellsCount.Name = "nud_RemoveCellsCount";
            nud_RemoveCellsCount.ReadOnly = true;
            nud_RemoveCellsCount.Size = new Size(100, 23);
            nud_RemoveCellsCount.TabIndex = 19;
            nud_RemoveCellsCount.TextAlign = HorizontalAlignment.Center;
            nud_RemoveCellsCount.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btn_ClearCells
            // 
            btn_ClearCells.Location = new Point(329, 578);
            btn_ClearCells.Name = "btn_ClearCells";
            btn_ClearCells.Size = new Size(100, 23);
            btn_ClearCells.TabIndex = 18;
            btn_ClearCells.Text = "Clear Cells";
            btn_ClearCells.UseVisualStyleBackColor = true;
            btn_ClearCells.Click += btn_RemoveCells_Click;
            // 
            // btn_Invalidate
            // 
            btn_Invalidate.Location = new Point(11, 578);
            btn_Invalidate.Name = "btn_Invalidate";
            btn_Invalidate.Size = new Size(100, 23);
            btn_Invalidate.TabIndex = 17;
            btn_Invalidate.Text = "Invalidate";
            btn_Invalidate.UseVisualStyleBackColor = true;
            btn_Invalidate.Click += btn_Invalidate_Click;
            // 
            // btn_Validate
            // 
            btn_Validate.Location = new Point(437, 549);
            btn_Validate.Name = "btn_Validate";
            btn_Validate.Size = new Size(100, 23);
            btn_Validate.TabIndex = 16;
            btn_Validate.Text = "Validate";
            btn_Validate.UseVisualStyleBackColor = true;
            btn_Validate.Click += btn_Validate_Click;
            // 
            // btn_Randomize
            // 
            btn_Randomize.Location = new Point(329, 549);
            btn_Randomize.Name = "btn_Randomize";
            btn_Randomize.Size = new Size(100, 23);
            btn_Randomize.TabIndex = 15;
            btn_Randomize.Text = "Randomize";
            btn_Randomize.UseVisualStyleBackColor = true;
            btn_Randomize.Click += btn_Randomize_Click;
            // 
            // btn_SwapColumn
            // 
            btn_SwapColumn.Location = new Point(223, 549);
            btn_SwapColumn.Name = "btn_SwapColumn";
            btn_SwapColumn.Size = new Size(100, 23);
            btn_SwapColumn.TabIndex = 14;
            btn_SwapColumn.Text = "Swap Column";
            btn_SwapColumn.UseVisualStyleBackColor = true;
            btn_SwapColumn.Click += btn_SwapColumn_Click;
            // 
            // btn_SwapRow
            // 
            btn_SwapRow.Location = new Point(117, 549);
            btn_SwapRow.Name = "btn_SwapRow";
            btn_SwapRow.Size = new Size(100, 23);
            btn_SwapRow.TabIndex = 13;
            btn_SwapRow.Text = "Swap Row";
            btn_SwapRow.UseVisualStyleBackColor = true;
            btn_SwapRow.Click += btn_SwapRow_Click;
            // 
            // btn_Reset
            // 
            btn_Reset.Location = new Point(11, 549);
            btn_Reset.Name = "btn_Reset";
            btn_Reset.Size = new Size(100, 23);
            btn_Reset.TabIndex = 12;
            btn_Reset.Text = "Reset";
            btn_Reset.UseVisualStyleBackColor = true;
            btn_Reset.Click += btn_Reset_Click;
            // 
            // LatinSquareGenerate
            // 
            Controls.Add(nud_RemoveCellsCount);
            Controls.Add(btn_ClearCells);
            Controls.Add(btn_Invalidate);
            Controls.Add(btn_Validate);
            Controls.Add(btn_Randomize);
            Controls.Add(btn_SwapColumn);
            Controls.Add(btn_SwapRow);
            Controls.Add(btn_Reset);
            Controls.Add(dataGridView);
            Name = "LatinSquareGenerate";
            Size = new Size(548, 614);
            ((ISupportInitialize)dataGridView).EndInit();
            ((ISupportInitialize)nud_RemoveCellsCount).EndInit();
            ResumeLayout(false);
        }
        public void Init(int inN)
        {
            data = new DataGrid(inN);
           
            n = inN;
            dataGridView.ColumnCount = n;
            dataGridView.RowCount = n;
            nud_RemoveCellsCount.Maximum = n * n;
            nud_RemoveCellsCount.Minimum = 1;
            nud_RemoveCellsCount.Value = n;
            // setup grid cell widths
            for (int i = 0; i < n; i++)
            {
                dataGridView.Columns[i].Width = 20;
            }
            UpdateData();
        }
        public DataGrid GetDataGrid()
        {
            return data;
        }
        public void SwapRows(int a, int b)
        {
            data.SwapRows(a, b);
            UpdateData();
        }
        public void SwapColumns(int a, int b)
        {
            data.SwapColumns(a, b);
            UpdateData();
        }
        // this method will duplicate an element
        // into the same row or column to break
        // the Latin square property for testing.
        private void Invalidate()
        {
            int i = rand.Next(0, n - 1);
            int j = rand.Next(0, n - 1);
            data.Invalidate(i, j);
            UpdateData();
        }
        private void UpdateData()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = data.data[i, j];
                }
            }
        }
        private void Identity()
        {
            data.PopulateIdentity();
            partialSquare = false;
            UpdateData();
        }
       

        private DataGridView dataGridView;

        public void Shuffle()
        {
            int rowWise = rand.Next(0, 2);
            int indexA = rand.Next(0, n);
            int indexB = rand.Next(0, n);
            while (indexA == indexB)
            {
                indexB = rand.Next(0, n);
            }

            if (rowWise == 0)
            {
                SwapColumns(indexA, indexB);
            }
            else
            {
                SwapRows(indexA, indexB);
            }
        }
        
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Identity();
            partialSquare = false;
        }

        private void btn_SwapColumn_Click(object sender, EventArgs e)
        {
            int indexA = rand.Next(0, n);
            int indexB = rand.Next(0, n);
            while (indexA == indexB)
            {
                indexB = rand.Next(0, n);
            }
            SwapColumns(indexA, indexB);
            UpdateData();
        }

        private void btn_SwapRow_Click(object sender, EventArgs e)
        {
            int indexA = rand.Next(0, n);
            int indexB = rand.Next(0, n);
            while (indexA == indexB)
            {
                indexB = rand.Next(0, n);
            }
            SwapRows(indexA, indexB);
            UpdateData();
        }

        private void btn_Randomize_Click(object sender, EventArgs e)
        {
            int m = rand.Next(100, 500);
            while (m > 0)
            {
                Shuffle();
                m--;
            }
            UpdateData();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            bool valid = data.Validate(partialSquare, 0);
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
        }

        private void btn_Invalidate_Click(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void btn_RemoveCells_Click(object sender, EventArgs e)
        {
            
           int m = (int)nud_RemoveCellsCount.Value + 1;
            int i = rand.Next(0, n);
            int j = rand.Next(0, n);
            while (m > 0)
            {
                data.ClearCell(i, j);
                i = rand.Next(0, n);
                j = rand.Next(0, n);
                m--;
            }
            partialSquare = true;
            UpdateData();
            
        }

    }
       

}
 