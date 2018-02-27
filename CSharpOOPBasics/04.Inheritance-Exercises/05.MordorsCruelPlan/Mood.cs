using System;
using System.Collections.Generic;
using System.Text;

public class Mood
{
    private string mood;
    private int happines;

    public int HappinesLevel
    {
        get { return this.happines; }
    }


    public string MoodType
    {
        get
        {
            GetMood();
            return this.mood;
        }
    }

    public Mood()
    {
        this.happines = 0;
        this.mood = string.Empty;
    }

    public void AddHappiness(string food)
    {
        HappinesFromFood happinesFromFood = new HappinesFromFood();

        bool isParsed = Enum.TryParse<HappinesFromFood>(food.ToLower(), out happinesFromFood);

        if (!isParsed)
        {
            happinesFromFood = HappinesFromFood.EverythingElse;
        }
        this.happines += (int)happinesFromFood;
    }

    private void GetMood()
    {
        if (this.happines < -5) this.mood = "Angry";

        if (this.happines >= -5 && this.happines <= 0) this.mood = "Sad";

        if (this.happines >= 1 && this.happines < 15) this.mood = "Happy";

        if (this.happines > 15) this.mood = "JavaScript";

    }


}

