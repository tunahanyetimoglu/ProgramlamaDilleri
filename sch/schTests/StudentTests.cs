using Microsoft.VisualStudio.TestTools.UnitTesting;
using sch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sch.Tests
{
    [TestClass()]
    public class StudentTests
    {

        [TestMethod()]
        public void pathControllerTest()
        {
            Assert.AreEqual<Boolean>(true, Program.pathController("../../okul.csv"));
            Assert.AreEqual<Boolean>(false, Program.pathController("../okul.csv"));
        }

        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void uniqueTest()
        {
            sch.Student test = new Student();
            Assert.AreEqual<Boolean>(true, Student.csvUniqueName(test.Parse("../../okul.csv")));
            Assert.AreEqual<Boolean>(false, Student.csvUniqueName(test.Parse("../../okul_not_unique.csv")));
        }

        [TestMethod()]
        public void argumanControllerTest()
        {
            Assert.AreEqual<Boolean>(true, Student.argumanController("K"));
            Assert.AreEqual<Boolean>(false, Student.argumanController("erkek"));
        }

        [TestMethod()]
        public void argumanControllerErrorMessage()
        {
            string[] testArray = new string[] { "1", "K" };
            string[] testArray2 = new string[] { "5" };
            string[] testArray3 = new string[] { "erkek" };

            Assert.AreEqual<Boolean>(false, Student.argumanControllerErrorMessage(testArray));
            Assert.AreEqual<Boolean>(false, Student.argumanControllerErrorMessage(testArray2));
            Assert.AreEqual<Boolean>(false, Student.argumanControllerErrorMessage(testArray3));

        }
    }
    
}