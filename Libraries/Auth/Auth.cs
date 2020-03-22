using LojaVirtual.Libraries.Session;
using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Auth
{
    public class Auth
    {
        private Session.Session _session;
        private static string Key = "Auth";
        public Auth(Session.Session session)
        {
            _session = session;
        }
        
        public void Login(Client client)
        {
            // serializar
            string json = JsonConvert.SerializeObject(client);
            _session.Create(Key, json);
        }

        public Client User()
        {
            string client = _session.Search(Key);
            return JsonConvert.DeserializeObject<Client>(client);
        }

        public void Logout()
        {

        }

    }
}