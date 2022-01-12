using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CarService_AdminClient.Data;

namespace CarService_AdminClient.Pages
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

        private async Task DeleteClient()
        {
            await HttpClient.DeleteAsync($"client/{ClientID}");
            NavigationManager.NavigateTo("clients");
        }
    }
}
