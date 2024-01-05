namespace Panda.Core.Modules.Tables.Domain;

public sealed class Row
{
    private Row() { }

    internal Row(Table table, string notes)
    {
        Id = Guid.NewGuid();
        TableId = table.Id;
        Table = table;
        Notes = notes;
    }

    public Guid Id { get; }
    public Guid TableId { get; private set; }
    public Table Table { get; } = null!;
    public string Notes { get; private set; } = string.Empty;

    public IReadOnlyCollection<Cell> GetCells()
    {
        return Table.GetCellsForRow(Id);
    }

    public void RemoveCells()
    {
        Table.RemoveCellsByRowId(Id);
    }
}