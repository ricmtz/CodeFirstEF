using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Classes;

namespace CodeFirstEF.Controllers
{
    class CtrlClient
    {
        private HitssTMContext entities;

        public CtrlClient()
        {
            entities = new HitssTMContext();
        }

        public bool CreateClient(string name, string descript="", int status=1)
        {
            var client = new Client()
            {
                Name = name,
                Description = descript,
                Status = status,
            };
            entities.Clients.Add(client);
            return entities.SaveChanges() > 0;
        }

        public List<Client> GetClients()
        {
            return entities.Clients
                .Where(c => c.Status != 0)
                .ToList();
        }

        public Client GetClientById(int id)
        {
            return entities.Clients.FirstOrDefault(c => c.Id == id && c.Status != 0);
        }

        public bool UpdateClient(Client client)
        {
            var oringClient = GetClientById(client.Id);
            if(oringClient != null)
            {
                oringClient.Name = client.Name;
                oringClient.Description = client.Description;
                oringClient.Status = client.Status;
                return entities.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteClient(int id)
        {
            var client = GetClientById(id);
            if(client != null)
            {
                client.Status = 0;
                return entities.SaveChanges() > 0;
            }
            return false;
        }
    }
}
