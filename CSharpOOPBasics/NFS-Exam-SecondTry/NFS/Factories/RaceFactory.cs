using System;

public static class RaceFactory
{
    public static Race Create(string type,int length,string route,int prizePool)
    {
        switch (type)
        {
            case "Casual":
                return new CasualRace(length, route, prizePool);

            case "Drag":
                return new DragRace(length, route, prizePool);

            case "Drift":
                return new DriftRace(length, route, prizePool);

            default:
                throw new ArgumentException();
        }
    }
}