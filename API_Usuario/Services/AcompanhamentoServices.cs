using API_Usuario.Context;

namespace API_Usuario.Services
{
    public class AcompanhamentoServices
    {
        public readonly Db _context;

        public AcompanhamentoServices(Db context)
        {
            _context = context;
        }

    }
}
