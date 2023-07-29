namespace Panda.Core.Modules.Sages.Domain;

public sealed record SageActual
{
    public int AccountNumber { get; set; } = 0;
    public string AccountName { get; set; } = string.Empty;
    public string AccountCostCentre { get; set; } = string.Empty;
    public string CostCentreName { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public int PeriodNumber { get; set; } = 0;
    public decimal ActualValue { get; set; } = 0;
    public decimal BudgetValue { get; set; } = 0;
    public decimal BudgetValuePrevious { get; set; } = 0;

    public bool Compare(SageActual sageActual)
    {
        return AccountNumber == sageActual.AccountNumber &&
               AccountName == sageActual.AccountName &&
               AccountCostCentre == sageActual.AccountCostCentre &&
               Department == sageActual.Department &&
               DepartmentName == sageActual.DepartmentName;
    }
}