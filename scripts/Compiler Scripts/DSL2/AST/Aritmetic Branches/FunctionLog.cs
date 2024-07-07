namespace DSL2
{
    public class FunctionLog : AST
    {
        public AST Argument { get; }
        public FunctionLog(AST argument)
        {
            Argument = argument;
        }

        public override object Evaluate(Environment environment)
        {
            // Primero, evaluamos el argumento.
            double argumentValue = Convert.ToDouble(Argument.Evaluate(environment));

            // Luego, calculamos y devolvemos el logaritmo del argumento.
            return Math.Log(argumentValue);
        }
    }   
}