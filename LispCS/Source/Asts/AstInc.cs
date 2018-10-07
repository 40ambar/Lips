namespace Source.Asts {

    public class AstInc : Ast {

        public AstVariable value;

        public AstInc(AstVariable value) {
            this.value = value;
        }

        public override object Eval(Context context) {
            var ret = (double)value.Eval(context);
            context.Set(value.name, ret + 1);
            return ret;
        }

    }

}