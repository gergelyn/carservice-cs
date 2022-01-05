using System;
namespace CarService_AdminClient.Data
{
    public class Client
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CarType { get; set; }

        public string LicensePlate { get; set; }

        public string Issue { get; set; }

        public string Progress { get; set; }
    }
}
