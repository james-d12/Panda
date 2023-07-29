using Panda.Core.Modules.Budgets.Domain;

namespace Panda.Core.Modules.Companies.Domain;

public sealed class Company
{
    private readonly HashSet<Budget> _budgets = new();
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public IReadOnlyCollection<Budget> Budgets { get => _budgets; }

    private Company() { }

    public Company(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }
}
