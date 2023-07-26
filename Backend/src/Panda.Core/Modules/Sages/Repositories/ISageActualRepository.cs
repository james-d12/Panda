using Panda.Core.Modules.Sages.Domain;

namespace Panda.Core.Modules.Sages.Repositories;
public interface ISageActualRepository
{
    List<SageActual> GetAllThisYear();
}
