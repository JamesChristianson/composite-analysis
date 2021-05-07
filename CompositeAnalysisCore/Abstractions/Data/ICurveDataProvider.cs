using CompositeAnalysisCore.Model;

namespace CompositeAnalysisCore.Data
{
    public interface ICurveDataProvider
    {
        CurveDataSet Provide();
    }
}