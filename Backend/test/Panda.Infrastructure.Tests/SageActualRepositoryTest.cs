using Panda.Core.Modules.Sages.Repositories;
using Panda.Infrastructure.Database.Sage;

namespace Panda.Infrastructure.Tests;
public class SageActualRepositoryTest
{
    [Fact]
    public void Test_Get_This_Year_Sage_Actuals()
    {
        ISageActualRepository sageActualRepository = new SageActualRepository();

        var sageAccounts = sageActualRepository.GetAllThisYear();

        Assert.True(sageAccounts.Count >= 1, "The result did not have 1 or more elements.");
    }
}
