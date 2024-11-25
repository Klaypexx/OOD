namespace Lab2_1.Commands;

public abstract class Command
{
    public virtual void Execute() => throw new NotImplementedException();
}
