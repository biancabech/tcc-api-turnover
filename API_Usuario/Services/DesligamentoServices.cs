using API_Usuario.Context;

namespace API_Usuario.Services
{
    public class DesligamentoServices
    {
        public readonly Db _context;

        public DesligamentoServices(Db context)
        {
            _context = context;
        }
    }
}
