namespace OsuRealDifficulty.Mania;

public static class DifficultyCalculationAlgorithms
{
    public static class Aggregation
    {
        public static AnalysisDifficultyValue SmallDoubleMeans<T>(
            IReadOnlyList<T> annotations,
            Func<T, double> valueCalculator)
            where T : IMapAnnotation
        {
            int count = annotations.Count;

            if (count is 0)
                return AnalysisDifficultyValue.NormalizedZero;

            var values = annotations.Select(valueCalculator)
                .Where(s => s > 0)
                .ToArray();

            return SmallDoubleMeans(values);
        }

        public static AnalysisDifficultyValue SmallDoubleMeans(
            double[] values)
        {
            int count = values.Length;

            if (count is 0)
                return AnalysisDifficultyValue.NormalizedZero;

            double valueSum = values.Sum();

            double mean2 = SomeMath.Mean2(values);
            double[] deviations = new double[count];
            for (int i = 0; i < deviations.Length; i++)
            {
                deviations[i] = values[i] / mean2;
            }
            var deviationMean = SomeMath.Mean(deviations, 4);
            var deviationValue = Math.Pow(deviationMean + 0.4, 2.5);
            var ceiling = mean2 * 10 * deviationValue;
            var valueSumValue = valueSum * deviationMean;
            var absoluteValue = Math.Min(ceiling, valueSumValue);
            double populationMultiplier = Math.Log(count, 20);
            if (populationMultiplier > 1)
            {
                populationMultiplier = Math.Log(populationMultiplier + 1, 2);
            }
            absoluteValue *= populationMultiplier;
            return new(absoluteValue);
        }
    }
}
