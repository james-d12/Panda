namespace Panda.Core.Modules.Sages.Domain;
public sealed class SageAccount
{
    public int AccountNumber { get; set; } = 0;
    public string AccountName { get; set; } = string.Empty;
    public string AccountCostCentre { get; set; } = string.Empty;
    public string CostCentreName { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public decimal RunRate { get; set; } = 0;
    public decimal ActualValue { get; set; } = 0;
    public decimal BudgetValue { get; set; } = 0;
}
