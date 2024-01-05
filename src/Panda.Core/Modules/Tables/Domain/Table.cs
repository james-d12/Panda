using Panda.Core.Modules.Reviews.Domain;
using Panda.Core.Modules.Sandboxes.Domain;
using Panda.Core.Modules.Summaries.Domain;
using System.Collections.Immutable;

namespace Panda.Core.Modules.Tables.Domain;

public sealed class Table
{
    private readonly HashSet<Cell> _cells = new();
    private readonly HashSet<Column> _columns = new();
    private readonly HashSet<Row> _rows = new();

    public Table()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
    public Guid? SandboxId { get; private set; }
    public Sandbox Sandbox { get; private set; } = null!;
    public Guid? SummaryId { get; private set; }
    public Summary Summary { get; private set; } = null!;
    public Guid? ReviewId { get; private set; }
    public Review Review { get; private set; } = null!;

    public IReadOnlyCollection<Column> Columns => _columns;
    public IReadOnlyCollection<Row> Rows => _rows;
    public IReadOnlyCollection<Cell> Cells => _cells;

    public void SetReview(Review review)
    {
        ReviewId = review.Id;
        Review = review;
    }

    public void SetSandbox(Sandbox sandbox)
    {
        SandboxId = sandbox.Id;
        Sandbox = sandbox;
    }

    public void SetSummary(Summary summary)
    {
        SummaryId = summary.Id;
        Summary = summary;
    }

    public Row CreateAndAddRow()
    {
        Row row = new(this, "");
        _rows.Add(row);
        return row;
    }

    public Column CreateAndAddColumn()
    {
        Column column = new(this, "", "");
        _columns.Add(column);
        return column;
    }

    public Cell? CreateAndAddCellById(Guid rowId, Guid columnId)
    {
        Row? row = _rows.First(row => row.Id == rowId);
        Column? column = _columns.First(column => column.Id == columnId);

        if (row == null || column == null)
        {
            return null;
        }

        Cell cell = new Cell(this, row, column);
        _cells.Add(cell);
        return cell;
    }

    public Cell? CreateAndAddCell(Row row, Column column)
    {
        return CreateAndAddCellById(row.Id, column.Id);
    }

    public void CreateAndAddCellsById(Guid rowId, Guid columnId, int count)
    {
        Row row = _rows.First(row => row.Id == rowId);
        Column column = _columns.First(column => column.Id == columnId);
        CreateAndAddCells(row, column, count);
    }

    public void CreateAndAddCells(Row row, Column column, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Cell cell = new Cell(this, row, column);
            _cells.Add(cell);
        }
    }

    public void AddCell(Cell cell)
    {
        if (cell.TableId != Id)
        {
            return;
        }

        Row? row = _rows.First(row => row.Id == cell.RowId);
        Column? column = _columns.First(column => column.Id == cell.ColumnId);

        if (row == null || column == null)
        {
            return;
        }

        _cells.Add(cell);
    }

    public void RemoveRowById(Guid rowId)
    {
        _cells.RemoveWhere(cell => cell.RowId == rowId);
        _rows.RemoveWhere(row => row.Id == rowId);
    }

    public void RemoveRow(Row row)
    {
        RemoveRowById(row.Id);
    }

    public void RemoveColumnById(Guid columnId)
    {
        _cells.RemoveWhere(cell => cell.ColumnId == columnId);
        _columns.RemoveWhere(column => column.Id == columnId);
    }

    public void RemoveColumn(Column column)
    {
        RemoveColumnById(column.Id);
    }

    public void RemoveCellById(Guid cellId)
    {
        _cells.RemoveWhere(cell => cell.Id == cellId);
    }

    public void RemoveCell(Cell cell)
    {
        RemoveCellById(cell.Id);
    }

    public void RemoveCellsByRowId(Guid rowId)
    {
        _cells.RemoveWhere(cell => cell.RowId == rowId);
    }

    public void RemoveCellsByColumnId(Guid columnId)
    {
        _cells.RemoveWhere(cell => cell.ColumnId == columnId);
    }

    public IReadOnlyCollection<Cell> GetCellsForRow(Guid rowId)
    {
        return _cells.Where(cell => cell.RowId == rowId).ToImmutableList();
    }

    public IReadOnlyCollection<Cell> GetCellsForColumn(Guid columnId)
    {
        return _cells.Where(cell => cell.ColumnId == columnId).ToImmutableList();
    }
}