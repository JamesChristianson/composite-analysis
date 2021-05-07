using CompositeAnalysisCore.Model;
using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompositeAnalysisCore.Data
{
    public class FileCurveDataProvider : ICurveDataProvider
    {

        public CurveDataSet Provide()
        {
            var curves = new List<List<double>>();
            var dependentVariables = new List<List<double>>();

            using (var csv = new CsvReader(new StreamReader(@"C:\repos\CompositeAnalysisCore\CompositeAnalysisConsole\TestData\wheatkernel-csv.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    var curve = new List<double>();
                    curves.Add(curve);

                    for (int i = 0; i < csv.Columns.Count; i++)
                    {
                        curve.Add(Convert.ToDouble(csv[i]));
                    }
                }
            }

            using (var csv = new CsvReader(new StreamReader(@"C:\repos\CompositeAnalysisCore\CompositeAnalysisConsole\TestData\wheatkernel-dependent-csv.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    var dependentVariable = new List<double>();
                    dependentVariables.Add(dependentVariable);

                    for (int i = 0; i < csv.Columns.Count; i++)
                    {
                        dependentVariable.Add(Convert.ToDouble(csv[i]));
                    }
                }
            }


            return new CurveDataSet()
            {
                Curve = curves.Select(p => p.ToArray()).ToArray(),
                DependentVariables = dependentVariables.Select(p => p.ToArray()).ToArray()
            };
        }
    }
}