using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentTripExpenseCalculator;

namespace StudentTripExpensesCalculatorTestProject
{
    [TestClass]
    public class UnitTestStudentTripCalculator
    {
        [TestMethod]
        public void TotalStudentExpensesTest()
        {
            List<Student> students = Utils.GetStudents();

            decimal totalExpensesStudent1 = students[0].CalculateStudentTotalExpenses();
            decimal totalExpensesStudent2 = students[1].CalculateStudentTotalExpenses();
            decimal totalExpensesStudent3 = students[2].CalculateStudentTotalExpenses();

            //"Louis' total was $53.54, Carter's was $50.23, and David shelled out $113.41. "
            Assert.AreEqual(53.54M, totalExpensesStudent1);
            Assert.AreEqual(50.23M, totalExpensesStudent2);
            Assert.AreEqual(113.41M, totalExpensesStudent3);
        }

        [TestMethod]
        public void FairShareAmountTest()
        {
            List<Student> students = Utils.GetStudents();

            var fsc = new FairShareCalculator(students);
            decimal fairShare = fsc.CalculateFairShare();

            //"The total cost of the trip was thus $217.18, and thus equal shares would be $72.39 1/3 cents"
            Assert.AreEqual(72.39M, fairShare);
        }

        [TestMethod]
        public void StudentOwed()
        {
            List<Student> students = Utils.GetStudents();

            var fsc = new FairShareCalculator(students);
            decimal fairShare = fsc.CalculateFairShare();

            Student owedStudent = fsc.CalculateStudentOwed();

            //" Therefore, Louis owes David $18.85, and Carter owes David $22.16."
            // David is owed by the other students.
            Assert.AreEqual("David", owedStudent.Name);
        }

        [TestMethod]
        public void AmountEachOwesToStudent()
        {
            List<Student> students = Utils.GetStudents();

            var fsc = new FairShareCalculator(students);
            decimal fairShare = fsc.CalculateFairShare();

            decimal fairShareStudent1 = students[0].CalculateExpensesOweOrOwed(fairShare);
            decimal fairShareStudent2 = students[1].CalculateExpensesOweOrOwed(fairShare);
            decimal fairShareStudent3 = students[2].CalculateExpensesOweOrOwed(fairShare);

            //" ...Louis owes David $18.85, and Carter owes David $22.16."
            Assert.AreEqual(18.85M, fairShareStudent1);
            Assert.AreEqual(22.16M, fairShareStudent2);
            Assert.AreEqual(0.00M, fairShareStudent3);

        }
    }
}
