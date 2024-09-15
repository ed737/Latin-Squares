using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latin_Squares
{
    public partial class FormSolver : Form
    {
        private int n;
        private DataGrid grid;
        private bool stepThroughSolve = false;
        public FormSolver()
        {
            InitializeComponent();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            n = (int)nud_OrderSelect.Value;
            gb_Setup.Enabled = false;
            latinSquare_Generate.Init(n);
            gb_Generate.Enabled = true;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            gb_Generate.Enabled = false;
            gb_Setup.Enabled = true;
        }

        private void btn_Solve_Click(object sender, EventArgs e)
        {
            gb_Generate.Enabled = false;

            grid = new DataGrid(n);
            grid = latinSquare_Generate.GetDataGrid();
            latinSquare_Solver.Init(n, grid);
            gb_Solve.Enabled = true;
            tb_GraphText.Text = latinSquare_Solver.GetGraphText();
            btn_SolverSolve.Enabled = true;
        }

        private void btn_BackSolve_Click(object sender, EventArgs e)
        {
            gb_Generate.Enabled = true;
            gb_Solve.Enabled = false;
            latinSquare_Solver.ClearText();
            tb_GraphText.Text = "";
        }

        private void cb_StepSolve_CheckedChanged(object sender, EventArgs e)
        {
                stepThroughSolve = cb_StepSolve.Checked;
               
        }

        private void btn_SolverSolve_Click(object sender, EventArgs e)
        {
            btn_SolverSolve.Enabled = false;
            cb_StepSolve.Enabled = false;
            if (stepThroughSolve)
            {

            }

            latinSquare_Solver.graph.Solve();
            latinSquare_Solver.UpdateData();
        }
    }
}
