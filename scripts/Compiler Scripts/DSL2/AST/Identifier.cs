namespace DSL2
{
    public class Identifier : AST
    {
        public string Name { get; }
        public Identifier(string name)
        {
            Name = name;
        }
        public override object Evaluate(Environment Environment)
        {
            // Buscamos el valor actual del Identifier en el Environment.
            var variable = Environment.FindVariable(Name);
            if (variable != null)
            {
                // Si la variable existe, devolvemos su valor.
                return variable.Value;
            }
            else
            {
                // Si la variable no existe, lanzamos una excepción.
                throw new Exception($"Error: Variable no definida '{Name}'.");
            }
        }
    }   
}