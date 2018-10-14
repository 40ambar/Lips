using Source;
using System;

//(f args..)
public class Call : Ast {

    public readonly Ast Function; //eval yapınca c# fonksiyonu gelecek
    public readonly Ast[] ParametersValues;

    public Call(Ast function, params Ast[] parametersValues) {
        Function = function;
        ParametersValues = parametersValues;
    }

    public override object Eval(Context context) {

        //evaluated parameters
        var evaluatedParameters = new object[ParametersValues.Length];
        for (var i = 0; i < ParametersValues.Length; i++) {
            evaluatedParameters[i] = ParametersValues[i].Eval(context);
        }

        //get function
        var func = (Delegate)Function.Eval(context);

        //internal
        if (Function is Lambda) {
            return func.DynamicInvoke(new[] { evaluatedParameters });
        }

        //external
        else {
            return func.DynamicInvoke(evaluatedParameters);
        }

    }

}