namespace CatADog.Domain.Repositories;

public interface ISessionHelper
{
    ISessionRepository OpenSession();
}