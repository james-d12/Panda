namespace Panda.Core.Modules.Tables.Domain;

public sealed class Column
{
    public Guid Id { get; private set; }
    public Guid TableId { get; private set; }
    public Table Table { get; private set; } = null!;
    public string Title { get; private set; } = string.Empty;
    public string Field { get; private set; } = string.Empty;

    private Column() { }

    internal Column(Table table, string title, string field)
    {
        Id = Guid.NewGuid();
        TableId = table.Id;
        Table = table;
        Title = title;
        Field = field;
    }

    public IReadOnlyCollection<Cell> GetCells()
    {
        return Table.GetCellsForColumn(Id);
    }

    public void RemoveCells()
    {
        Table.RemoveCellsByColumnId(Id);
    }
}