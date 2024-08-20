using System;
using System.Windows.Forms;

namespace GradeCalculatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

