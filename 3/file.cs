// โจทย์ข้อ 3
// คำนวณค่าแรงและค่าล่วงเวลาสำหรับพนักงาน

// โครงสร้างของโปรแกรม:

// สร้างคลาส Employee ที่มีคุณสมบัติสำหรับชื่อพนักงาน, จำนวนชั่วโมงทำงาน, และอัตราค่าจ้าง
// สร้างคลาส WageCalculator สำหรับคำนวณค่าแรง

using System;

class Employee
{
    public string Name { get; set; }
    public int HoursWorked { get; set; }
    public decimal HourlyRate { get; set; }
}

class WageCalculator
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

class Program
{
    static void Main()
    {
        Employee employee = new Employee { Name = "นาย B", HoursWorked = 10, HourlyRate = 100m };
        WageCalculator calculator = new WageCalculator();

        decimal wages = calculator.CalculateWages(employee.HoursWorked, employee.HourlyRate);

        Console.WriteLine($"ชื่อพนักงาน: {employee.Name}");
        Console.WriteLine($"จำนวนชั่วโมงทำงาน: {employee.HoursWorked}");
        Console.WriteLine($"ค่าแรงที่ได้รับ: {wages} บาท");
    }
}
