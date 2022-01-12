using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarService_Common.Models;

namespace CarService.Tests
{
    [TestClass]
    public class ClientNameTest
    {
        [DataRow("Anna")]
        [DataRow("János")]
        [DataRow("László")]
        [DataTestMethod]
        public void Client_WithValidFirstName(string firstName)
        {
            Client testClient = new Client
            {
                FirstName = firstName,
                LastName = "Doe",
                CarType = "BMW",
                LicensePlate = "ABC-123",
                Issue = "Problem",
                Progress = "Accepted"
            };

            var errors = ValidateModel(testClient);
            Assert.IsTrue(errors.Count == 0);
        }

        [DataRow("Vezetéknév")]
        [DataTestMethod]
        public void Client_WithValidLastName(string lastName)
        {
            Client testClient = new Client
            {
                FirstName = "John",
                LastName = lastName,
                CarType = "BMW",
                LicensePlate = "ABC-123",
                Issue = "Problem",
                Progress = "Accepted"
            };

            var errors = ValidateModel(testClient);
            Assert.IsTrue(errors.Count == 0);
        }

        [DataRow("")]
        [DataRow(" ")]
        [DataRow(" Keresztnév")]
        [DataRow("Keresztnév ")]
        [DataRow("K3r3$ztn3v!.")]
        [DataTestMethod]
        public void Client_WithInvalidFirstName(string firstName)
        {
            Client testClient = new Client
            {
                FirstName = firstName,
                LastName = "Doe",
                CarType = "BMW",
                LicensePlate = "ABC-123",
                Issue = "Problem",
                Progress = "Accepted"
            };

            var errors = ValidateModel(testClient);
            Assert.IsTrue(errors.Count > 0);
        }

        [DataRow("")]
        [DataRow(" ")]
        [DataRow(" Vezetéknév")]
        [DataRow("Vezetéknév ")]
        [DataRow("V3z3t3kn3v$!.")]
        [DataTestMethod]
        public void Client_WithInvalidLastName(string lastName)
        {
            Client testClient = new Client
            {
                FirstName = "John",
                LastName = lastName,
                CarType = "BMW",
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
