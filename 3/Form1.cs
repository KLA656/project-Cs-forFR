using System;
using System.Windows.Forms;

namespace WageCalculatorApp
{
    public partial class Form1 : Form
    {
        private TextBox nameTextBox;
        private TextBox hoursWorkedTextBox;
        private TextBox hourlyRateTextBox;
        private Button calculateButton;
        private Label resultLabel;
        private Label nameLabel;
        private Label hoursWorkedLabel;
        private Label hourlyRateLabel;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.nameTextBox = new TextBox();
            this.hoursWorkedTextBox = new TextBox();
            this.hourlyRateTextBox = new TextBox();
            this.calculateButton = new Button();
            this.resultLabel = new Label();
            this.nameLabel = new Label();
            this.hoursWorkedLabel = new Label();
            this.hourlyRateLabel = new Label();

            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(120, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(150, 20);
            this.nameTextBox.TabIndex = 0;
            
            // 
            // hoursWorkedTextBox
            // 
            this.hoursWorkedTextBox.Location = new System.Drawing.Point(120, 38);
            this.hoursWorkedTextBox.Name = "hoursWorkedTextBox";
            this.hoursWorkedTextBox.Size = new System.Drawing.Size(100, 20);
            this.hoursWorkedTextBox.TabIndex = 1;

            // 
            // hourlyRateTextBox
            // 
            this.hourlyRateTextBox.Location = new System.Drawing.Point(120, 64);
            this.hourlyRateTextBox.Name = "hourlyRateTextBox";
            this.hourlyRateTextBox.Size = new System.Drawing.Size(100, 20);
            this.hourlyRateTextBox.TabIndex = 2;

            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(12, 90);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 3;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new EventHandler(this.calculateButton_Click);

            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(12, 116);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(260, 100);
            this.resultLabel.TabIndex = 4;

            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(12, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(100, 20);
            this.nameLabel.Text = "Employee Name:";

            // 
            // hoursWorkedLabel
            // 
            this.hoursWorkedLabel.Location = new System.Drawing.Point(12, 41);
            this.hoursWorkedLabel.Name = "hoursWorkedLabel";
            this.hoursWorkedLabel.Size = new System.Drawing.Size(100, 20);
            this.hoursWorkedLabel.Text = "Hours Worked:";

            // 
            // hourlyRateLabel
            // 
            this.hourlyRateLabel.Location = new System.Drawing.Point(12, 67);
            this.hourlyRateLabel.Name = "hourlyRateLabel";
            this.hourlyRateLabel.Size = new System.Drawing.Size(100, 20);
            this.hourlyRateLabel.Text = "Hourly Rate:";

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.hoursWorkedLabel);
            this.Controls.Add(this.hourlyRateLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.hoursWorkedTextBox);
            this.Controls.Add(this.hourlyRateTextBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.resultLabel);
            this.Name = "Form1";
            this.Text = "Wage Calculator";
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // Retrieve input values
            string name = nameTextBox.Text;
            int hoursWorked;
            decimal hourlyRate;

            // Validate inputs
            if (!int.TryParse(hoursWorkedTextBox.Text, out hoursWorked))
            {
                MessageBox.Show("Invalid number of hours worked.");
                return;
            }
            if (!decimal.TryParse(hourlyRateTextBox.Text, out hourlyRate))
            {
                MessageBox.Show("Invalid hourly rate.");
                return;
            }

            // Create Employee object
            Employee employee = new Employee
            {
                Name = name,
                HoursWorked = hoursWorked,
                HourlyRate = hourlyRate
            };

            // Calculate wages
            WageCalculator calculator = new WageCalculator();
            decimal wages = calculator.CalculateWages(employee.HoursWorked, employee.HourlyRate);

            // Display results
            resultLabel.Text = $"ชื่อพนักงาน: {employee.Name}\n" +
                               $"จำนวนชั่วโมงทำงาน: {employee.HoursWorked}\n" +
                               $"ค่าแรงที่ได้รับ: {wages} บาท";
        }
    }

    // Employee class
    public class Employee
    {
        public string Name { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
    }

    // WageCalculator class
    public class WageCalculator
    {
        public decimal CalculateWages(int hoursWorked, decimal hourlyRate)
        {
            if (hoursWorked <= 8)
            {
                return hoursWorked * hourlyRate;
            }
            else
            {
                int overtimeHours = hoursWorked - 8;
                return (8 * hourlyRate) + (overtimeHours * hourlyRate * 1.5m);
            }
        }
    }
}
