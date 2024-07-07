namespace DSL2
{
    public class FunctionInline : AST
    {
        public string Name { get; }
        public List<string> Params { get; }
        public AST Body { get; }

        public FunctionInline(string name, List<string> paramss, AST body)
        {
            Name = name;
            Params = paramss;
            Body = body;
        }
        public override object Evaluate(Environment environment)
        {
            // Definimos una nueva función en el Environment.
            environment.FunctionDefinition(this);

            // La definición de una función no tiene un valor por sí misma, por lo que devolvemos null.
            return null;
        }
    }   
}