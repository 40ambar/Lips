namespace Source.Asts {

    public class AstSet : Ast {

        private AstVariable Variable;
        private Ast Value;

        public AstSet(AstVariable variable, Ast value) {
            Variable = variable;
            Value = value;
        }

        public override object Eval(Context context) {
            return context.Set(
                Variable.name,
                Value.Eval(context)
            );
        }

    }

}