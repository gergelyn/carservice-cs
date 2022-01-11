using System;
using CarService_AdminClient.Data.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace CarService_AdminClient.Data
{
    public class Client
    {
        public long Id { get; set; }

        [Required]
        [Name(ErrorMessage = "Name must not contain special characters or whitespaces!")]
        public string FirstName { get; set; }

        [Required]
        [Name(ErrorMessage = "Name must not contain special characters or whitespaces!")]
        public string LastName { get; set; }

        [Required]
        [CarType(ErrorMessage = "The given format is invalid for car type!")]
        public string CarType { get; set; }

        [Required]
        [LicensePlate(ErrorMessage = "License plate must be in XXX-000 format!")]
        public string LicensePlate { get; set; }

        [Required]
        public string Issue { get; set; }

        [Required]
        public string Progress { get; set; }
    }
}
