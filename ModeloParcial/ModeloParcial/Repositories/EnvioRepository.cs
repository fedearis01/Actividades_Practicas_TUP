using ModeloParcial.Models;
using Microsoft.EntityFrameworkCore;

namespace ModeloParcial.Repositories
{
    public class EnvioRepository : IEnvioRepository
    {
        private readonly EnvioContext _Context;
        private readonly DbSet<Envio> _envio;

        public EnvioRepository(EnvioContext context)
        {
            _Context = context;
            _envio = _Context.Set<Envio>();
        }
        public bool DeleteEnvio(int id)
        {
            var envio = _envio.Find(id);
            if (envio != null)
            {
                if (envio.Estado == true)
                {
                    envio.Estado = false;
                    _Context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            else
            {
                return false;
            }

        }

        public List<Envio>? GetEnvios(string client, bool Estado)
        {
            var envios = new List<Envio>();
            if (client != null && Estado != null)
            {
                envios = _envio.Where(x => x.Direccion.Contains(client) && x.Estado == Estado).ToList();
            }
            else
            {
                if (client == null && Estado != null)
                {
                    envios = _envio.Where(x => x.Estado == Estado).ToList();
                }
                else
                {
                    if (client != null && Estado == null)
                    {
                        envios = _envio.Where(x => x.Direccion.Contains(client)).ToList();
                    }
                }

            }
            return envios;
        }
    }
}
