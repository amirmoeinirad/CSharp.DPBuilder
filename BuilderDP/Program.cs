
// Amir Moeini Rad
// September 2025

// Main Concept: The Builder Design Pattern
// With Help from Gemini

// In this pattern, a complex object is constructed step by step and the final step will return the object.
// The construction process can create different types and representations of an object using the same construction code.

namespace BuilderDP
{
    // Product Class
    // This is the complex object we want to build.
    public class Car
    {
        public string? Engine { get; set; }
        public string? Color { get; set; }
        public bool HasGPS { get; set; }

        public void Display()
        {
            Console.WriteLine($"Car Specs:");
            Console.WriteLine($"- Engine: {Engine}");
            Console.WriteLine($"- Color: {Color}");
            Console.WriteLine($"- GPS: {(HasGPS ? "Yes" : "No")}");
        }
    }


    /////////////////////////////////////////////////////////
    
    
    // Builder Interface
    public interface ICarBuilder
    {
        SportsCarBuilder SetEngine(string engine);
        SportsCarBuilder SetColor(string color);
        SportsCarBuilder SetGPS(bool hasGPS);
        Car Build();
    }

    
    // Concrete Builder
    // Modern .NET Style (Fluent Builder)
    public class SportsCarBuilder : ICarBuilder
    {
        private Car _car = new();

        public SportsCarBuilder SetEngine(string engine)
        {
            _car.Engine = engine;
            return this;
        }

        public SportsCarBuilder SetColor(string color)
        {
            _car.Color = color;
            return this;
        }

        public SportsCarBuilder SetGPS(bool hasGPS)
        {
            _car.HasGPS = hasGPS;
            return this;
        }

        public Car Build()
        {
            return _car;
        }
    }


    /////////////////////////////////////////////////////////


    // Client App
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("The Builder Design Pattern in C#.NET.");
            Console.WriteLine("-------------------------------------\n");


            var carBuilder = new SportsCarBuilder();

            // Setting the properties step by step (.NET Fluent Builder Style)
            // Properties of the car object are set using various methods of the builder.
            // This pattern is useful when the object has lots of optional parameters or when the construction process is complex.
            // Using this pattern, we don't need to set the propeties in the constructor of the class.
            // Otherwise, we would have to create multiple constructors for different combinations of parameters.
            carBuilder.SetEngine("Electric")
                      .SetColor("Blue")
                      .SetGPS(false);

            // Finally, we call the Build method to create the configured object.
            Car finalCar = carBuilder.Build();

            // Displaying the built and configured car specifications
            finalCar.Display();


            Console.WriteLine("\nDone.");
        }
    }
}
