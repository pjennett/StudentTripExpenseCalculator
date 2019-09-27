using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTripExpenseCalculator
{
    public class FairShareCalculator
    {
        private List<Student> students;

        public FairShareCalculator(List<Student> students)
        {
            this.students = students;
        }

        public decimal CalculateFairShare()
        {
            decimal fairShare = 0.00M;
            int numStudents = students.Count;
            decimal sumExpenses = 0.00M;

            for (int i = 0; i < numStudents; i++)
            {
                sumExpenses = sumExpenses + students[i].CalculateStudentTotalExpenses();
            }

            fairShare = sumExpenses / numStudents;
            fairShare = Math.Truncate(fairShare * 100) / 100;
            return fairShare;
        }

        public Student CalculateStudentOwed()
        {
            //Assumptions 
            // - only one student paid more than fair share
            // - at least one student paid more than fair share
            //What this means - 
            //  If more than one student is owed money, only the student who paid the most will
            //  be paid back. Other students will neither owe or be owed.
            Student owedStudent = new Student("DummyStudent", new decimal[] { 0.01M }); //adding dummy - q&d design choice here to make compiler happy
            int numStudents = students.Count;
            decimal fairShare = CalculateFairShare();
            decimal maxTotalExp = 0.0M;

            foreach (Student student in students)
            {
                // This finds first student owed money
                //  which is how I read the bounds of the problem.
                //if (student.CalculateStudentTotalExpenses() > fairShare)
                //{
                //    owedStudent = student;
                //    break;
                //}
                // This finds student who paid the most (if more than one paid greater than fair share)
                //  which extends the bounds of the problem a little
                decimal studentTotalExp = student.CalculateStudentTotalExpenses();
                if (studentTotalExp > fairShare && studentTotalExp > maxTotalExp)
                {
                    owedStudent = student;
                    maxTotalExp = studentTotalExp;
                }

            }
            return owedStudent;
        }
    }
}
