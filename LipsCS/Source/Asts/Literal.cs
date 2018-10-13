using Source;

public class Literal : Ast {

    public readonly object Value;

    public Literal(object value) {
        Value = value;
    }

    public override object Eval(Context context) {
        return Value;
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

}