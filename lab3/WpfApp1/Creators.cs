using System.Windows.Media;

//абстрактный создатель для кругов
public abstract class CircleCreator
{
    public abstract Circle CreateCircle();
}

// Конкретные создатели для разных цветов
public class RedCircleCreator : CircleCreator
{
    public override Circle CreateCircle()
    {
        return new Circle { Color = Colors.Red };
    }
}

public class BlueCircleCreator : CircleCreator
{
    public override Circle CreateCircle()
    {
        return new Circle { Color = Colors.Blue };
    }
}

public class GreenCircleCreator : CircleCreator
{
    public override Circle CreateCircle()
    {
        return new Circle { Color = Colors.Green };
    }
}




// Абстрактный создатель для квадратов
public abstract class SquareCreator
{
    public abstract Square CreateSquare();
}

// Конкретные создатели для разных цветов
public class RedSquareCreator : SquareCreator
{
    public override Square CreateSquare()
    {
        return new Square { Color = Colors.Red };
    }
}

public class BlueSquareCreator : SquareCreator
{
    public override Square CreateSquare()
    {
        return new Square { Color = Colors.Blue };
    }
}

public class GreenSquareCreator : SquareCreator
{
    public override Square CreateSquare()
    {
        return new Square { Color = Colors.Green };
    }
}




// Абстрактный создатель для треугольников
public abstract class TriangleCreator
{
    public abstract Triangle CreateTriangle();
}

// Конкретные создатели для разных цветов
public class RedTriangleCreator : TriangleCreator
{
    public override Triangle CreateTriangle()
    {
        return new Triangle { Color = Colors.Red };
    }
}

public class BlueTriangleCreator : TriangleCreator
{
    public override Triangle CreateTriangle()
    {
        return new Triangle { Color = Colors.Blue };
    }
}

public class GreenTriangleCreator : TriangleCreator
{
    public override Triangle CreateTriangle()
    {
        return new Triangle { Color = Colors.Green };
    }
}