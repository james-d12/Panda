using Panda.Core.Modules.Categories.Domain;

namespace Panda.Core.Modules.Sages.Domain;

public sealed class Sage
{
    public Guid Id { get; }
    public Guid SageAccountId { get; }
    public Guid CategoryId { get; }
    public Category Category { get; private set; } = null!;
}