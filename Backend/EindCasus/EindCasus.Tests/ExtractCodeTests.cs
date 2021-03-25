using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EindCasus.Interfaces;
using EindCasus.Services.ExtractValueServices;
using System.ComponentModel.DataAnnotations;

namespace EindCasus.Tests
{
    [TestClass]
    public class ExtractCodeTests
    {
        ExtractCode extractCode = new();

        [TestMethod]
        public void ShouldExtractCode()
        {
            string result = extractCode.ValidateCode("Cursuscode: test");
            Assert.AreEqual(result, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWhenNotEnoughCharacters()
        {
            extractCode.ValidateCode("Cursuscod");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWhenNoCursusCode()
        {
            extractCode.ValidateCode("iets heel anders");
        }

    }
}
