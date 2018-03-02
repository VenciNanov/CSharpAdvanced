using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle : Shape
{
    private double sideA;
    private double sideB;


    public Rectangle(double sideA, double sideB)
    {
        this.sideA = sideA;
        this.sideB = sideB;
    }

    public override double CalculatePerimeter()
    {
        return 2*(this.sideA+this.sideB);
    }

    public override double CalculateArea()
    {
        return this.sideA * this.sideB;
    }

    public sealed override string Draw()
    {
        return base.Draw() + "Rectangle";
    }

}
