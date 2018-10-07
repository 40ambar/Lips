namespace Source.Asts {

    public class AstDec : Ast {

        private AstVariable Value;

        public AstDec(AstVariable value) {
            Value = value;
        }

        public override object Eval(Context context) {
            var ret = (double)Value.Eval(context);
            context.Set(Value.name, ret - 1);
            return ret;
        }

    }

}
