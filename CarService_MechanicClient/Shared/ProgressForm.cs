using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarService_Common.Models;

namespace CarService_MechanicClient.Shared
{
    public partial class ProgressForm
    {
        [Parameter]
        public Client Client { get; set; }

        [Parameter]
        public Func<Task> SubmitForm { get; set; }
    }
}
