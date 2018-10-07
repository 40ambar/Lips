namespace Source.Asts {

    public class AstIf : Ast {

        private Ast Condition;
        private Ast TrueValue;
        private Ast FalseValue;

        public AstIf(Ast condition, Ast trueValue, Ast falseValue) {
            Condition = condition;
            TrueValue = trueValue;
            FalseValue = falseValue;
        }

        public override object Eval(Context context) {
            if ((bool)Condition.Eval(context)) {
                return TrueValue.Eval(context);
            }
            else {
                return FalseValue.Eval(context);
            }
        }

    }

}