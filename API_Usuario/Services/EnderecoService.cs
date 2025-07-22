using API_Usuario.Context;
using API_Usuario.Models;

namespace API_Usuario.Services
{
    public class EnderecoService
    {
        public readonly Db _context;

        public EnderecoService(Db context)
        {
            _context = context;
        }

        public async Task<List<Endereco>> GetAllEndereco()
        {
            return await _context.Enderecos
                
                
               
        }
    }
}
