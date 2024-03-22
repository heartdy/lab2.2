using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        Console.WriteLine("กรุณากรอกข้อมูลนักศึกษา (ใส่ -1 เพื่อหยุด)");

        while (true)
        {
            Console.Write("รหัสนักศึกษา: ");
            string studentID = Console.ReadLine();

            if (studentID == "-1")
                break;

            Console.Write("ชื่อ-นามสกุล: ");
            string name = Console.ReadLine();

            Console.Write("คะแนน: ");
            double score = Convert.ToDouble(Console.ReadLine());

            students.Add(new Student(studentID, name, score));
        }

        if (students.Count > 0)
        {
            double maxScore = students.Max(student => student.Score);
            double minScore = students.Min(student => student.Score);
            double averageScore = students.Average(student => student.Score);

            Console.WriteLine($"คะแนนสูงสุด: {maxScore}");
            Console.WriteLine($"คะแนนต่ำสุด: {minScore}");
            Console.WriteLine($"คะแนนเฉลี่ย: {averageScore}");

            Console.WriteLine("ข้อมูลนักศึกษาทั้งหมด:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.StudentID} - {student.Name} - {student.Score} - เกรด: {GetGrade(student.Score)}");
            }

            int nA = students.Count(student => GetGrade(student.Score) == "A");
            int nBplus = students.Count(student => GetGrade(student.Score) == "B+");
            int nB = students.Count(student => GetGrade(student.Score) == "B");
            int nCplus = students.Count(student => GetGrade(student.Score) == "C+");
            int nC = students.Count(student => GetGrade(student.Score) == "C");
            int nDplus = students.Count(student => GetGrade(student.Score) == "D+");
            int nD = students.Count(student => GetGrade(student.Score) == "D");

            double gpa = (nA * 4.0 + nBplus * 3.5 + nB * 3.0 + nCplus * 2.5 + nC * 2.0 + nDplus * 1.5 + nD * 1.0) / students.Count;

            Console.WriteLine($"GPA ทั้งหมด: {gpa}");
        }
        else
        {
            Console.WriteLine("ไม่มีข้อมูลนักศึกษา");
        }
    }

    static string GetGrade(double score)
    {
        if (score >= 80) return "A";
        if (score >= 75) return "B+";
        if (score >= 70) return "B";
        if (score >= 65) return "C+";
        if (score >= 60) return "C";
        if (score >= 55) return "D+";
        if (score >= 50) return "D";
        return "F";
    }
}

class Student
{
    public string StudentID { get; }
    public string Name { get; }
    public double Score { get; }

    public Student(string studentID, string name, double score)
    {
        StudentID = studentID;
        Name = name;
        Score = score;
    }
}
