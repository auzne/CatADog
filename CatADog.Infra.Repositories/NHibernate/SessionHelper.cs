using CatADog.Domain.Repositories;

namespace CatADog.Infra.Repositories.NHibernate;

public class SessionHelper : ISessionHelper
{
    public ISessionRepository OpenSession()
    {
        return new SessionRepository(NHibernateHelper.OpenSession());
    }
}