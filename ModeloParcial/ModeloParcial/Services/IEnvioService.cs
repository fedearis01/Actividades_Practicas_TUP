using ModeloParcial.Models;

namespace ModeloParcial.Services
{
    public interface IEnvioService
    {
        public List<Envio>? GetEnvios(string client, bool Estado);

        public bool DeleteEnvio(int id);
    }
}
