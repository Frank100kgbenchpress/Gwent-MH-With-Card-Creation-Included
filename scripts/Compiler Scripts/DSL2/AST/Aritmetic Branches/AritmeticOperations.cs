namespace DSL2
{
    public class AritmeticOperations : AST
    {
        public AST LeftOperator { get; }
        public AST RightOperator { get; }
        public string Operator { get; }

        public AritmeticOperations(AST leftOperator, AST rightOperator, string operators)
        {
            LeftOperator = leftOperator;
            RightOperator = rightOperator;
            Operator = operators;
        }

        public override object Evaluate(Environment environment)
        {
            
            double LeftValue = Convert.ToDouble(LeftOperator.Evaluate(environment));
            double RightValue = Convert.ToDouble(RightOperator.Evaluate(environment));            
            switch (Operator)
            {
                case "+":
                    return LeftValue + RightValue;
                case "-":
                    return LeftValue - RightValue;
                case "*":
                    return LeftValue * RightValue;
                case "%":
                    return LeftValue % RightValue;    
                case "^":
                    return Math.Pow(LeftValue,RightValue);   
                case "/":
                    if (RightValue != 0)
                    {
                        return LeftValue / RightValue;
                    }
                    else
                    {
                        throw new Exception("Error: Can not divide by 0.");
                    }
                default:
                    throw new Exception($"Error: Unknown Operator '{Operator}'.");
            }   
        }
    }
}