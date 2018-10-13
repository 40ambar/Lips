using Source;
using System.Collections;

public class While : Ast {

    public readonly Ast Condition;
    public readonly Ast Body;

    public While(Ast condition, Ast body) {
        Condition = condition;
        Body = body;
    }

    public override object Eval(Context context) {
        var ret = new ArrayList();
        while ((bool)Condition.Eval(context)) {
            ret.Add(Body.Eval(context));
        }
        return ret.ToArray();
    }

}