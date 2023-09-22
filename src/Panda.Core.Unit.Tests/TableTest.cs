using Panda.Core.Modules.Tables.Domain;

namespace Panda.Core.Unit.Tests;

public class TableTest
{
    [Fact]
    public void Test_Table_Add_Rows()
    {
        Table? table = new Table();

        Row? row1 = table.CreateAndAddRow();
        Row? row2 = table.CreateAndAddRow();

        Assert.Equal(2, table.Rows.Count);
        Assert.Empty(table.Columns);
        Assert.Empty(table.Cells);

        Assert.StrictEqual(row1, table.Rows.ElementAt(0));
        Assert.StrictEqual(row2, table.Rows.ElementAt(1));
    }

    [Fact]
    public void Test_Table_Add_Columns()
    {
        Table? table = new Table();

        Column? column1 = table.CreateAndAddColumn();
        Column? column2 = table.CreateAndAddColumn();


        Assert.Equal(2, table.Columns.Count);
        Assert.Empty(table.Rows);
        Assert.Empty(table.Cells);

        Assert.StrictEqual(column1, table.Columns.ElementAt(0));
        Assert.StrictEqual(column2, table.Columns.ElementAt(1));
    }

    [Fact]
    public void Test_Table_Add_Remove_Rows()
    {
        Table? table = new Table();

        Row? row1 = table.CreateAndAddRow();
        Row? row2 = table.CreateAndAddRow();

        table.RemoveRow(row1);

        Assert.Single(table.Rows);
        Assert.Equal(row2.Id, table.Rows.ElementAt(0).Id);
    }

    [Fact]
    public void Test_Table_Rows_Columns_Cells()
    {
        Table? table = new Table();

        Row? row1 = table.CreateAndAddRow();
        Column? column1 = table.CreateAndAddColumn();
        Cell? cell1 = table.CreateAndAddCellById(row1.Id, column1.Id);

        IReadOnlyCollection<Cell>? columnCells = column1.GetCells();
        IReadOnlyCollection<Cell>? rowCells = row1.GetCells();

        Assert.Single(table.Rows);
        Assert.Single(table.Columns);
        Assert.Single(table.Cells);

        Assert.StrictEqual(row1, table.Rows.ElementAt(0));
        Assert.StrictEqual(column1, table.Columns.ElementAt(0));
        Assert.StrictEqual(cell1, table.Cells.ElementAt(0));

        Assert.StrictEqual(columnCells.ElementAt(0), cell1);
        Assert.StrictEqual(rowCells.ElementAt(0), cell1);

        column1.RemoveCells();

        Assert.Empty(table.Cells);
        Assert.Empty(row1.GetCells());
        Assert.Empty(column1.GetCells());
    }

    [Fact]
    public void Test_Table_Cell_Update_Restriction()
    {
        Table? table = new Table();

        Row? row1 = table.CreateAndAddRow();
        Column? column1 = table.CreateAndAddColumn();
        Cell? cell1 = table.CreateAndAddCell(row1, column1);

        cell1?.SetName("Test Name");

        Assert.Equal("Test Name", cell1?.Name);

        cell1?.SetPrice(10.5);

        Assert.Equal("Test Name", cell1?.Name);
        Assert.Null(cell1?.Price);
    }
}