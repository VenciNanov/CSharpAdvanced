using System;
using System.Collections.Generic;
using System.Text;

public class Smartphone : ISmartphone
{
    public string Model { get; private set; }

    public Smartphone(string model)
    {
        this.Model = model;
    }

    public string Call(string phoneNumber)
    {
        if (this.CheckNumber(phoneNumber))
        {
            return $"Calling... {phoneNumber}";
        }
        return "Invalid number!";

    }

    public string Browse(string url)
    {
        if (this.CheckUrl(url))
        {
            return $"Browsing: {url}!";
        }
        return "Invalid URL!";

    }

    private bool CheckUrl(string url)
    {
        for (int i = 0; i < url.Length; i++)
        {
            if (char.IsDigit(url[i]))
            {
                return false;
            }
        }
        return true;
    }

    private bool CheckNumber(string phoneNumber)
    {
        for (int i = 0; i < phoneNumber.Length; i++)
        {
            if (!char.IsDigit(phoneNumber[i]))
            {
                return false;

            }
        }
        return true;
    }
}

