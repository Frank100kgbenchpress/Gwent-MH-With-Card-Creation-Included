namespace DSL2
{
    public class Environment
    {
        Dictionary<string, Variable> variables = new Dictionary<string, Variable>();

        public void VariableDefinition(Variable variable)
        {
            variables[variable.Name] = variable;
        }

        public Variable FindVariable(string name)
        {
            if (variables.TryGetValue(name, out var variable))
            {
                return variable;
            }
            else
            {
                return null;
            }
        }

        Dictionary<string, FunctionInline> functions = new Dictionary<string, FunctionInline>();

        public void FunctionDefinition(FunctionInline function)
        {
            functions[function.Name] = function;
        }

        public FunctionInline FindFunction(string name)
        {
            if (functions.TryGetValue(name, out var funcion))
            {
                return funcion;
            }
            else
            {
                return null;
            }
        }    
    }   
}