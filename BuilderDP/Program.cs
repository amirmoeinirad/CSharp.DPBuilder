
// Amir Moeini Rad
// September 2025

// Main Concept: Builder Design Pattern
// Help from Gemini

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
        void SetEngine(string engine);
        void SetColor(string color);
        void SetGPS(bool hasGPS);
        Car Build();
    }

    
    // Concrete Builder
    public class SportsCarBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public void SetEngine(string engine)
        {
            _car.Engine = engine;
        }

        public void SetColor(string color)
        {
            _car.Color = color;
        }

        public void SetGPS(bool hasGPS)
        {
            _car.HasGPS = hasGPS;
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
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Builder Design Pattern in C#.NET.");
            Console.WriteLine("---------------------------------\n");


            var carBuilder = new SportsCarBuilder();

            // Setting the properties step by step
            // Properties of the car object are set using various methods of the builder.
            // This pattern is useful when the object has lots of optional parameters or when the construction process is complex.
            // Using this pattern, we don't need to set the propeties in the constructor of the class.
            // Otherwise, we would have to create multiple constructors for different combinations of parameters.
            carBuilder.SetEngine("Electric");
            carBuilder.SetColor("Blue");
            carBuilder.SetGPS(false);

            // Finally, we call the Build method to get the constructed object.
            Car finalCar = carBuilder.Build();

            // Displaying the built car specifications
            finalCar.Display();


            Console.WriteLine("\nDone.");
        }
    }
}
