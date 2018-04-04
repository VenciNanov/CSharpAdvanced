using System;
using System.Collections.Generic;
using System.Text;

public class TrafficLight
{
    private Queue<Signals> signals;

    public TrafficLight(Signals signal)
    {
        this.signals = new Queue<Signals>();
        SetSignals(signal);
    }

    private void SetSignals(Signals signal)
    {
        var signalsCount = Enum.GetNames(typeof(Signals)).Length;

        var currentSignal = signal;

        while (this.signals.Count != signalsCount)
        {
            this.signals.Enqueue(currentSignal);

            var nextSignal = (int)currentSignal + 1;
            if (nextSignal == signalsCount)
            {
                nextSignal = 0;
            }

            currentSignal = (Signals)nextSignal;
        }

    }

    public Signals Signal => this.signals.Peek();

    public void ChangeSignal()
    {
        var oldSignal = this.signals.Dequeue();
        this.signals.Enqueue(oldSignal);
    }

    public override string ToString()
    {
        return this.Signal.ToString();
    }
}
