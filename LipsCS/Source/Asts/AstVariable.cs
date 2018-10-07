namespace Source.Asts {

    public class AstVariable : Ast {

        public readonly string Name;

        public AstVariable(string name) {
            Name = name;
        }

        public override object Eval(Context context) {
            return context.Get(Name);
        }

    }

}