namespace Source.Asts {

    public class AstVariable : Ast {

        public readonly string name;

        public AstVariable(string name) {
            this.name = name;
        }

        public override object Eval(Context context) {
            return context.Get(name);
        }

    }

}