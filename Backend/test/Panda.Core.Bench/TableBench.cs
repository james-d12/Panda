using BenchmarkDotNet.Attributes;
using Panda.Core.Modules.Tables.Domain;

namespace Panda.Core.Domain.Bench;

public class TableBench
{
    [Benchmark]
    public void CreateRows()
    {
        var table = new Table();
        for (int i = 0; i < 1000; i++)
        {
            table.CreateAndAddRow();
        }
    }

    [Benchmark]
    public void CreateRowsAndColumnsAndCells()
    {
        var table = new Table();
        var row = table.CreateAndAddRow();
        var column = table.CreateAndAddColumn();

        table.CreateAndAddCells(row, column, 1000);
    }
}
