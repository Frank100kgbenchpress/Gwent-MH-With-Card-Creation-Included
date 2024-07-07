namespace DSL2
{
    public class LogicOperator : AST
    {   

        public AST LeftOperator { get; }
        public AST RightOperator { get; }
        public string Operator { get; }
        public LogicOperator(AST leftOperator, AST rightOperator, string operators)
        {
            LeftOperator = leftOperator;
            RightOperator = rightOperator;
            Operator = operators;
        }
        public override object Evaluate(Environment environment)
        {
            // Primero, evaluamos los operandos.
            var LeftValue = LeftOperator.Evaluate(environment);
            var RightValue = RightOperator.Evaluate(environment);
                // Luego, realizamos la operación lógica.
            switch (Operator)
            {
                case "==":
                    return Convert.ToDouble(LeftValue) == Convert.ToDouble(RightValue);
                case "!=":
                    return Convert.ToDouble(LeftValue) != Convert.ToDouble(RightValue);;
                case ">":
                    return Convert.ToDouble(LeftValue) > Convert.ToDouble(RightValue);
                case "<":
                    return Convert.ToDouble(LeftValue) < Convert.ToDouble(RightValue);
                case "&&":
                    return Convert.ToBoolean(LeftValue) && Convert.ToBoolean(RightValue);
                case "||":
                    return Convert.ToBoolean(LeftValue) || Convert.ToBoolean(RightValue);
                default:
                    throw new Exception($"Error: Operador desconocido '{Operator}'.");
            }
        }
    }
}