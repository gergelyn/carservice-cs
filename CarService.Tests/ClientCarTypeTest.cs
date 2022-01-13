using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarService_Common.Models;

namespace CarService.Tests
{
    [TestClass]
    public class ClientCarTypeTest
    {
        [DataRow("BMW")]
        [DataRow("Audi")]
        [DataRow("Mercedes-Benz")]
        [DataRow("Aston Martin")]
        [DataTestMethod]
        public void Client_WithValidCarType(string carType)
        {
            Client testClient = new Client
            {
                FirstName = "John",
                LastName = "Doe",
                CarType = carType,
                LicensePlate = "ABC-123",
                Issue = "Problem",
                Progress = "Accepted"
            };

            var errors = ValidateModel(testClient);
            Assert.IsTrue(errors.Count == 0);
        }

        [DataRow("audi")]
        [DataRow("aston martin")]
        [DataRow("aston Martin")]
        [DataRow("Aston martin")]
        [DataRow("Mercedes-benz")]
        [DataRow("mercedes-benz")]
        [DataRow("mercedes-Benz")]
        [DataRow("Mercedes -Benz")]
        [DataRow("Mercedes- Benz")]
        [DataRow("Audi ")]
        [DataRow("Mercedes -")]
        [DataRow("Mercedes-")]
        [DataRow("Mercedes- ")]
        [DataRow("")]
        [DataRow(" ")]
        [DataTestMethod]
        public void Client_WithInvalidCarType(string carType)
        {
            Client testClient = new Client
            {
                FirstName = "John",
                LastName = "Doe",
                CarType = carType,
                LicensePlate = "ABC-123",
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
