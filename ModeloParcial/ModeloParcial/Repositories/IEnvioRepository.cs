using ModeloParcial.Models;

namespace ModeloParcial.Repositories

{
    public interface IEnvioRepository
    {

        public List<Envio>? GetEnvios(string client,bool Estado);

        public bool DeleteEnvio(int id);

    }
}
