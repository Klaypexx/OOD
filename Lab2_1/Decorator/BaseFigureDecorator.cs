namespace Lab2_1.Decorator;

public class BaseFigureDecorator
{
    public virtual string GetDescription() => throw new NotImplementedException();

    public virtual float GetPerimeter() => throw new NotImplementedException();

    public virtual float GetArea() => throw new NotImplementedException();
}
