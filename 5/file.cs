// คุณสามารถเขียนโปรแกรม C# เพื่อคำนวณหาต้นทุนสินค้าตามที่โจทย์กำหนดได้ โดยใช้คำสั่ง If...Else If...Else เพื่อกำหนดเงื่อนไขในการคิดต้นทุนและตรวจสอบจำนวนสินค้าที่เหลืออยู่ตามรายละเอียดที่ให้มา

using System;

class Program
{
    static void Main()
    {
        // รับข้อมูลจากผู้ใช้
        Console.Write("กรุณาป้อนประเภทสินค้า (1 = เกรด A, 2 = เกรด B, 3 = เกรด C): ");
        int productType = int.Parse(Console.ReadLine());

        Console.Write("กรุณาป้อนราคาต้นทุนสินค้า: ");
        decimal costPrice = decimal.Parse(Console.ReadLine());

        Console.Write("กรุณาป้อนจำนวนสินค้าที่เหลือ: ");
        int stockQuantity = int.Parse(Console.ReadLine());

        decimal sellingPrice = 0;
        string productGrade = "";

        // คำนวณราคาขายตามประเภทสินค้า
        if (productType == 1)
        {
            productGrade = "สินค้าเกรด A";
            sellingPrice = costPrice * 1.40m; // บวกกำไร 40%
        }
        else if (productType == 2)
        {
            productGrade = "สินค้าเกรด B";
            sellingPrice = costPrice * 1.30m; // บวกกำไร 30%
        }
        else if (productType == 3)
        {
            productGrade = "สินค้าเกรด C";
            sellingPrice = costPrice * 1.20m; // บวกกำไร 20%
        }
        else
        {
            Console.WriteLine("ประเภทสินค้าที่คุณป้อนไม่ถูกต้อง");
            return;
        }

        // แสดงข้อมูลสินค้าและราคาขาย
        Console.WriteLine(productGrade);
        Console.WriteLine($"ราคาขายสินค้าคือ: {sellingPrice} บาท");

        // ตรวจสอบจำนวนสินค้าที่เหลือและแสดงข้อความ
        if (stockQuantity <= 10)
        {
            Console.WriteLine("ซื้อสินค้าเพิ่ม (Add to Cart)");
        }
        else
        {
            Console.WriteLine("สินค้าเพียงพอ (Enough goods)");
        }
    }
}
