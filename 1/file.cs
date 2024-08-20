// โจทย์ข้อ 1
// ให้เขียนโปรแกรมเพื่อคำนวณส่วนลดราคาสินค้าตามเงื่อนไขที่กำหนด

// โครงสร้างของโปรแกรม:

// สร้างคลาส Product ที่มีคุณสมบัติสำหรับชื่อสินค้าและราคา
// สร้างคลาส DiscountCalculator สำหรับคำนวณส่วนลด
// ใช้เงื่อนไข if..else ในการคำนวณส่วนลดตามยอดซื้อ

using System;

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
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

class Program
{
    static void Main()
    {
        Product product = new Product { Name = "สินค้า A", Price = 2500m };
        DiscountCalculator calculator = new DiscountCalculator();

        decimal discount = calculator.CalculateDiscount(product.Price);
        decimal finalPrice = product.Price - discount;

        Console.WriteLine($"สินค้าชื่อ: {product.Name}");
        Console.WriteLine($"ราคาปกติ: {product.Price} บาท");
        Console.WriteLine($"ส่วนลด: {discount} บาท");
        Console.WriteLine($"ราคาหลังหักส่วนลด: {finalPrice} บาท");
    }
}