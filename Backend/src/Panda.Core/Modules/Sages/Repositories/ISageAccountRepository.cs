using Panda.Core.Modules.Sages.Domain;

namespace Panda.Core.Modules.Sages.Repositories;
public interface ISageAccountRepository
{
    List<SageAccount> GetAllThisYear();
    List<SageAccount> GetAllLastYear();
}
