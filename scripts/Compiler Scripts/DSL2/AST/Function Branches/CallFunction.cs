namespace DSL2
{
    public class CallFunction : AST
    {
        public string Name { get; }
        public List<AST> Arguments { get; }

        public CallFunction(string name, List<AST> arguments)
        {
            Name = name;
            Arguments = arguments;
        }
        public override object Evaluate(Environment environment)
        {
            // Buscamos la definición de la función en el Environment.
            var function = environment.FindFunction(Name);
            if (function == null)
            {
                throw new Exception($"Error: Undefined Function '{Name}'.");
            }

            // Creamos un nuevo Environment para la llamada a la función.
            var EnvironmentFunction = new Environment();
            // Evaluamos los argumentos y los definimos en el Environment de la función.
            for (int i = 0; i < Arguments.Count; i++)
            {
                var value = Arguments[i].Evaluate(environment);
                var variable = new Variable(function.Params[i], value);
                EnvironmentFunction.VariableDefinition(variable);
            }

            // Evaluamos el cuerpo de la función en el Environment de la función y devolvemos el resultado.
            return function.Body.Evaluate(EnvironmentFunction);
        } 

    }    
}