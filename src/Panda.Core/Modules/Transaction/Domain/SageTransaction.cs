namespace Panda.Core.Modules.Transaction.Domain;

public sealed record SageTransaction
{
    public int UniqueReferenceNumber { get; set; } = 0;
    public long TransactionId { get; set; } = 0;
    public DateTime TransactionDate { get; set; }
    public int AccountNumber { get; set; } = 0;
    public string AccountName { get; set; } = string.Empty;
    public string AccountCostCentre { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    public string Narrative { get; set; } = string.Empty;
    public int PeriodNumber { get; set; } = 0;
    public decimal Value { get; set; } = 0;
    public long Source { get; set; } = 0;
}