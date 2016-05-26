namespace _2.TirePressureMonitoringSystem
{
    public interface ISensor
    {
        IRandomNumberProvider RandomNumberProvider { get; set; }

        double PopNextPressurePsiValue();
    }
}
