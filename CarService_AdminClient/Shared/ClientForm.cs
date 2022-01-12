using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarService_Common.Models;

namespace CarService_AdminClient.Shared
{
    public partial class ClientForm
    {
        [Parameter]
        public string ButtonTitle { get; set; }

        [Parameter]
        public Client Client { get; set; }

        [Parameter]
        public Func<Task> SubmitForm { get; set; }
    }
}
