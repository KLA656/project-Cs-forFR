using System;
using System.Windows.Forms;

namespace ProductCostCalculatorApp
{
    public partial class Form1 : Form
    {
        private ComboBox productTypeComboBox;
        private TextBox costPriceTextBox;
        private TextBox stockQuantityTextBox;
        private Button calculateButton;
        private Label resultLabel;
        private Label productTypeLabel;
        private Label costPriceLabel;
        private Label stockQuantityLabel;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.productTypeComboBox = new ComboBox();
            this.costPriceTextBox = new TextBox();
            this.stockQuantityTextBox = new TextBox();
            this.calculateButton = new Button();
            this.resultLabel = new Label();
            this.productTypeLabel = new Label();
            this.costPriceLabel = new Label();
            this.stockQuantityLabel = new Label();

            // 
            // productTypeComboBox
            // 
            this.productTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.productTypeComboBox.Items.AddRange(new object[] {
            "1 = เกรด A",
            "2 = เกรด B",
            "3 = เกรด C"});
            this.productTypeComboBox.Location = new System.Drawing.Point(120, 12);
            this.productTypeComboBox.Name = "productTypeComboBox";
            this.productTypeComboBox.Size = new System.Drawing.Size(100, 21);
            this.productTypeComboBox.TabIndex = 0;

            // 
            // costPriceTextBox
            // 
            this.costPriceTextBox.Location = new System.Drawing.Point(120, 39);
            this.costPriceTextBox.Name = "costPriceTextBox";
            this.costPriceTextBox.Size = new System.Drawing.Size(100, 20);
            this.costPriceTextBox.TabIndex = 1;

            // 
            // stockQuantityTextBox
            // 
            this.stockQuantityTextBox.Location = new System.Drawing.Point(120, 65);
            this.stockQuantityTextBox.Name = "stockQuantityTextBox";
            this.stockQuantityTextBox.Size = new System.Drawing.Size(100, 20);
            this.stockQuantityTextBox.TabIndex = 2;

            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(12, 91);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 3;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new EventHandler(this.calculateButton_Click);

            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(12, 117);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(260, 100);
            this.resultLabel.TabIndex = 4;

            // 
            // productTypeLabel
            // 
            this.productTypeLabel.Location = new System.Drawing.Point(12, 15);
            this.productTypeLabel.Name = "productTypeLabel";
            this.productTypeLabel.Size = new System.Drawing.Size(100, 20);
            this.productTypeLabel.Text = "Product Type:";

            // 
            // costPriceLabel
            // 
            this.costPriceLabel.Location = new System.Drawing.Point(12, 42);
            this.costPriceLabel.Name = "costPriceLabel";
            this.costPriceLabel.Size = new System.Drawing.Size(100, 20);
            this.costPriceLabel.Text = "Cost Price:";

            // 
            // stockQuantityLabel
            // 
            this.stockQuantityLabel.Location = new System.Drawing.Point(12, 68);
            this.stockQuantityLabel.Name = "stockQuantityLabel";
            this.stockQuantityLabel.Size = new System.Drawing.Size(100, 20);
            this.stockQuantityLabel.Text = "Stock Quantity:";

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 229);
            this.Controls.Add(this.productTypeLabel);
            this.Controls.Add(this.costPriceLabel);
            this.Controls.Add(this.stockQuantityLabel);
            this.Controls.Add(this.productTypeComboBox);
            this.Controls.Add(this.costPriceTextBox);
            this.Controls.Add(this.stockQuantityTextBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.resultLabel);
            this.Name = "Form1";
            this.Text = "Product Cost Calculator";
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (productTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("กรุณาเลือกประเภทสินค้า");
                return;
            }

            int productType = productTypeComboBox.SelectedIndex + 1;
            decimal costPrice;
            int stockQuantity;

            // Validate inputs
            if (!decimal.TryParse(costPriceTextBox.Text, out costPrice))
            {
                MessageBox.Show("ราคาต้นทุนสินค้าผิดพลาด");
                return;
            }
            if (!int.TryParse(stockQuantityTextBox.Text, out stockQuantity))
            {
                MessageBox.Show("จำนวนสินค้าที่เหลือผิดพลาด");
                return;
            }

            decimal sellingPrice = 0;
            string productGrade = "";

            // Calculate selling price based on product type
            if (productType == 1)
            {
                productGrade = "สินค้าเกรด A";
                sellingPrice = costPrice * 1.40m; // 40% profit
            }
            else if (productType == 2)
            {
                productGrade = "สินค้าเกรด B";
                sellingPrice = costPrice * 1.30m; // 30% profit
            }
            else if (productType == 3)
            {
                productGrade = "สินค้าเกรด C";
                sellingPrice = costPrice * 1.20m; // 20% profit
            }
            else
            {
                MessageBox.Show("ประเภทสินค้าที่เลือกไม่ถูกต้อง");
                return;
            }

            // Display results
            resultLabel.Text = $"{productGrade}\n" +
                               $"ราคาขายสินค้าคือ: {sellingPrice} บาท\n";

            // Check stock quantity
            if (stockQuantity <= 10)
            {
                resultLabel.Text += "ซื้อสินค้าเพิ่ม (Add to Cart)";
            }
            else
            {
                resultLabel.Text += "สินค้าเพียงพอ (Enough goods)";
            }
        }
    }
}
