namespace Source.Asts {

    public class AstSet : Ast {

        private AstVariable variable;
        private Ast value;

        public AstSet(AstVariable variable, Ast value) {
            this.value = value;
        }

        public override object Eval(Context context) {
            return context.Set(
                variable.name,
                variable.Eval(context)
            );
        }

    }

}