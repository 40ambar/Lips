namespace Source.Asts {

    public class AstIf : Ast {

        private Ast condition;
        private Ast trueValue;
        private Ast falseValue;

        public AstIf(Ast condition, Ast trueValue, Ast falseValue) {
            this.condition = condition;
            this.trueValue = trueValue;
            this.falseValue = falseValue;
        }

        public override object Eval(Context context) {
            if ((bool)condition.Eval(context)) {
                return trueValue.Eval(context);
            }
            else {
                return falseValue.Eval(context);
            }
        }

    }

}