// Product
public class Car
{
    public string? Engine { get; set; }
    public int Seats { get; set; }
    public string? Color { get; set; }

    public override string ToString()
    {
        return $"Car [Engine: {Engine}, Seats: {Seats}, Color: {Color}]";
    }
}

// Builder Interface
public interface ICarBuilder
{
    ICarBuilder SetEngine(string engine);
    ICarBuilder SetSeats(int seats);
    ICarBuilder SetColor(string color);
    Car Build();
}

// Abstract Builder (Optional - for shared behavior)
public abstract class CarBuilder : ICarBuilder
{
    protected Car _car = new Car();

    public abstract ICarBuilder SetEngine(string engine);
    public abstract ICarBuilder SetSeats(int seats);
    public abstract ICarBuilder SetColor(string color);

    public Car Build()
    {
        return _car;
    }
}

// Concrete Builder for Sports Car
public class SportsCarBuilder : CarBuilder
{
    public override ICarBuilder SetEngine(string engine)
    {
        _car.Engine = engine;
        return this;
    }

    public override ICarBuilder SetSeats(int seats)
    {
        _car.Seats = seats;
        return this;
    }

    public override ICarBuilder SetColor(string color)
    {
        _car.Color = color;
        return this;
    }
}

// Concrete Builder for SUV
public class SUVCarBuilder : CarBuilder
{
    public override ICarBuilder SetEngine(string engine)
    {
        _car.Engine = engine;
        return this;
    }

    public override ICarBuilder SetSeats(int seats)
    {
        _car.Seats = seats;
        return this;
    }

    public override ICarBuilder SetColor(string color)
    {
        _car.Color = color;
        return this;
    }
}


// Director
public class CarDirector
{
    public Car ConstructSportsCar(ICarBuilder builder)
    {
        return builder.SetEngine("V8 Engine")
                .SetSeats(2)
                .SetColor("Black")
                .Build();
    }

    public Car ConstructSUVCar(ICarBuilder builder)
    {
        return builder.SetEngine("Turbo Diesel")
                 .SetSeats(4)
                 .SetColor("Red")
                 .Build();
    }
}

// Usage
class Program
{
    static void Main(string[] args)
    {
        CarDirector director = new CarDirector();

        ICarBuilder builderSportCar = new SportsCarBuilder();
        ICarBuilder builderSUVCar = new SUVCarBuilder();

        Car sportCar = director.ConstructSportsCar(builderSportCar);

        Car SUVCar = director.ConstructSUVCar(builderSUVCar);

        Console.WriteLine(sportCar);

        Console.WriteLine(SUVCar);
    }
}
