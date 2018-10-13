using Source;

public class Variable : Ast {

    public readonly string Name;

    public Variable(string name) {
        Name = name;
    }

    public override object Eval(Context context) {
        return context.Get(Name);
    }

}