using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        // Define controls
        private TextBox txtProductName;
        private TextBox txtProductPrice;
        private Label lblDiscount;
        private Label lblFinalPrice;
        private Button btnCalculate;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Initialize controls
            this.txtProductName = new TextBox();
            this.txtProductPrice = new TextBox();
            this.lblDiscount = new Label();
            this.lblFinalPrice = new Label();
            this.btnCalculate = new Button();

            // Set properties of controls
            this.txtProductName.Location = new System.Drawing.Point(20, 20);
            this.txtProductName.Size = new System.Drawing.Size(200, 20);

            this.txtProductPrice.Location = new System.Drawing.Point(20, 50);
            this.txtProductPrice.Size = new System.Drawing.Size(200, 20);

            this.lblDiscount.Location = new System.Drawing.Point(20, 110);
            this.lblDiscount.Size = new System.Drawing.Size(200, 20);

            this.lblFinalPrice.Location = new System.Drawing.Point(20, 140);
            this.lblFinalPrice.Size = new System.Drawing.Size(200, 20);

            this.btnCalculate.Location = new System.Drawing.Point(20, 80);
            this.btnCalculate.Size = new System.Drawing.Size(100, 30);
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Click += new EventHandler(this.btnCalculate_Click);

            // Add controls to the form
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductPrice);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblFinalPrice);
            this.Controls.Add(this.btnCalculate);

            // Set properties of the form
            this.Text = "Discount Calculator";
            this.ClientSize = new System.Drawing.Size(300, 200);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text;
            decimal productPrice;

            if (decimal.TryParse(txtProductPrice.Text, out productPrice))
            {
                DiscountCalculator calculator = new DiscountCalculator();

                decimal discount = calculator.CalculateDiscount(productPrice);
                decimal finalPrice = productPrice - discount;

                lblDiscount.Text = $"ส่วนลด: {discount} บาท";
                lblFinalPrice.Text = $"ราคาหลังหักส่วนลด: {finalPrice} บาท";
            }
            else
            {
                MessageBox.Show("กรุณาป้อนราคาที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    class DiscountCalculator
    {
        public decimal CalculateDiscount(decimal totalAmount)
        {
            if (totalAmount < 500)
                return 0;
            else if (totalAmount >= 500 && totalAmount <= 2000)
                return totalAmount * 0.03m;
            else if (totalAmount >= 2001 && totalAmount <= 4000)
                return totalAmount * 0.05m;
            else if (totalAmount >= 4001 && totalAmount <= 6000)
                return totalAmount * 0.07m;
            else
                return totalAmount * 0.10m;
        }
    }
}
