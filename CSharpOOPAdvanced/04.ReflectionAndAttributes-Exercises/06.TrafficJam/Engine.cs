using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private readonly List<TrafficLight> trafficLights;

    public Engine()
    {
        this.trafficLights = new List<TrafficLight>();
    }

    public void Run()
    {
        SetLights();

        int n = int.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();

        foreach (var _ in Enumerable.Range(0, n))
        {
            this.trafficLights.ForEach(x => x.ChangeSignal());

            sb.AppendLine(string.Join(" ", this.trafficLights));
        }

        Console.WriteLine(sb.ToString().Trim());
    }

    private void SetLights()
    {
        string[] trafficLightSignals = Console.ReadLine().Split();

        foreach (var trafficLight in trafficLightSignals)
        {
            if (Enum.TryParse(trafficLight, out Signals signal))
            {
                this.trafficLights.Add(new TrafficLight(signal));
            }
        }
    }
    private string ChangeSignal(TrafficLight trafficLight)
    {
        trafficLight.ChangeSignal();
        var result = trafficLight.Signal.ToString();
        return result;
    }
}