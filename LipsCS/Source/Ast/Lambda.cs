using Source;

public class Lambda : Ast {

    public readonly string[] ParameterNames;
    public readonly Ast Body;

    public Lambda(string[] parameterNames, Ast body) {
        ParameterNames = parameterNames;
        Body = body;
    }

    public override object Eval(Context context) {
        return Body.Eval(context);
    }

}