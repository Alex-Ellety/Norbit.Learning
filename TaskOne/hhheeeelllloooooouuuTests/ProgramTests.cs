using Microsoft.VisualStudio.TestTools.UnitTesting;
using hhheeeelllloooooouuu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hhheeeelllloooooouuu.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [DataRow("hhheeelllooouu", "hello", true)]
        [DataRow("hleleo", "hello", false)]
        [DataRow("ffflaaggelllllattiooneee", "flagelation", true)]
        [DataRow("fglglataionlg", "flagelation", false)]
        [TestMethod()]
        public void HasWord_CorrectParameters_Success(string value, string targetWord, bool expectedResult)
        {
            var actualResult = Program.HasWord(value, targetWord);

            Assert.AreEqual(expectedResult, actualResult, "слова не совпадают");
        }

        [DataRow("", "flagelation", true)]
        [DataRow("hleleo", "", false)]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void HasWord_InvalidParameters_ThrowsException(string value, string targetWord, bool expectedResult)
        {
            var actualResult = Program.HasWord(value, targetWord);

            Assert.Fail("Не выброшено исключение валидации");
        }

        [DataRow("", "")]
        [DataRow("", "")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void CheckValueGreaterThanTest()
        {
            Assert.Fail("");
        }
    }
}