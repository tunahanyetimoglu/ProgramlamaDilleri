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
            Assert.AreEqual<Boolean>(false, Program.pathController("okul.csv"));
        }

        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void uniqueTest()
        {
            Assert.AreEqual<Boolean>(true, Student.csvUniqueName(Student.Parse("../../okul.csv")));
            Assert.AreEqual<Boolean>(false, Student.csvUniqueName(Student.Parse("../../okul_not_unique.csv")));
        }

        [TestMethod()]
        public void argumanControllerTest()
        {
            Assert.AreEqual<Boolean>(true, Student.argumanController("K"));
            Assert.AreEqual<Boolean>(false, Student.argumanController("q"));
        }
        [TestMethod()]
        public void argumanLenghtControl()
        {
            string[] testArray = new string[] { "1", "K" };
            Assert.AreEqual<Boolean>(false, Program.argsLengthControl(testArray));
        }
        [TestMethod()]
        public void argumanControllerErrorMessage()
        {
            Assert.AreEqual<String>("Devre Hatası", Student.argumanControllerErrorMessage("5"));
            Assert.AreEqual<String>("Arguman Hatası", Student.argumanControllerErrorMessage("erkek"));
        }
    }
    
}
