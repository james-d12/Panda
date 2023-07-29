using Panda.Core.Modules.Sages.Repositories;
using Panda.Infrastructure.Sage.Repositories;

namespace Panda.Infrastructure.Tests;

public class SageAccountRepositoryTest
{
    [Fact]
    public void Test_Get_All_This_Year_Sage_Accounts()
    {
        ISageAccountRepository sageAccountRepository = new SageAccountRepository();

        var sageAccounts = sageAccountRepository.GetAllThisYear();

        Assert.True(sageAccounts.Count >= 1, "The result did not have 1 or more elements.");
    }
}
