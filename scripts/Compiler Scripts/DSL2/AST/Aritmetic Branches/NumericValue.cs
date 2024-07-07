namespace DSL2
{
    public class NumericValue : AST
    {
        public int Value { get; }
        public NumericValue(int value)
        {
            Value = value;
        }
        public override object Evaluate(Environment environment)
        {
            return Value;
        }
    }  
}