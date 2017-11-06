using Microsoft.VisualStudio.TestTools.UnitTesting;
using sch;
using System;
using System.Collections.Generic;
using System.IO;
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
            Assert.AreEqual<Boolean>(true, File.Exists("../../okul.csv"));
            Assert.AreEqual<Boolean>(false, File.Exists("okul.csv"));
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
            Assert.AreEqual<Boolean>(true, Student.argumentController("K"));
            Assert.AreEqual<Boolean>(true, Student.argumentController("k"));
            Assert.AreEqual<Boolean>(true, Student.argumentController("E"));
            Assert.AreEqual<Boolean>(true, Student.argumentController("e"));
            Assert.AreEqual<Boolean>(true, Student.argumentController("1"));
            Assert.AreEqual<Boolean>(true, Student.argumentController("2"));
            Assert.AreEqual<Boolean>(true, Student.argumentController("3"));
            Assert.AreEqual<Boolean>(true, Student.argumentController("4"));
            Assert.AreEqual<Boolean>(false, Student.argumentController("q"));
        }
        [TestMethod()]
        public void argumanLengthControl()
        {
            string[] testArray = new string[] { "1", "K" };
            Assert.AreEqual<Boolean>(false, Program.argsLengthControl(testArray));
        }
        [TestMethod()]
        public void argumanControllerErrorMessage()
        {
            Assert.AreEqual<String>("Devre Hatası", Student.argumentControllerErrorMessage("5"));
            Assert.AreEqual<String>("Arguman Hatası", Student.argumentControllerErrorMessage("erkek"));
        }
    }
    
}