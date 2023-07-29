using Panda.Core.Modules.Sages.Repositories;
using Panda.Core.Modules.Transaction.Domain;
using Panda.Infrastructure.Utilities;

namespace Panda.Infrastructure.Sage.Repositories;
public sealed class SageTransactionRepository : ISageTransactionRepository
{
    public List<SageTransaction> GetAllThisYear()
    {
        string filePath = "Database/Queries/ThisYearTransactions.sql";
        string sqlQuery = Filesystem.ReadFileAsText(filePath);

        if (sqlQuery.Length <= 0)
        {
            return new List<SageTransaction>();
        }

        List<SageTransaction> sageTransactions = SageDB.ReadDataFromDatabase(sqlQuery, reader =>
        {
            return new SageTransaction
            {
                UniqueReferenceNumber = reader.GetInt32(0),
                TransactionId = reader.GetInt64(1),
                TransactionDate = reader.GetDateTime(2),
                AccountNumber = reader.GetInt32(3),
                AccountName = reader.GetString(4),
                AccountCostCentre = reader.GetString(5),
                Department = reader.GetString(6),
                DepartmentName = reader.GetString(7),
                Reference = reader.GetString(8),
                Narrative = reader.GetString(9),
                PeriodNumber = reader.GetInt16(10),
                Value = reader.GetDecimal(11),
                Source = reader.GetInt64(12)
            };
        });

        return sageTransactions;
    }
}
