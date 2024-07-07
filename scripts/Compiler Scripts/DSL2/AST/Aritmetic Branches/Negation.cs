namespace DSL2
{
    public class Negation : AST
    {
        AST Subexpression;
        public Negation(AST subexpression)
        {
            Subexpression = subexpression;
        }

        public override object Evaluate(Environment environment)
        {
            // Primero evaluamos la subexpresión.
            object value = Subexpression.Evaluate(environment);

            // Luego, comprobamos que el valor sea un número.
            if (value is int)
            {
                // Si es un int, lo convertimos a double y luego lo negamos.
                return - Convert.ToDouble(value);
            }
            else if (value is double)
            {
                // Si ya es un double, simplemente lo negamos.
                return - (double)value;
            }
            else
            {
                // Si no es un número, lanzamos una excepción.
                throw new Exception("Error: Can not deny a non-numeric value.");
            }
        }
    }   
}