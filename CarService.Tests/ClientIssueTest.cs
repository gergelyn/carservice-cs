using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarService_Common.Models;

namespace CarService.Tests
{
    [TestClass]
    public class ClientIssueTest
    {

        [DataRow("Problem")]
        [DataTestMethod]
        public void Client_WithValidIssue(string problem)
        {
            Client testClient = new Client
            {
                FirstName = "John",
                LastName = "Doe",
                CarType = "BMW",
                LicensePlate = "ABC-123",
                Issue = problem,
                Progress = "Accepted"
            };

            var errors = ValidateModel(testClient);
            Assert.IsTrue(errors.Count == 0);
        }

        [DataRow("")]
        [DataRow(" ")]
        [DataTestMethod]
        public void Client_WithInvalidIssue(string problem)
        {
            Client testClient = new Client
            {
                FirstName = "John",
                LastName = "Doe",
                CarType = "BMW",
                LicensePlate = "ABC-123",
                Issue = problem,
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
