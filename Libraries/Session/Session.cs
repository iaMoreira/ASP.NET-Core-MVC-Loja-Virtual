using System.Runtime.CompilerServices;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace LojaVirtual.Libraries.Session
{
    public class Session
    {
        private IHttpContextAccessor _context;
        public Session(IHttpContextAccessor context)
        {
            _context = context;
        }
        public void Create(string Key, string Value)
        {
            _context.HttpContext.Session.SetString(Key, Value);
        }

        public void Update(string Key, string Value)
        {
            if(this.Exist(Key)){
                this.Destroy(Key);
            }
            _context.HttpContext.Session.SetString(Key, Value);
        }

        public void Destroy(string Key)
        {
            _context.HttpContext.Session.Remove(Key);
        }

        public string Search(string Key)
        {
            return _context.HttpContext.Session.GetString(Key);

        }

        public bool Exist(string Key)
        {
            if(_context.HttpContext.Session.GetString(Key) == null){
                return false;
            }
            return true;
        }
        
        public void RemoveAll()
        {
            _context.HttpContext.Session.Clear();
        }
    }
}