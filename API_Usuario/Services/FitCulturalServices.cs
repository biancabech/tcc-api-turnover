using API_Usuario.Context;

namespace API_Usuario.Services
{
    public class FitCulturalServices
    {
        public readonly Db _Context;

        public FitCulturalServices(Db context)
        {
            _Context = context;
        }
    }
}
