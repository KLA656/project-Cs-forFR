// โจทย์ข้อ 4
// คำนวณค่าคอมมิชชั่นจากยอดขาย

// โครงสร้างของโปรแกรม:

// สร้างคลาส Sales ที่มีคุณสมบัติสำหรับยอดขาย
// สร้างคลาส CommissionCalculator สำหรับคำนวณค่าคอมมิชชั่น

using System;

class Sales
{
    public decimal SalesAmount { get; set; }
}

class CommissionCalculator
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

class Program
{
    static void Main()
    {
        Sales sales = new Sales { SalesAmount = 12000m };
        CommissionCalculator calculator = new CommissionCalculator();

        decimal commission = calculator.CalculateCommission(sales.SalesAmount);

        Console.WriteLine($"ยอดขาย: {sales.SalesAmount} บาท");
        Console.WriteLine($"ค่าคอมมิชชั่น: {commission} บาท");
    }
}
