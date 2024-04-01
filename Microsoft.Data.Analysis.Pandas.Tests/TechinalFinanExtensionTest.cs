using System;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Data.Analysis.Pandas;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Data.Analysis.Pandas.Tests;

[TestSubject(typeof(TechinalFinanExtension))]
public class TechinalFinanExtensionTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TechinalFinanExtensionTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void RmaTest()
    {
        var up = new DoubleDataFrameColumn("Close", new[] { 0.0,0.1,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.1,0.0,0.35,0.0,0.0,0.0 });
        var rma = up.Rma(14).Select(c=> c is null? null: (double?)Math.Round(c.Value,6));
        var exp = "0,0.007143,0.006633,0.006159,0.005719,0.00531,0.004931,0.004579,0.004252,0.011091,0.010299,0.034563,0.032094,0.029802,0.027673";
        var act = String.Join(",", rma);
        _testOutputHelper.WriteLine(act);

        Assert.Equal(exp, act);
    }
}