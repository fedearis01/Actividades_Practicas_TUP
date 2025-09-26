using ModeloParcial.Models;
using ModeloParcial.Repositories;

namespace ModeloParcial.Services
{
    public class EnvioService:IEnvioService
    {
        private readonly IEnvioRepository _repository;
        public EnvioService(IEnvioRepository repository) 
        {
            _repository = repository;
        }

        public bool DeleteEnvio(int id)
        {
           return _repository.DeleteEnvio(id);
        }

        public List<Envio>? GetEnvios(string client, bool Estado)
        {
            return _repository.GetEnvios(client, Estado);
        }
    }
}
