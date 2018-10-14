using Source;
using System;

public class Lambda : Ast {

    public readonly string[] ParameterNames;
    public readonly Ast Body;

    public Lambda(string[] parameterNames, Ast body) {
        ParameterNames = parameterNames;
        Body = body;
    }

    public override object Eval(Context context) {
        return new Func<object[], object>(arguments => {
            var funcContext = context.Extend();
            for (var i = 0; i < arguments.Length; i++) {
                funcContext.Define(
                    ParameterNames[i],
                    arguments[i]
                );
            }
            return Body.Eval(funcContext);
        });
    }

}