namespace DSL2
{
    public class IfElseExpression : AST
    {
        public AST Condition { get; }
        public AST ExpressionIf { get; }
        public AST ExpressionElse { get; }

        public IfElseExpression(AST condition, AST expressionIf, AST expressionElse)
        {
            Condition = condition;
            ExpressionIf = expressionIf;
            ExpressionElse = expressionElse;
        }

        public override object Evaluate(Environment Environment)
        {
            // Primero, evaluamos la condición.
            bool condition = Convert.ToBoolean(Condition.Evaluate(Environment));

            // Luego, en función del valor de la condición, evaluamos y devolvemos el resultado de ExpresionIf o ExpresionElse.
            if (condition)
            {
                return ExpressionIf.Evaluate(Environment);
            }
            else
            {
                return ExpressionElse.Evaluate(Environment);
            }
        }
    }   
}