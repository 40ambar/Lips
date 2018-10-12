using Source;

public class Set : Ast {

    public readonly string Name;
    public readonly Ast Value;

    public Set(string name, Ast value) {
        Name = name;
        Value = value;
    }

    public override object Eval(Context context) {
        var ret = Value.Eval(context);
        context.Set(Name, ret);
        return ret;
    }

}