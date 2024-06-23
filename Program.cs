using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StudentManager
{
    

    static void Menu()
    {
        try
        {
           bool condition = true;
           string choice;
            
          do
          {            
            Console.WriteLine("1. Display All Students");
            Console.WriteLine("2. Check if a student is enrolled by last name");
            Console.WriteLine("3. Display full student information by last name");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your choice: ");
            choice = (Console.ReadLine());

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Display All Students");
                    Display_All_Students();
                    break;
                case "2":
                    Console.Write("Enter the last name of student to check enrollment: ");
                    string lastNameToCheck = Console.ReadLine();
                    if (Enrolled_In_Class_By_LastName(lastNameToCheck)) { Console.WriteLine("The student is enrolled"); }
                    else { Console.WriteLine("The student is not enrolled"); }            
                    break;
                case "3":
                    Console.WriteLine("Display full student information by last name");
                    Console.Write("Enter the last name of student to display full information: ");
                    string lastNameToFind = Console.ReadLine();
                    int studentIndex = Find_Student_Id_By_LastName(lastNameToFind);
                    if (studentIndex != -1) { Display_Student_Information(studentIndex); }
                    else { Console.WriteLine("Student is not enrolled"); }
                    break;
                case "4":
                    Console.WriteLine("Exit");
                    condition = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
          }    while (condition);
        }
        catch
        {
            Console.WriteLine("Oooooops something going WRONG! Try again!");
        }
    }

    public static void Main(string[] args)
    {
        Menu();
    }




    static string[] firstNames = { "Alice", "Bob", "Charlie", "David", "Eva" };
    static string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown" };

    static string FullName(int studentIndex)
    {
        return $"{firstNames[studentIndex]} {lastNames[studentIndex]}";
    }

    static void Display_Student_Information(int studentIndex)
    {
        Console.WriteLine("Student Information");
        Console.WriteLine($"Student Id: {studentIndex}");
        Console.WriteLine($"Full Name: {FullName(studentIndex)}");
        Console.WriteLine($"First Name: {firstNames[studentIndex]}");
        Console.WriteLine($"Last Name: {lastNames[studentIndex]}");
        Console.WriteLine();
    }

    static void Display_All_Students()
    {
        for (int i = 0; i < firstNames.Length; i++)
        {
            Display_Student_Information(i);
        }
    }

    static bool Enrolled_In_Class_By_LastName(string studentsLastName)
    {
        studentsLastName = studentsLastName.ToLower();
        foreach (var lastName in lastNames)
        {
            if (lastName.ToLower() == studentsLastName)
            {
                return true;
            }
        }
        return false;
    }


    static int Find_Student_Id_By_LastName(string studentLastName)
    {
        studentLastName = studentLastName.ToLower();
        for (int i = 0; i < lastNames.Length; i++)
        {
            if (lastNames[i].ToLower() == studentLastName)
            {
                return i;
            }
        }
        return -1;
    }
}