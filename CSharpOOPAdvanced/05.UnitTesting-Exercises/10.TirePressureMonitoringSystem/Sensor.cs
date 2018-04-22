using System;
using System.Collections.Generic;
using System.Text;

class Sensor : ISensor
{
    const double Offset = 16;
    readonly Random _randomPressureSampleSimulator = new Random();

    public double PopNextPressurePSIValue()
    {
        double pressureTelemetryValue = ReadPressureSample();

        return Offset + pressureTelemetryValue;
    }

    private double ReadPressureSample()
    {
        return 6 * _randomPressureSampleSimulator.NextDouble() * _randomPressureSampleSimulator.NextDouble();


    }
}
