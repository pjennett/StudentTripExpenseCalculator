using System;
using System.Collections.Generic;

namespace StudentTripExpenseCalculator
{
    public class Student
    {
        public decimal[] Expenses { get; private set; }
        public string Name { get; private set; }

        public Student(string studentName, decimal[] studentExpenses)
        {
            Name = studentName;
            Expenses = studentExpenses;
        }

        public decimal CalculateStudentTotalExpenses()
        {
            decimal total = 0;

            int numExpenses = Expenses.Length;
            for (int i = 0; i < numExpenses; i++)
            {
                total = total + Expenses[i];
            }

            return total;
        }

        public decimal CalculateExpensesOweOrOwed(decimal fairShareAmount)
        {
            decimal totalExp = CalculateStudentTotalExpenses();
            if (totalExp > fairShareAmount)
            {
                return 0.00M;
            }
            else
            {
                return fairShareAmount - totalExp;
            }

        }
    }
}
