namespace Microsoft.Data.Analysis.Pandas;

public static class DataFramePandasExtension
{
    public static PrimitiveDataFrameColumn<double> Diff(this DataFrameColumn column, string columnName = "Diff")
    {
        var diffColumn = new PrimitiveDataFrameColumn<double>(columnName);
        var _column = column as PrimitiveDataFrameColumn<double>;
        if (_column is null)
            throw new Exception("column is not instance of PrimitiveDataFrameColumn<double>");

        for (int i = 1; i < _column.Length; i++)
        {
            // double? a = _column[i];
            // double? b = _column[i - 1];
            double? difference = _column[i] - _column[i - 1];
            diffColumn.Append(difference);
        }

        return diffColumn;
    }

    public static void SetValue(this DataFrameColumn column,Func<double?,double?> operation)
    {
        var _column = column as PrimitiveDataFrameColumn<double>;
        if (_column is null)
            throw new Exception("column is not instance of PrimitiveDataFrameColumn<double>");

        // Apply the operation
        for (int i = 0; i < _column.Length; i++)
        {
            column[i] = operation(_column[i]);
        }
    }
}