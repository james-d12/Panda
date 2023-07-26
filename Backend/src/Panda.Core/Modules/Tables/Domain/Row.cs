namespace Panda.Core.Modules.Tables.Domain;

public sealed class Row
{
    public Guid Id { get; private set; }
    public Guid TableId { get; private set; }
    public Table Table { get; private set; } = null!;
    public string Notes { get; private set; } = string.Empty;

    private Row() { }

    internal Row(Table table, string notes)
    {
        Id = Guid.NewGuid();
        TableId = table.Id;
        Table = table;
        Notes = notes;
    }

    public IReadOnlyCollection<Cell> GetCells()
    {
        return Table.GetCellsForRow(Id);
    }

    public void RemoveCells()
    {
        Table.RemoveCellsByRowId(Id);
    }
}