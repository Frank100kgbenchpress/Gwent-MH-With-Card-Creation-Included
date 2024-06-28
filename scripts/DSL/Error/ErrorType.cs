namespace DSL
{
    /// <summary>
    /// Enumerates the types of errors that can occur during the execution of the interpreter.
    /// </summary>
    public enum ErrorType
    {
        LEXICAL,    // Lexical errors occur when the lexer encounters an invalid character
        SYNTAX,     // Syntax errors occur when the parser encounters an invalid token
        SEMANTIC    // Semantic errors occur when the evaluator encounters an invalid expression
    }
}