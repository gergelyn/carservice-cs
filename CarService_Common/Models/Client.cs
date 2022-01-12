using System;
using System.ComponentModel.DataAnnotations;
using CarService_Common.Models.CustomValidators;

namespace CarService_Common.Models
{
    public class Client
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(25)]
        [Name(ErrorMessage = "Name must not contain special characters or whitespaces!")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [Name(ErrorMessage = "Name must not contain special characters or whitespaces!")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [CarType(ErrorMessage = "The given format is invalid for car type!")]
        public string CarType { get; set; }

        [Required]
        [MaxLength(7)]
        [LicensePlate(ErrorMessage = "License plate must be in XXX-000 format!")]
        public string LicensePlate { get; set; }

        [Required]
        public string Issue { get; set; }

        [Required]
        public string Progress { get; set; }
    }
}
