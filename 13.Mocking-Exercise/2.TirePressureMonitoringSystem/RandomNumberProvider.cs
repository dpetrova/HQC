namespace _2.TirePressureMonitoringSystem
{
    using System;

    public class RandomNumberProvider : IRandomNumberProvider
    {
        private Random random;

        public RandomNumberProvider()
        {
            random = new Random();
        }

        public double GetRandomNumber()
        {
            return this.random.NextDouble();
        }
    }
}
