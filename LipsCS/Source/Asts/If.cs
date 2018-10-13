using Source;

public class If : Ast {

    public readonly Ast Condition;
    public readonly Ast TrueAst;
    public readonly Ast FalseAst;

    public If(Ast condition, Ast trueAst, Ast falseAst) {
        Condition = condition;
        TrueAst = trueAst;
        FalseAst = falseAst;
    }

    public override object Eval(Context context) {
        if ((bool)Condition.Eval(context)) {
            return TrueAst.Eval(context);
        }
        else {
            return FalseAst.Eval(context);
        }
    }

}