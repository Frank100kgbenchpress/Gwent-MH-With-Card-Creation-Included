using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL2
{
    /// <summary>
    /// Represents a token in the source code.
    /// </summary>
    public class Token
    {
        public TokenType Type { get; }  // The type of the token
        public string Lexeme { get; }   // The lexeme of the token
        public Token(TokenType type, string lexeme)
        {
            Type = type;
            Lexeme = lexeme;
        }
    }
}