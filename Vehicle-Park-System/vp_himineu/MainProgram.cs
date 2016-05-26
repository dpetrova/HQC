namespace VehiclePark
{
    using System.Globalization;
    using System.Threading;

    using VehiclePark.Core;

    internal static class MainProgram
    {
        internal static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new Engine();
            engine.Run();
        }
    }
}