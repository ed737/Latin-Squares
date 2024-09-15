namespace Latin_Squares
{
    partial class FormSolver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gb_Setup = new GroupBox();
            label1 = new Label();
            btn_Next = new Button();
            nud_OrderSelect = new NumericUpDown();
            latinSquare_Generate = new LatinSquareGenerate();
            gb_Generate = new GroupBox();
            btn_Solve = new Button();
            btn_Back = new Button();
            gb_Solve = new GroupBox();
            cb_StepSolve = new CheckBox();
            btn_SolverSolve = new Button();
            latinSquare_Solver = new LatinSquareSolve();
            btn_BackSolve = new Button();
            tb_GraphText = new TextBox();
            gb_Setup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_OrderSelect).BeginInit();
            gb_Generate.SuspendLayout();
            gb_Solve.SuspendLayout();
            SuspendLayout();
            // 
            // gb_Setup
            // 
            gb_Setup.Controls.Add(label1);
            gb_Setup.Controls.Add(btn_Next);
            gb_Setup.Controls.Add(nud_OrderSelect);
            gb_Setup.Location = new Point(34, 21);
            gb_Setup.Name = "gb_Setup";
            gb_Setup.Size = new Size(305, 129);
            gb_Setup.TabIndex = 2;
            gb_Setup.TabStop = false;
            gb_Setup.Text = "Setup";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 24);
            label1.Name = "label1";
            label1.Size = new Size(255, 17);
            label1.TabIndex = 6;
            label1.Text = "Select Order of Latin Square to Generate...";
            // 
            // btn_Next
            // 
            btn_Next.Location = new Point(183, 81);
            btn_Next.Name = "btn_Next";
            btn_Next.Size = new Size(65, 23);
            btn_Next.TabIndex = 5;
            btn_Next.Text = "Next";
            btn_Next.UseVisualStyleBackColor = true;
            btn_Next.Click += btn_Next_Click;
            // 
            // nud_OrderSelect
            // 
            nud_OrderSelect.AllowDrop = true;
            nud_OrderSelect.Location = new Point(46, 81);
            nud_OrderSelect.Maximum = new decimal(new int[] { 26, 0, 0, 0 });
            nud_OrderSelect.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_OrderSelect.Name = "nud_OrderSelect";
            nud_OrderSelect.ReadOnly = true;
            nud_OrderSelect.Size = new Size(49, 23);
            nud_OrderSelect.TabIndex = 4;
            nud_OrderSelect.TextAlign = HorizontalAlignment.Center;
            nud_OrderSelect.Value = new decimal(new int[] { 9, 0, 0, 0 });
            // 
            // latinSquare_Generate
            // 
            latinSquare_Generate.Location = new Point(6, 67);
            latinSquare_Generate.Name = "latinSquare_Generate";
            latinSquare_Generate.Size = new Size(548, 614);
            latinSquare_Generate.TabIndex = 3;
            // 
            // gb_Generate
            // 
            gb_Generate.Controls.Add(btn_Solve);
            gb_Generate.Controls.Add(btn_Back);
            gb_Generate.Controls.Add(latinSquare_Generate);
            gb_Generate.Enabled = false;
            gb_Generate.Location = new Point(34, 156);
            gb_Generate.Name = "gb_Generate";
            gb_Generate.Size = new Size(555, 687);
            gb_Generate.TabIndex = 4;
            gb_Generate.TabStop = false;
            gb_Generate.Text = "Generate Latin Square";
            // 
            // btn_Solve
            // 
            btn_Solve.Location = new Point(434, 36);
            btn_Solve.Name = "btn_Solve";
            btn_Solve.Size = new Size(100, 25);
            btn_Solve.TabIndex = 5;
            btn_Solve.Text = "Solve";
            btn_Solve.UseVisualStyleBackColor = true;
            btn_Solve.Click += btn_Solve_Click;
            // 
            // btn_Back
            // 
            btn_Back.Location = new Point(25, 36);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(100, 25);
            btn_Back.TabIndex = 4;
            btn_Back.Text = "Back";
            btn_Back.UseVisualStyleBackColor = true;
            btn_Back.Click += btn_Back_Click;
            // 
            // gb_Solve
            // 
            gb_Solve.Controls.Add(cb_StepSolve);
            gb_Solve.Controls.Add(btn_SolverSolve);
            gb_Solve.Controls.Add(latinSquare_Solver);
            gb_Solve.Controls.Add(btn_BackSolve);
            gb_Solve.Enabled = false;
            gb_Solve.Location = new Point(606, 156);
            gb_Solve.Name = "gb_Solve";
            gb_Solve.Size = new Size(563, 687);
            gb_Solve.TabIndex = 5;
            gb_Solve.TabStop = false;
            gb_Solve.Text = "Solve Latin Square";
            // 
            // cb_StepSolve
            // 
            cb_StepSolve.AutoSize = true;
            cb_StepSolve.Location = new Point(322, 40);
            cb_StepSolve.Name = "cb_StepSolve";
            cb_StepSolve.Size = new Size(97, 19);
            cb_StepSolve.TabIndex = 7;
            cb_StepSolve.Text = "Step Through";
            cb_StepSolve.UseVisualStyleBackColor = true;
            cb_StepSolve.CheckedChanged += cb_StepSolve_CheckedChanged;
            // 
            // btn_SolverSolve
            // 
            btn_SolverSolve.Location = new Point(436, 36);
            btn_SolverSolve.Name = "btn_SolverSolve";
            btn_SolverSolve.Size = new Size(100, 25);
            btn_SolverSolve.TabIndex = 6;
            btn_SolverSolve.Text = "Solve";
            btn_SolverSolve.UseVisualStyleBackColor = true;
            btn_SolverSolve.Click += btn_SolverSolve_Click;
            // 
            // latinSquare_Solver
            // 
            latinSquare_Solver.Location = new Point(7, 67);
            latinSquare_Solver.Name = "latinSquare_Solver";
            latinSquare_Solver.Size = new Size(548, 614);
            latinSquare_Solver.TabIndex = 5;
            // 
            // btn_BackSolve
            // 
            btn_BackSolve.Location = new Point(25, 36);
            btn_BackSolve.Name = "btn_BackSolve";
            btn_BackSolve.Size = new Size(100, 25);
            btn_BackSolve.TabIndex = 4;
            btn_BackSolve.Text = "Back";
            btn_BackSolve.UseVisualStyleBackColor = true;
            btn_BackSolve.Click += btn_BackSolve_Click;
            // 
            // tb_GraphText
            // 
            tb_GraphText.Location = new Point(345, 28);
            tb_GraphText.Multiline = true;
            tb_GraphText.Name = "tb_GraphText";
            tb_GraphText.ScrollBars = ScrollBars.Both;
            tb_GraphText.Size = new Size(824, 122);
            tb_GraphText.TabIndex = 6;
            tb_GraphText.WordWrap = false;
            // 
            // FormSolver
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 855);
            Controls.Add(tb_GraphText);
            Controls.Add(gb_Solve);
            Controls.Add(gb_Generate);
            Controls.Add(gb_Setup);
            MaximizeBox = false;
            Name = "FormSolver";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Latin Square Generator and Solver";
            gb_Setup.ResumeLayout(false);
            gb_Setup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_OrderSelect).EndInit();
            gb_Generate.ResumeLayout(false);
            gb_Solve.ResumeLayout(false);
            gb_Solve.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        //private LatinSquareGrid latinSquare_Generate = new LatinSquareGrid();
        private GroupBox gb_Setup;
        private Label label1;
        private Button btn_Next;
        private NumericUpDown nud_OrderSelect;
        private LatinSquareGenerate latinSquare_Generate;
        private GroupBox gb_Generate;
        private Button btn_Solve;
        private Button btn_Back;
        private GroupBox gb_Solve;
        private Button btn_BackSolve;
        private LatinSquareSolve latinSquare_Solver;
        private TextBox tb_GraphText;
        private CheckBox cb_StepSolve;
        private Button btn_SolverSolve;
    }
}