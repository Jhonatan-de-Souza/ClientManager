using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web.Mvc;
using ClientManager.Controllers;
using ClientManager.Core;
using ClientManager.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ClientManager.Tests.Controllers
{
    [TestFixture]
    public class PersonControllerTest
    {
        private PersonController _personController;

        public PersonControllerTest()
        {


            /* Creating the mock unit of work to be used by the controller */
            var mockUoW = new Mock<IUnitOfWork>();
            /* Passing the unit of work to the controller */
            _personController = new PersonController(mockUoW.Object);
            /* Setting the current user property of the instantiated controller  */
            _personController.MockCurrentUser("1", "rafael@hotmail.com");



        }

        [Test]
        public void CreateAction_ReturnsNotNullView()
        {
            //var _MockUoW = new Mock<IUnitOfWork>();
            //// Arrange
            //PersonController controller = new PersonController(_MockUoW.Object);
            //var testDate = _MockUoW.Setup(uow => uow.People.GetAll());

            // Act
            //ViewResult result = controller.Create() as ViewResult;

            // Assert
            //Assert.That(result, Is.Not.Null);

        }

        [TestMethod]
        public void What_Condition_Results()
        {

        }


    }
}
