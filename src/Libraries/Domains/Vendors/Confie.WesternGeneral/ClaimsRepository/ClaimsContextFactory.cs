using Confie.Infrastructure.Factories;

namespace Confie.WesternGeneral.ClaimsRepository
{
    public class ClaimsContextFactory : IFactory<ClaimsContext>
    {
        public ClaimsContext Create()
        {
            return new ClaimsContext();
        }
    }
}