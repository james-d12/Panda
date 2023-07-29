using Panda.Core.Modules.Sages.Domain;
using Panda.Core.Modules.Sages.Repositories;
using Panda.Infrastructure.Utilities;

namespace Panda.Infrastructure.Sage.Repositories;
public sealed class SageAccountRepository : ISageAccountRepository
{
    public List<SageAccount> GetAllLastYear()
    {
        throw new NotImplementedException();
    }

    public List<SageAccount> GetAllThisYear()
    {
        string filePath = "Database/Queries/ThisYearSages.sql";
        string sqlQuery = Filesystem.ReadFileAsText(filePath);

        if (sqlQuery.Length <= 0)
        {
            return new List<SageAccount>();
        }

        List<SageAccount> sageAccounts = SageDB.ReadDataFromDatabase(sqlQuery, reader =>
        {
            return new SageAccount
            {
                AccountNumber = reader.GetInt32(0),
                AccountName = reader.GetString(1),
                AccountCostCentre = reader.GetString(2),
                CostCentreName = reader.GetString(3),
                Department = reader.GetString(4),
                DepartmentName = reader.GetString(5),
                RunRate = reader.GetDecimal(6),
                BudgetValue = reader.GetDecimal(7),
                ActualValue = 0,
            };
        });

        return sageAccounts;
    }
}
