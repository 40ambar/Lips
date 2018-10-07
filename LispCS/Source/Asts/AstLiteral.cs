namespace Source.Asts {

    public class AstLiteral : Ast {

        private object value;

        public AstLiteral(object value) {
            this.value = value;
        }

        public override object Eval(Context context) {
            return value;
        }

    }

}