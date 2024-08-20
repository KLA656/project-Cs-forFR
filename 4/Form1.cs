using System;
using System.Windows.Forms;

namespace CommissionCalculatorApp
{
    public partial class Form1 : Form
    {
        private TextBox salesAmountTextBox;
        private Button calculateButton;
        private Label resultLabel;
        private Label salesAmountLabel;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.salesAmountTextBox = new TextBox();
            this.calculateButton = new Button();
            this.resultLabel = new Label();
            this.salesAmountLabel = new Label();

            // 
            // salesAmountTextBox
            // 
            this.salesAmountTextBox.Location = new System.Drawing.Point(120, 12);
            this.salesAmountTextBox.Name = "salesAmountTextBox";
            this.salesAmountTextBox.Size = new System.Drawing.Size(100, 20);
            this.salesAmountTextBox.TabIndex = 0;

            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(12, 38);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 1;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new EventHandler(this.calculateButton_Click);

            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(12, 64);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(260, 100);
            this.resultLabel.TabIndex = 2;

            // 
            // salesAmountLabel
            // 
            this.salesAmountLabel.Location = new System.Drawing.Point(12, 15);
            this.salesAmountLabel.Name = "salesAmountLabel";
            this.salesAmountLabel.Size = new System.Drawing.Size(100, 20);
            this.salesAmountLabel.Text = "Sales Amount:";

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.Controls.Add(this.salesAmountLabel);
            this.Controls.Add(this.salesAmountTextBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.resultLabel);
            this.Name = "Form1";
            this.Text = "Commission Calculator";
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            decimal salesAmount;

            // Validate input
            if (!decimal.TryParse(salesAmountTextBox.Text, out salesAmount))
            {
                MessageBox.Show("Invalid sales amount.");
                return;
            }

            // Create Sales object
            Sales sales = new Sales
            {
                SalesAmount = salesAmount
            };

            // Calculate commission
            CommissionCalculator calculator = new CommissionCalculator();
            decimal commission = calculator.CalculateCommission(sales.SalesAmount);

            // Display results
            resultLabel.Text = $"Sales Amount: {sales.SalesAmount} บาท\n" +
                               $"Commission: {commission} บาท";
        }
    }

    // Sales class
    public class Sales
    {
        public decimal SalesAmount { get; set; }
    }

    // CommissionCalculator class
    public class CommissionCalculator
    {
        public decimal CalculateCommission(decimal salesAmount)
        {
            if (salesAmount >= 1 && salesAmount <= 3000)
                return salesAmount * 0.03m;
            else if (salesAmount > 3000 && salesAmount <= 5000)
                return salesAmount * 0.05m;
            else if (salesAmount > 5000 && salesAmount <= 10000)
                return salesAmount * 0.07m;
            else if (salesAmount > 10000 && salesAmount <= 15000)
                return salesAmount * 0.10m;
            else if (salesAmount > 15000 && salesAmount <= 20000)
                return salesAmount * 0.12m;
            else
                return salesAmount * 0.20m;
        }
    }
}
