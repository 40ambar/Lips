using Source;

public class List : Ast {

    public readonly Ast[] Expressions;

    public List(params Ast[] expressions) {
        Expressions = expressions;
    }

    public override object Eval(Context context) {
        var ret = new object[Expressions.Length];
        for (var i = 0; i < Expressions.Length; i++) {
            ret[i] = Expressions[i].Eval(context);
        }
        return ret;
    }
}