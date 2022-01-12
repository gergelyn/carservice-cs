using System;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarService_Common.Models;

namespace CarService.Tests
{
    [TestClass]
    public class ClientLicensePlateTest
    {
        
        [DataRow("AAA-000")]
        [DataRow("AAA-001")]
        [DataRow("AAA-011")]
        [DataRow("ABB-000")]
        [DataRow("ABB-001")]
        [DataRow("ABB-011")]
        [DataRow("ABC-000")]
        [DataRow("ABC-001")]
        [DataRow("ABC-011")]
        [DataTestMethod]
        public void Client_WithValidLicensePlate(string licensePlate)
        {
            Client testClient = new Client
            {
                FirstName = "John",
                LastName = "Doe",
                CarType = "BMW",
                LicensePlate = licensePlate,
                Issue = "Problem",
                Progress = "Accepted"
            };

            var errors = ValidateModel(testClient);
            Assert.IsTrue(errors.Count == 0);
        }

        [DataRow("AAA000")]
        [DataRow("ABCDE-0")]
        [DataRow("ABCD-00")]
        [DataRow("AB-0000")]
        [DataRow("A-00000")]
        [DataRow("ABB-0000")]
        [DataRow("")]
        [DataRow(" ")]
        [DataTestMethod]
        public void Client_WithInvalidLicensePlate(string licensePlate)
        {
            Client testClient = new Client
            {
                FirstName = "John",
                LastName = "Doe",
                CarType = "BMW",
                LicensePlate = licensePlate,
                Issue = "Problem",
                Progress = "Accepted"
            };

            var errors = ValidateModel(testClient);
            Assert.IsTrue(errors.Count > 0);
        }

        //http://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }

}
