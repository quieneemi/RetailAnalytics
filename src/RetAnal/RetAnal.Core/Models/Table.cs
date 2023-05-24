namespace RetAnal.Core.Models;

public class Table
{
    public string[] Columns { get; set; }
    public string[][] Rows { get; set; }
    public int RowsAmount { get; set; }

    public Table()
    {
        Columns = Array.Empty<string>();
        Rows = Array.Empty<string[]>();
    }

    public Table(string[] columns, string[][] rows, int rowsAmount = 0)
    {
        Columns = columns;
        Rows = rows;
        RowsAmount = rowsAmount;
    }
}