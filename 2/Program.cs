using System;
using System.Windows.Forms;

namespace GradeCalculatorApp
{
    public partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtScore;
        private Button btnCalculate;
        private Label lblGrade;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtScore = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblGrade = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtScore
            this.txtScore.ForeColor = System.Drawing.Color.Gray;
            this.txtScore.Text = "Enter Score";
            this.txtScore.Enter += new System.EventHandler(this.txtScore_Enter);
            this.txtScore.Leave += new System.EventHandler(this.txtScore_Leave);
            this.txtScore.Location = new System.Drawing.Point(100, 50);
            this.txtScore.Size = new System.Drawing.Size(200, 20);

            // btnCalculate
            this.btnCalculate.Location = new System.Drawing.Point(100, 100);
            this.btnCalculate.Text = "Calculate Grade";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            this.btnCalculate.Size = new System.Drawing.Size(200, 23);

            // lblGrade
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(100, 150);
            this.lblGrade.Size = new System.Drawing.Size(0, 13);

            // Form1
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblGrade);
            this.Name = "Form1";
            this.Text = "Grade Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int score = int.Parse(txtScore.Text);
                GradeCalculator calculator = new GradeCalculator();
                string grade = calculator.CalculateGrade(score);

                lblGrade.Text = $"เกรดที่ได้: {grade}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("โปรดใส่คะแนนให้ถูกต้อง\n" + ex.Message);
            }
        }

        private void txtScore_Enter(object sender, EventArgs e)
        {
            if (txtScore.Text == "Enter Score")
            {
                txtScore.Text = "";
                txtScore.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtScore_Leave(object sender, EventArgs e)
        {
            if (txtScore.Text == "")
            {
                txtScore.Text = "Enter Score";
                txtScore.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }

    public class GradeCalculator
    {
        public string CalculateGrade(int score)
        {
            if (score >= 80 && score <= 100)
                return "A";
            else if (score >= 75 && score < 80)
                return "B+";
            else if (score >= 70 && score < 75)
                return "B";
            else if (score >= 65 && score < 70)
                return "C+";
            else if (score >= 60 && score < 65)
                return "C";
            else if (score >= 55 && score < 60)
                return "D+";
            else if (score >= 50 && score < 55)
                return "D";
            else
                return "F";
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
