using Source;

public class Def : Ast {

    public readonly string Name;
    public readonly Ast Value;

    public Def(string name, Ast value) {
        Name = name;
        Value = value;
    }

    public override object Eval(Context context) {
        var ret = Value.Eval(context);
        context.Define(Name, ret);
        return ret;
    }

}