using Panda.Core.Modules.Transaction.Domain;

namespace Panda.Core.Modules.Sages.Repositories;
public interface ISageTransactionRepository
{
    List<SageTransaction> GetAllThisYear();
}
