using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleAp;
using SampleAp.Controllers;
using SampleAp.Data.Entities;
using SampleApCore.Interfaces;

namespace SampleAp.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTest
    {
        private readonly IContactUs contact;
        private readonly ICommon common;
        public ContactControllerTest()
        {
           
        }   
        
        public ContactControllerTest(IContactUs _contact, ICommon _common)
        {
            contact = _contact;
            common = _common;
        }    


        [TestMethod]
        public void CreateContact()
        {
            // Arrange Model
            var newentry = new Contact { FirstName = "TestFirst ", LastName = "TestLast", MasterDisplayAsId = 2, Knickname = "testentry", DateOfBirth = DateTime.Now.AddMonths(-24), PhoneNumber = "+91-1234567980" };

            // Act
            ContactController controller = new ContactController(contact, common);
            var resultdata = controller.CreateContact(newentry);
            // Assert
            Assert.IsNotNull(resultdata);
        }

        // Like above method we can have n number of test cases thus having different consequences

        
    }
}
