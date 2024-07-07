namespace DSL2
{
    public class VariableDeclaration : AST
    {
        public string Name { get; }
        public AST InitialValue { get; }
        public VariableDeclaration(string name, AST initialValue)
        {
            Name = name;
            InitialValue = initialValue;
        }
        public override object Evaluate(Environment environment)
        {
            // Primero, evaluamos el valor inicial de la variable.
            var value = InitialValue.Evaluate(environment);

            // Luego, definimos una nueva variable en el Environment con el Name y el valor inicial.
            environment.VariableDefinition(new Variable(Name, value));

            // La declaración de una variable no tiene un valor por sí misma, por lo que devolvemos null.
            return null;
        }    
    }   
}