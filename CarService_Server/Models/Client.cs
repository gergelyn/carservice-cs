using System;
using System.ComponentModel.DataAnnotations;

namespace CarService_Server.Models
{
    public class Client
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string CarType { get; set; }
        [Required]
        [MaxLength(7)]
        public string LicensePlate { get; set; }
        [Required]
        public string Issue { get; set; }
        [Required]
        public string Progress { get; set; }
    }
}
