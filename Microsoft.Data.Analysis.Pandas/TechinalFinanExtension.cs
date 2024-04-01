namespace Microsoft.Data.Analysis.Pandas;

public static class TechinalFinanExtension
{
    public static PrimitiveDataFrameColumn<double> Rma(this DataFrameColumn column, int length = 14)
    {
        var _column = column as PrimitiveDataFrameColumn<double>;
        if (_column is null)
            throw new Exception("column is not instance of PrimitiveDataFrameColumn<double>");

        var _series = _column.Clone();
        var alpha = 1.0 / length;
        for (int i = 1; i < _series.Length; i++)
        {
            if (_series[i - 1].HasValue)
            {
                _series[i] = (_series[i] * alpha) + (1 - alpha) * (_series[i - 1]);
            }
            else
            {
                _series[i] = (_series[i] / length);
            }
        }

        return _series;
    }
}