using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EindCasus.Interfaces;

namespace EindCasus.Tests
{
    [TestClass]
    public class ImportServiceTest
    {
        Mock<IImportCursusRepository> importRepositoryMock;
        Mock<ICursusRepository> cursusRepositoryMock;

        [TestInitialize]
        public void Init()
        {
            importRepositoryMock = new Mock<IImportCursusRepository>();
            cursusRepositoryMock = new Mock<ICursusRepository>();
        }

        //[TestMethod]

    }
}
