using System;
using System.Collections.Generic;

namespace StudentTripExpenseCalculator
{

/*
    The project goals are simple: We require a program that calculates the expenses 
    for a group of students who like to go on road trips.

    The group agrees in advance to share expenses equally, but it is not practical 
    to share every expense as it occurs. Thus individuals in the group pay for particular 
    things, such as meals, hotels, taxi rides, and plane tickets. After the trip, each 
    student's expenses are tallied and money is exchanged so that the net cost to each is 
    the same, to within one cent. In the past, this money exchange has been tedious and 
    time consuming. Your job is to compute, from a list of students and their personal 
    expenses from the trip, the minimum amount of money that must change hands in order to 
    equalize (within one cent) all the students' costs. 
 */

    class Program
    {

        static void Main(string[] args)
        {
            List<Student> students = Utils.GetStudents();
            FairShareCalculator fsc = new FairShareCalculator(students);
            decimal fairShare = fsc.CalculateFairShare();
            Student studentOwed = fsc.CalculateStudentOwed();

            foreach (Student student in students)
            {
                decimal amountOwed = student.CalculateExpensesOweOrOwed(fairShare);
                if (amountOwed > 0)
                {
                    Console.WriteLine(student.Name + " owes " + studentOwed.Name + " $" + amountOwed.ToString());
                }
            }

            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();
        }
    }

    public static class Utils
    {
        public static List<Student> GetStudents()
        {
            var student1 = new Student("Louis", new decimal[] { 5.75M, 35.00M, 12.79M });
            var student2 = new Student("Carter", new decimal[] { 12.00M, 15.00M, 23.23M });
            var student3 = new Student("David", new decimal[] { 10.00M, 20.00M, 38.41M, 45.00M });
            //var student4 = new Student("Sarah", new decimal[] { 10.00M, 20.00M, 8.41M, 25.00M });
            //var student5 = new Student("Kate", new decimal[] { 10.00M, 20.00M, 38.41M, 15.00M });

            var students = new List<Student> { student1, student2, student3 };
            //var students = new List<Student> { student1, student2, student3, student4 };
            //var students = new List<Student> { student1, student2, student3, student4, student5 };
            return students;
        }
    }
}