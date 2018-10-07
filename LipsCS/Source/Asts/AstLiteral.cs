namespace Source.Asts {

    public class AstLiteral : Ast {

        private object Value;

        public AstLiteral(object value) {
            Value = value;
        }

        public override object Eval(Context context) {
            return Value;
        }

    }

}