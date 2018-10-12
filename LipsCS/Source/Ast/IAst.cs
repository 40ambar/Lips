
using Source;

public interface IAst
{
    Value Eval(Context context);
}

public abstract class Value : IAst
{
    public Value Eval(Context context)
    {
        return this;
    }
}

public class Number : Value {
    public readonly double Value;

    public Number(double value) {
        Value = value;
    }

    public override bool Equals(object value){
        var other = value as Number;
        return other.Value == Value;
    }
}