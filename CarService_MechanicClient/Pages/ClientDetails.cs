using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarService_Common.Models;

namespace CarService_MechanicClient.Pages
{
    public partial class ClientDetails : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Client Client { get; set; }

        [Parameter]
        public string ClientID { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Client = await HttpClient.GetFromJsonAsync<Client>($"client/{ClientID}");
            await base.OnInitializedAsync();
        }

        void NavigateBack()
        {
            NavigationManager.NavigateTo("clients");
        }

        private async Task SubmitForm()
        {
            await HttpClient.PutAsJsonAsync($"client/{ClientID}", Client);
            NavigationManager.NavigateTo("clients");
        }
    }
}
