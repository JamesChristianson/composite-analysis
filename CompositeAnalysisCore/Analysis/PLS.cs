using Accord.Statistics.Analysis;
using Accord.Statistics.Models.Regression.Linear;
using CompositeAnalysisCore.Data;
using System.Linq;

namespace CompositeAnalysisCore.Analysis
{
    public class PLS
    {
        private readonly ICurveDataProvider _dataProvider;

        public PLS(ICurveDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public double[][] Run(double[][] testData)
        {
            var pls = new PartialLeastSquaresAnalysis()
            {
                Method = AnalysisMethod.Center,
                Algorithm = PartialLeastSquaresAlgorithm.NIPALS
            };

            var data = _dataProvider.Provide();

          var reg = pls.Learn(data.Curve, data.DependentVariables);



            //MLR

            var ols = new OrdinaryLeastSquares();

           var olsReg =  ols.Learn(data.Curve, data.DependentVariables);
            var td = testData.SelectMany(x => x).ToArray();
           double[] predicted = olsReg.Transform(td);

            return reg.Transform(testData);
        }
    }
}
