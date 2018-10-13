using Source;
using System.Collections;

public class For : Ast {

    public readonly string Variable;
    public readonly Ast From;
    public readonly Ast To;
    public readonly Ast Step;
    public readonly Ast Body;

    public For(string variable, Ast from, Ast to, Ast step, Ast body) {
        Variable = variable;
        From = from;
        To = to;
        Step = step;
        Body = body;
    }

    public override object Eval(Context context) {
        var ret = new ArrayList();
        var from = (double)From.Eval(context);
        var to = (double)To.Eval(context);
        var step = (double)Step.Eval(context);
        context.Define(Variable, from);
        for (var i = from; i <= to; i += step) {
            context.Set(Variable, i);
            ret.Add(Body.Eval(context));
        }
        return ret.ToArray();
    }

}