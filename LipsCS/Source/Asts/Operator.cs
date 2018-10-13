using Source;

public class Operator : Ast {

    public readonly string Op;
    public readonly Ast Left;
    public readonly Ast Right;

    public Operator(string op, Ast left, Ast right = null) {
        Op = op;
        Left = left;
        Right = right;
    }

    public override object Eval(Context context) {
        switch (Op) {
            case "++": {
                    var variable = (Variable)Left;
                    var value = (double)variable.Eval(context);
                    context.Set(variable.Name, value + 1);
                    return value;
                }
            case "--": {
                    var variable = (Variable)Left;
                    var value = (double)variable.Eval(context);
                    context.Set(variable.Name, value + 1);
                    return value;
                }
            case "+": return (double)Left.Eval(context) + (double)Right.Eval(context);
            case "-": return (double)Left.Eval(context) - (double)Right.Eval(context);
            case "*": return (double)Left.Eval(context) * (double)Right.Eval(context);
            case "/": return (double)Left.Eval(context) / (double)Right.Eval(context);
            case "<": return (double)Left.Eval(context) < (double)Right.Eval(context);
            case ">": return (double)Left.Eval(context) > (double)Right.Eval(context);
            default: return 0;
        }
    }

}