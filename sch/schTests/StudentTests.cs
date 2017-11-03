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
        }

        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void uniqueTest()
        {
            sch.Student test = new Student();
            Assert.AreEqual<Boolean>(true, Student.csvUniqueName(test.Parse("../../okul.csv")));           
        }

        [TestMethod()]
        public void argumanControllerTest()
        {
            Assert.AreEqual<Boolean>(true, Program.argumanController("K"));
        }

        [TestMethod()]
        public void pathControllerTest2()
        {
            Assert.AreEqual<Boolean>(true, Program.pathController("../okul.csv"));
        }

        [TestMethod()]
        public void argumanControllerTest2()
        {
            Assert.AreEqual<Boolean>(true, Program.argumanController("erkek"));
        }

        [TestMethod()]
        public void uniqueTest2()
        {
            sch.Student test = new Student();
            Assert.AreEqual<Boolean>(true, Student.csvUniqueName(test.Parse("../okul.csv")));
        }
    }
    
}
