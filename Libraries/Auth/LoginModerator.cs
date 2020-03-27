using LojaVirtual.Libraries.Session;
using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Auth
{
    public class LoginModerator
    {
        private Session.Session _session;
        private static string Key = "LoginModerator";
        public LoginModerator(Session.Session session)
        {
            _session = session;
        }
        
        public void Login(Moderator moderator)
        {
            // serializar
            string json = JsonConvert.SerializeObject(moderator);
            _session.Create(Key, json);
        }

        public Moderator User()
        {
            if(_session.Exist(Key)){
                string moderator = _session.Search(Key);
                return JsonConvert.DeserializeObject<Moderator>(moderator);
            }
            return null;
        }

        public void Logout()
        {

        }

    }
}