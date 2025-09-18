using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using UnitTestingLib;

namespace UnitTestingComponent
{
    [TestClass]
    public class NotificationTest
    {
        [TestMethod]
        public void ShallSendNotificationMock()
        {
            //Arrange
            var mockNotificationService = new Mock<UnitTestingLib.INotificationService>();
            //Create 
            mockNotificationService.Setup(service => service.SendNotification(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            //Setup the mock to return true when SendNotification is called with any string parameters
            var notificationComponent = new UnitTestingLib.NotificationService(mockNotificationService.Object); //Get the mock obj using the Object property
            var deviceInfo = "Device123";
            var message = "This is test Notification";

            //Act
            notificationComponent.NotifyUser(deviceInfo, message);
            //Assert
            mockNotificationService.Verify(service => service.SendNotification(deviceInfo, message), Times.Once);
        }
        //Use Moq to create a mock implementation of the INotificationService interface.
        [TestMethod]
        public void ShallSendNotification()
        {   // Arrange
            var mockNotificationService = new Mock<INotificationService>();
            mockNotificationService.Setup(service => service.SendNotification(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var notificationService = new NotificationService(mockNotificationService.Object);
            string deviceInfo = "Device123";
            string message = "Test Notification";
            // Act
            bool result = notificationService.NotifyUser(deviceInfo, message);
            // Assert
            Assert.IsTrue(result);
            mockNotificationService.Verify(service => service.SendNotification(deviceInfo, message), Times.Once);
        }

    }
}
