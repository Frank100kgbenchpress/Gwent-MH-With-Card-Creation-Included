namespace DSL2
{
    public class PrintExpression : AST
    {
        public AST Expression { get; }

        public PrintExpression(AST expression)
        {
            Expression = expression;
        }

        public override object Evaluate(Environment environment)
        {
            // Evaluamos la expresión y la convertimos en una cadena.
            var value = Expression.Evaluate(environment);
            return value.ToString();
        }
    }   
}