// โจทย์ข้อ 2
// ให้เขียนโปรแกรมคำนวณเกรดนักศึกษา

// โครงสร้างของโปรแกรม:

// สร้างคลาส Student สำหรับเก็บข้อมูลนักศึกษา
// สร้างคลาส GradeCalculator สำหรับคำนวณเกรดตามคะแนนที่ได้

using System;

class Student
{
    public string Name { get; set; }
    public int Score { get; set; }
}

class GradeCalculator
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

class Program
{
    static void Main()
    {
        Student student = new Student { Name = "นางสาว A", Score = 72 };
        GradeCalculator calculator = new GradeCalculator();

        string grade = calculator.CalculateGrade(student.Score);

        Console.WriteLine($"ชื่อนักศึกษา: {student.Name}");
        Console.WriteLine($"คะแนน: {student.Score}");
        Console.WriteLine($"เกรดที่ได้: {grade}");
    }
}
