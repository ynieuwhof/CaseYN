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
    public class ExtractDatumTests
    {
        ExtractDatum extractDatum = new ExtractDatum();

        [TestMethod]
        public void ShouldExtractDatum()
        {
            DateTime result = extractDatum.ValidateDatum("Startdatum: 3/04/2010");
            Assert.AreEqual(result, new DateTime(2010, 4, 3));
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWhenNotEnoughCharacters()
        {
            extractDatum.ValidateDatum("tekort");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWhenNoDatum()
        {
            extractDatum.ValidateDatum("iets heel anders");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ShouldThrowExceptionWhenDatumIsWrongFormat()
        {
            extractDatum.ValidateDatum("Startdatum: 01-02-2020");
        }

    }
}
