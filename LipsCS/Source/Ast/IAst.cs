
using Source;

public abstract class Ast
{
    public abstract object Eval(Context context);

    public override bool Equals(object other) {
        return this.GetHashCode() == other.GetHashCode();
    }
}

public class Literal : Ast {
    public readonly object Value;

    public Literal(object value) {
        Value = value;
    }

    public override object Eval(Context context){
        return Value;
    }

    public override int GetHashCode(){
        return Value.GetHashCode();
    }
}

public class Operator : Ast
{
    public readonly string Op;
    public readonly Ast Left;
    public readonly Ast Right;

    public Operator(string op, Ast left, Ast right = null){
        Op = op;
        Left = left;
        Right = right;
    }

    public override object Eval(Context context) {
        if(Op == "+"){
            return  (double)Left.Eval(context) + (double)Right.Eval(context);
        }
        else if(Op == "-"){
            return  (double)Left.Eval(context) - (double)Right.Eval(context);
        }
        return 0;
    }
}

public class Variable : Ast {
    public readonly string Name;
    public Variable(string name){
        Name = name;
    }
    public override object Eval(Context context){
        return context.Get(Name);
    }
}

public class If : Ast {
    public readonly Ast Condition;
    public readonly Ast TrueAst;
    public readonly Ast FalseAst;

    public If(Ast condition, Ast trueAst, Ast falseAst){
        Condition = condition;
        TrueAst = trueAst;
        FalseAst = falseAst;
    }

    public override object Eval(Context context) {
        if((bool)Condition.Eval(context)) { 
            return TrueAst.Eval(context);
        } 
        else {
            return FalseAst.Eval(context);
        }
    }
}


/// <summary>
/// Lambda: (call-lambda (lambda (x  y) (* x y)) 4 5) => 20
/// (x, y) => x * y
/// function a(x, y) { return x * y; }
/// (a b(1,3) 5) => 20
/// </summary>
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

public class Call : Ast {
    public readonly Lambda Function;
    public readonly Ast[] ParametersValues;
    
    public Call(Lambda function, params Ast[] parametersValues){
        Function = function;
        ParametersValues = parametersValues;
    }

    public override object Eval(Context context) {
        var funcContext = context.Extend();
        for(var i = 0; i < ParametersValues.Length; i++){
            funcContext.Define(Function.ParameterNames[i], ParametersValues[i].Eval(context));
        }
        return Function.Eval(funcContext);
    }
}
