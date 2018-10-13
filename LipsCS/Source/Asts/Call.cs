using Source;

public class Call : Ast {

    public readonly Lambda Function;
    public readonly Ast[] ParametersValues;

    public Call(Lambda function, params Ast[] parametersValues) {
        Function = function;
        ParametersValues = parametersValues;
    }

    public override object Eval(Context context) {
        var funcContext = context.Extend();
        for (var i = 0; i < ParametersValues.Length; i++) {
            funcContext.Define(
                Function.ParameterNames[i],
                ParametersValues[i].Eval(context)
            );
        }
        return Function.Eval(funcContext);
    }

}