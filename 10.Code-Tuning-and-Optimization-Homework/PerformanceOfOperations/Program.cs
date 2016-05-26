//+-----------+------------------+------------------+------------------+------------------+------------------+--+
//| operation |       int        |       long       |      double      |      float       |     decimal      |  |
//+-----------+------------------+------------------+------------------+------------------+------------------+--+
//| +         | 00:00:00.0258229 | 00:00:00.0009915 | 00:00:00.0013285 | 00:00:00.0014243 | 00:00:00.0027454 |  |
//| -         | 00:00:00.0009071 | 00:00:00.0006745 | 00:00:00.0029546 | 00:00:00.0017453 | 00:00:00.0015201 |  |
//| ++        | 00:00:00.0028936 | 00:00:00.0011266 | 00:00:00.0010194 | 00:00:00.0010673 | 00:00:00.0046612 |  |
//| *         | 00:00:00.0041138 | 00:00:00.0008256 | 00:00:00.0008079 | 00:00:00.0007007 | 00:00:00.0051567 |  |
//| /         | 00:00:00.0010434 | 00:00:00.0008484 | 00:00:00.0011563 | 00:00:00.0007902 | 00:00:00.0019135 |  |
//| Sqrt      |                  |                  | 00:00:00.0040944 | 00:00:00.0013667 | 00:00:00.0040231 |  |
//| Log       |                  |                  | 00:00:00.0016495 | 00:00:00.0011797 | 00:00:00.0012047 |  |
//| Sin       |                  |                  | 00:00:00.0011164 | 00:00:00.0013992 | 00:00:00.0009812 |  |
//+-----------+------------------+------------------+------------------+------------------+------------------+--+

namespace PerformanceOfOperations
{
    using System;
    using System.Diagnostics;

    internal class Program
    {
        private const int IntValue = 111;

        private const long LongValue = 111111111111111;

        private const float FloatValue = 1.1111111111f;

        private const double DoubleValue = 1.1111111111d;

        private const decimal DecimalValue = 1.1111111111m;

        private static void Main()
        {
            Console.WriteLine("Add:");
            AddValue(IntValue);
            AddValue(LongValue);
            AddValue(FloatValue);
            AddValue(DoubleValue);
            AddValue(DecimalValue);

            Console.WriteLine("Subtract:");
            SubtractValue(IntValue);
            SubtractValue(LongValue);
            SubtractValue(FloatValue);
            SubtractValue(DoubleValue);
            SubtractValue(DecimalValue);

            Console.WriteLine("Increment:");
            IncrementValue(IntValue);
            IncrementValue(LongValue);
            IncrementValue(FloatValue);
            IncrementValue(DoubleValue);
            IncrementValue(DecimalValue);

            Console.WriteLine("Multiply:");
            MultiplyValue(IntValue);
            MultiplyValue(LongValue);
            MultiplyValue(FloatValue);
            MultiplyValue(DoubleValue);
            MultiplyValue(DecimalValue);

            Console.WriteLine("Divide:");
            DivideValue(IntValue);
            DivideValue(LongValue);
            DivideValue(FloatValue);
            DivideValue(DoubleValue);
            DivideValue(DecimalValue);

            Console.WriteLine("Square root:");
            SquareRootValue(FloatValue);
            SquareRootValue(DoubleValue);
            SquareRootValue(DecimalValue);

            Console.WriteLine("Natural log:");
            NaturalLogValue(FloatValue);
            NaturalLogValue(DoubleValue);
            NaturalLogValue(DecimalValue);

            Console.WriteLine("Sine:");
            SineValue(FloatValue);
            SineValue(DoubleValue);
            SineValue(DecimalValue);
        }

        private static void AddValue(dynamic value)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            value += 999;
            stopwatch.Stop();

            Console.WriteLine("Time elapsed for {0}: {1}", value.GetType(), stopwatch.Elapsed);
        }

        private static void SubtractValue(dynamic value)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            value -= 999;
            stopwatch.Stop();

            Console.WriteLine("Time elapsed for {0}: {1}", value.GetType(), stopwatch.Elapsed);
        }

        private static void IncrementValue(dynamic value)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            value++;
            stopwatch.Stop();

            Console.WriteLine("Time elapsed for {0}: {1}", value.GetType(), stopwatch.Elapsed);
        }

        private static void MultiplyValue(dynamic value)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            if (value is decimal)
            {
                value *= 9.99m;
            }
            else
            {
                var result = value * 9.99;
            }

            stopwatch.Stop();

            Console.WriteLine("Time elapsed for {0}: {1}", value.GetType(), stopwatch.Elapsed);
        }

        private static void DivideValue(dynamic value)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            if (value is decimal)
            {
                value /= 9.99m;
            }
            else
            {
                var result = value / 9.99;
            }

            stopwatch.Stop();

            Console.WriteLine("Time elapsed for {0}: {1}", value.GetType(), stopwatch.Elapsed);
        }

        private static void SquareRootValue(dynamic value)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            if (value is decimal)
            {
                value = (decimal)Math.Sqrt((double)value);
            }
            else
            {
                var result = Math.Sqrt(value);
            }

            stopwatch.Stop();

            Console.WriteLine("Time elapsed for {0}: {1}", value.GetType(), stopwatch.Elapsed);
        }

        private static void NaturalLogValue(dynamic value)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            if (value is decimal)
            {
                value = (decimal)Math.Log((double)value);
            }
            else
            {
                var result = Math.Log(value);
            }

            stopwatch.Stop();

            Console.WriteLine("Time elapsed for {0}: {1}", value.GetType(), stopwatch.Elapsed);
        }

        private static void SineValue(dynamic value)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            if (value is decimal)
            {
                value = (decimal)Math.Sin((double)value);
            }
            else
            {
                var result = Math.Sin(value);
            }

            stopwatch.Stop();

            Console.WriteLine("Time elapsed for {0}: {1}", value.GetType(), stopwatch.Elapsed);
        }
    }
}
