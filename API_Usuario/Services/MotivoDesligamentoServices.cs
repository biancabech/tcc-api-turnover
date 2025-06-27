using API_Usuario.Context;

namespace API_Usuario.Services
{
    public class MotivoDesligamentoServices
    {
        public readonly Db _Context;

        public MotivoDesligamentoServices(Db context)
        {
            _Context = context;
        }
    }
}
