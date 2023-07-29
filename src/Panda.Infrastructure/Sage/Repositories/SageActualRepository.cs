using Panda.Core.Modules.Sages.Domain;
using Panda.Core.Modules.Sages.Repositories;
using Panda.Infrastructure.Utilities;

namespace Panda.Infrastructure.Sage.Repositories;
public sealed class SageActualRepository : ISageActualRepository
{
    public List<SageActual> GetAllThisYear()
    {
        string filePath = "Database/Queries/ThisYearSageActuals.sql";
        string sqlQuery = Filesystem.ReadFileAsText(filePath);

        if (sqlQuery.Length <= 0)
        {
            return new List<SageActual>();
        }

        List<SageActual> sageActuals = SageDB.ReadDataFromDatabase(sqlQuery, reader =>
        {
            return new SageActual
            {
                AccountNumber = reader.GetInt32(0),
                AccountName = reader.GetString(1),
                AccountCostCentre = reader.GetString(2),
                CostCentreName = reader.GetString(3),
                Department = reader.GetString(4),
                DepartmentName = reader.GetString(5),
                PeriodNumber = reader.GetInt16(6),
                ActualValue = reader.GetDecimal(7),
                BudgetValue = reader.GetDecimal(8),
                BudgetValuePrevious = reader.GetDecimal(9)
            };
        });

        return sageActuals;
    }
}
