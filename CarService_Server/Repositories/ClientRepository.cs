using System.Collections.Generic;
using System.Linq;
using CarService_Server.Models;

namespace CarService_Server.Repositories
{
    public class ClientRepository
    {
        public static IList<Client> GetClients()
        {
            using (var database = new ClientContext())
            {
                var clients = database.Clients.ToList();

                return clients;
            }
        }

        public static Client GetClient(long id)
        {
            using (var database = new ClientContext())
            {
                var client = database.Clients.Where(c => c.Id == id).FirstOrDefault();

                return client;
            }
        }
    }
}
