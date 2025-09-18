using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingLib;
using static UnitTestingLib.ContactService;

namespace UnitTestingComponent
{
    [TestClass]
    public class ContactServiceTest
    {
        [TestMethod]
        public void ShallReturnContactById()
        {
            // Arrange
            var mockRepo = new Mock<IContactRepository>();
            var expectedContact = new Contact { Id = 1, Name = "Aditya" };

            mockRepo.Setup(repo => repo.GetContactById(1)).Returns(expectedContact);
            var service = new ContactService(mockRepo.Object);

            // Act
            var result = service.GetContact(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Aditya", result.Name);
            mockRepo.Verify(repo => repo.GetContactById(1), Times.Once);
        }

        [TestMethod]
        public void ShallAddContact()
        {
            // Arrange
            var mockRepo = new Mock<IContactRepository>();
            var newContact = new Contact { Id = 2, Name = "Niranjan" };
            var service = new ContactService(mockRepo.Object);

            // Act
            service.CreateContact(newContact);

            // Assert
            mockRepo.Verify(repo => repo.AddContact(newContact), Times.Once);
        }
    }
}

