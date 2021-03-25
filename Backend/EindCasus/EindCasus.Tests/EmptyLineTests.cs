using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EindCasus.Services.ExtractValueServices;
using System.ComponentModel.DataAnnotations;

namespace EindCasus.Tests
{
    [TestClass]
    public class EmptyLineTests
    {
        EmptyLineValidator emptyLineValidator = new EmptyLineValidator();


        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWhenNoEmptyLine()
        {
            emptyLineValidator.CheckForEmptyLine("Hier staat gewoon iets");
        }

        [TestMethod]
        public void ShouldNotThrowExceptionWhenEmptyLine()
        {
            string result = emptyLineValidator.CheckForEmptyLine("");
            Assert.AreEqual(result, "Ok");
        }
    }
}
