using Panda.Core.Modules.Categories.Domain;

namespace Panda.Core.Modules.Sages.Domain;

public sealed class Sage
{
    public Guid Id { get; private set; }
    public Guid SageAccountId { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;
}