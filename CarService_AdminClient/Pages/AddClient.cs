using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using CarService_AdminClient.Data;

namespace CarService_AdminClient.Pages
{
    public partial class AddClient
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Client Client { get; set; } = new Client();

        private async Task SubmitForm()
        {
            await HttpClient.PostAsJsonAsync("client", Client);
            NavigationManager.NavigateTo("clients");
        }
    }
}
