using Source;

public abstract class Ast{

    public abstract object Eval(Context context);

    public override bool Equals(object other) {
        return GetHashCode() == other.GetHashCode();
    }

    public override int GetHashCode() {
        return base.GetHashCode();
    }

}