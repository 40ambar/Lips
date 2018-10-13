using Source;

public class Get : Ast {

    public readonly string Name;

    public Get(string name) {
        Name = name;
    }

    public override object Eval(Context context) {
        return context.Get(Name);
    }

}