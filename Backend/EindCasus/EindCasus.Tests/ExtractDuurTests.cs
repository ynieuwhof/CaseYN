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
    public class ExtractDuurTests
    {
        ExtractDuur extractDuur = new ExtractDuur();

        [TestMethod]
        public void ShouldExtractDuur()
        {
            int result = extractDuur.ValidateDuur("Duur: 3 dagen");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWhenNotEnoughCharacters()
        {
            extractDuur.ValidateDuur("kort");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWhenNoDuur()
        {
            extractDuur.ValidateDuur("staat gewoon heel iets anders");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWhenNoDagen()
        {
            extractDuur.ValidateDuur("Duur: 2");
        }
    }
}
