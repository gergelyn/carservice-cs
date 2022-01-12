using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarService_Common.Models;

namespace CarService_AdminClient.Pages
{
    public partial class ClientList : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Client[] Clients { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Clients = await HttpClient.GetFromJsonAsync<Client[]>("client");
            await base.OnInitializedAsync();
        }
    }
}
