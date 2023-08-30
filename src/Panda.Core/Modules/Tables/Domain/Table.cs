using Panda.Core.Modules.Reviews.Domain;
using Panda.Core.Modules.Sandboxes.Domain;
using Panda.Core.Modules.Summaries.Domain;
using System.Collections.Immutable;

namespace Panda.Core.Modules.Tables.Domain;

public sealed class Table
{
    private readonly HashSet<Column> _columns = new();
    private readonly HashSet<Row> _rows = new();
    private readonly HashSet<Cell> _cells = new();

    public Guid Id { get; private set; }
    public Guid? SandboxId { get; private set; } = null;
    public Sandbox Sandbox { get; private set; } = null!;
    public Guid? SummaryId { get; private set; } = null;
    public Summary Summary { get; private set; } = null!;
    public Guid? ReviewId { get; private set; } = null;
    public Review Review { get; private set; } = null!;

    public IReadOnlyCollection<Column> Columns { get => _columns; }
    public IReadOnlyCollection<Row> Rows { get => _rows; }
    public IReadOnlyCollection<Cell> Cells { get => _cells; }

    public Table()
    {
        Id = Guid.NewGuid();
    }

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
        var row = new Row(table: this, notes: "");
        _rows.Add(row);
        return row;

    }

    public Column CreateAndAddColumn()
    {
        var column = new Column(table: this, title: "", field: "");
        _columns.Add(column);
        return column;
    }

    public Cell? CreateAndAddCellById(Guid rowId, Guid columnId)
    {
        var row = _rows.First(row => row.Id == rowId);
        var column = _columns.First(column => column.Id == columnId);

        if (row == null || column == null)
        {
            return null;
        }

        var cell = new Cell(table: this, row, column);
        _cells.Add(cell);
        return cell;
    }

    public Cell? CreateAndAddCell(Row row, Column column)
    {
        return CreateAndAddCellById(row.Id, column.Id);
    }

    public void CreateAndAddCellsById(Guid rowId, Guid columnId, int count)
    {
        var row = _rows.First(row => row.Id == rowId);
        var column = _columns.First(column => column.Id == columnId);
        CreateAndAddCells(row, column, count);
    }

    public void CreateAndAddCells(Row row, Column column, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var cell = new Cell(this, row, column);
            _cells.Add(cell);
        }
    }

    public void AddCell(Cell cell)
    {
        if (cell.TableId != Id)
        {
            return;
        }

        var row = _rows.First(row => row.Id == cell.RowId);
        var column = _columns.First(column => column.Id == cell.ColumnId);

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