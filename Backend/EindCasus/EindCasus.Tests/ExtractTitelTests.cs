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
    public class ExtractTitelTests
    {
        ExtractTitel extractTitel = new ExtractTitel();

        [TestMethod]
        public void ShouldExtractTitel()
        {
            string result = extractTitel.ValidateTitel("Titel: eencursusnaam");
            Assert.AreEqual(result, "eencursusnaam");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWhenNotEnoughCharacters()
        {
            extractTitel.ValidateTitel("kort");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWhenNoTitel()
        {
            extractTitel.ValidateTitel("staat er gewoon niet");
        }
    }
}
