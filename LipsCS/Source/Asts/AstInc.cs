namespace Source.Asts {

    public class AstInc : Ast {

        private AstVariable Value;

        public AstInc(AstVariable value) {
            Value = value;
        }

        public override object Eval(Context context) {
            var ret = (double)Value.Eval(context);
            context.Set(Value.name, ret + 1);
            return ret;
        }

    }

}