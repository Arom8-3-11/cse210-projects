using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Shapes Project.");

        // Test individually
        // Square square = new Square("Red", 5);
        // Console.WriteLine($"Square: {square.GetColor()}, Area: {square.GetArea()}");

        // Rectangle rectangle = new Rectangle("Blue", 4, 6);
        // Console.WriteLine($"Rectangle: {rectangle.GetColor()}, Area: {rectangle.GetArea()}");

        // Circle circle = new Circle("Green", 3);
        // Console.WriteLine($"Circle: {circle.GetColor()}, Area: {circle.GetArea()}");

        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Red", 6);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 4, 7);
        shapes.Add(s2);

        Circle s3 = new Circle("Green", 9);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            // Notice that all shapes have a GetColor method from the base class
            string color = s.GetColor();

            // Notice that all shapes have a GetArea method, but the behavior is
            // different for each type of shape
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}