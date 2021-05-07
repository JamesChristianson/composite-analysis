using Accord.Math.Optimization.Losses;

namespace CompositeAnalysisCore.Errors
{
    public class MultipleErrorAnalysis
    {

        public void CalculateErrors(double[] outputs, double[] predicted)
        {
            // Now we can compute diverse error metrics using, e.g.:
            double mse = new SquareLoss(outputs).Loss(predicted);

            double sse = new SquareLoss(outputs)
            {
                Mean = false
            }.Loss(predicted);

            double rmse = new SquareLoss(outputs)
            {
                Mean = true,
                Root = true
            }.Loss(predicted);

            // coefficient of determination r²
            double r2 = new RSquaredLoss(numberOfInputs: 1, expected: outputs).Loss(predicted);

            // adjusted or weighted versions of r² using
            var r2loss = new RSquaredLoss(numberOfInputs: 1, expected: outputs)
            {
                Adjust = true,
            }.Loss(predicted);

        }
    }
}
