using API_Usuario.Context;

namespace API_Usuario.Services
{
    public class FuncionarioServices
    {
        public readonly Db _context;

        public FuncionarioServices(Db context)
        {
            _context = context;
        }
    }
}
