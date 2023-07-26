using Panda.Core.Modules.Tables.Domain;

namespace Panda.Core.Tests.Modules.Tables;

public class TableTest
{
    [Fact]
    public void Test_Table_Add_Rows()
    {
        var table = new Table();

        var row1 = table.CreateAndAddRow();
        var row2 = table.CreateAndAddRow();

        Assert.Equal(2, table.Rows.Count);
        Assert.Equal(0, table.Columns.Count);
        Assert.Equal(0, table.Cells.Count);

        Assert.StrictEqual(row1, table.Rows.ElementAt(0));
        Assert.StrictEqual(row2, table.Rows.ElementAt(1));
    }

    [Fact]
    public void Test_Table_Add_Columns()
    {
        var table = new Table();

        var column1 = table.CreateAndAddColumn();
        var column2 = table.CreateAndAddColumn();


        Assert.Equal(2, table.Columns.Count);
        Assert.Equal(0, table.Rows.Count);
        Assert.Equal(0, table.Cells.Count);

        Assert.StrictEqual(column1, table.Columns.ElementAt(0));
        Assert.StrictEqual(column2, table.Columns.ElementAt(1));
    }

    [Fact]
    public void Test_Table_Add_Remove_Rows()
    {
        var table = new Table();

        var row1 = table.CreateAndAddRow();
        var row2 = table.CreateAndAddRow();

        table.RemoveRow(row1);

        Assert.Equal(1, table.Rows.Count);
        Assert.Equal(row2.Id, table.Rows.ElementAt(0).Id);
    }

    [Fact]
    public void Test_Table_Rows_Columns_Cells()
    {
        var table = new Table();

        var row1 = table.CreateAndAddRow();
        var column1 = table.CreateAndAddColumn();
        var cell1 = table.CreateAndAddCellById(row1.Id, column1.Id);

        var columnCells = column1.GetCells();
        var rowCells = row1.GetCells();

        Assert.Equal(1, table.Rows.Count);
        Assert.Equal(1, table.Columns.Count);
        Assert.Equal(1, table.Cells.Count);

        Assert.StrictEqual(row1, table.Rows.ElementAt(0));
        Assert.StrictEqual(column1, table.Columns.ElementAt(0));
        Assert.StrictEqual(cell1, table.Cells.ElementAt(0));

        Assert.StrictEqual(columnCells.ElementAt(0), cell1);
        Assert.StrictEqual(rowCells.ElementAt(0), cell1);

        column1.RemoveCells();

        Assert.Equal(0, table.Cells.Count);
        Assert.Equal(0, row1.GetCells().Count);
        Assert.Equal(0, column1.GetCells().Count);
    }

    [Fact]
    public void Test_Table_Cell_Update_Restriction()
    {
        var table = new Table();

        var row1 = table.CreateAndAddRow();
        var column1 = table.CreateAndAddColumn();
        var cell1 = table.CreateAndAddCell(row1, column1);

        cell1?.SetName("Test Name");

        Assert.Equal("Test Name", cell1?.Name);

        cell1?.SetPrice(10.5);

        Assert.Equal("Test Name", cell1?.Name);
        Assert.Null(cell1?.Price);
    }
}
