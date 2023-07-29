namespace Panda.Core.Modules.Tables.Domain;

public sealed class Cell
{
    public Guid Id { get; private set; }
    public Guid RowId { get; private set; }
    public Row Row { get; private set; } = null!;
    public Guid ColumnId { get; private set; }
    public Column Column { get; private set; } = null!;
    public Guid TableId { get; private set; }
    public Table Table { get; private set; } = null!;
    public DateTime? DateTime { get; private set; } = null;
    public ulong? Quantity { get; private set; } = null;
    public double? Price { get; private set; } = null;
    public string? Name { get; private set; } = null;

    private Cell() { }

    internal Cell(Table table, Row row, Column column)
    {
        Id = Guid.NewGuid();
        RowId = row.Id;
        Row = row;
        ColumnId = column.Id;
        Column = column;
        TableId = table.Id;
        Table = table;
    }


    public void SetDateTime(DateTime dateTime)
    {
        if (!CanSetDate())
        {
            return;
        }

        DateTime = dateTime;
    }


    public void SetPrice(double price)
    {
        if (!CanSetPrice())
        {
            return;
        }

        Price = price;
    }

    public void SetQuantity(ulong quantity)
    {
        if (!CanSetQuantity())
        {
            return;
        }

        Quantity = quantity;
    }
    public void SetName(string name)
    {
        if (!CanSetName())
        {
            return;
        }

        Name = name;
    }

    private bool CanSetDate()
    {
        object?[] fields = { Price, Quantity, Name };
        return fields.All(field => field == null);
    }
    private bool CanSetPrice()
    {
        object?[] fields = { DateTime, Quantity, Name };
        return fields.All(field => field == null);
    }

    private bool CanSetQuantity()
    {
        object?[] fields = { DateTime, Price, Name };
        return fields.All(field => field == null);
    }

    private bool CanSetName()
    {
        object?[] fields = { DateTime, Price, Quantity };
        return fields.All(field => field == null);
    }
}