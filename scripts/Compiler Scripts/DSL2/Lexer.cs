using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
namespace DSL2
{
    public class Lexer
    {
        string SourceCode;
        int CurrentPosition;
        List<string> diagnostics = new();
        Dictionary <string, TokenType> Keywords = new Dictionary<string, TokenType>
        {
            {"function", TokenType.FUNCTION},
            {"if", TokenType.IF},
            {"else", TokenType.ELSE},
            {"true", TokenType.BOOLEAN},
            {"false", TokenType.BOOLEAN},
            {"Card", TokenType.CARD},
            {"Effect", TokenType.EFFECT},
            { "Params", TokenType.PARAMS },
            { "Action", TokenType.ACTION},
            { "TriggerPlayer", TokenType.TRIGGERPLAYER},
            { "Board",TokenType.BOARD },
            { "HandOfPlayer", TokenType.HANDOFPLAYER},
            { "Hand", TokenType.HAND  },
            { "FieldOfPlayer", TokenType.FIELDOFPLAYER },
            { "Field",  TokenType.FIELD},
            { "GraveyardOfPlayer", TokenType.GRAVEYARDOFPLAYER },
            { "Graveyard", TokenType.GRAVEYARD },
            { "DeckOfPlayer", TokenType.DECKOFPLAYER},
            { "Find", TokenType.FIND },
            { "Push", TokenType.PUSH },
            { "SendBottom", TokenType.SENDBOTTOM },
            { "Pop", TokenType.POP },
            { "Remove", TokenType.REMOVE},
            { "Shuffle", TokenType.SHUFFLE},
            { "Type",  TokenType.TYPE},
            { "Faction", TokenType.FACTION},
            { "Attack", TokenType.ATTACK },
            { "Range", TokenType.RANGE},
            { "OnActivation", TokenType.ONACTIVATION },
            { "Selector",  TokenType.SELECTOR},
            { "Source",  TokenType.SOURCE},
            { "Single", TokenType.SINGLE},
            { "Predicate", TokenType.PREDICATE },
            { "PostAction", TokenType.POSTACTION},
            { "Melee" , TokenType.MELEE},
            {"Ranged" , TokenType.RANGED},
            {"Siege" , TokenType.SIEGE}
        };
        public Lexer(string sourceCode)
        {
            SourceCode = sourceCode;
            CurrentPosition = 0;
        }

        public List<Token> GetTokens()
        {
            List<Token> tokens = new();

            while (NotEnd() )
            {
                char actualChar = SourceCode[CurrentPosition];
                // ignore whitespace
                if (actualChar == ' ' || actualChar == '\n' || actualChar == '\r')
                {
                    CurrentPosition++;
                    continue;
                }
                
                // scan separators
                if (actualChar == '('  )
                {
                    tokens.Add(new Token(TokenType.LEFT_PAREN, actualChar.ToString()));
                    CurrentPosition++;
                    continue;
                }
                if ( actualChar == ')' )
                {
                    tokens.Add(new Token(TokenType.RIGHT_PAREN, actualChar.ToString()));
                    CurrentPosition++;
                    continue;
                }

                if ( actualChar == '"')
                {
                    tokens.Add(new Token(TokenType.QUOTATIONMARKS, actualChar.ToString()));
                    CurrentPosition++;
                    continue;
                }

                if ( actualChar == ';' )
                {
                    tokens.Add(new Token(TokenType.SEMICOLON, actualChar.ToString()));
                    CurrentPosition++;
                    continue;
                }
                if ( actualChar == ',' )
                {
                    tokens.Add(new Token(TokenType.COMMA, actualChar.ToString()));
                    CurrentPosition++;
                    continue;
                }

                // scan numbers
                if (char.IsDigit(actualChar))
                {
                    string number = "";
                    while (NotEnd() && char.IsDigit(SourceCode[CurrentPosition]))
                    {
                        number += SourceCode[CurrentPosition];
                        CurrentPosition++;
                    }
                    tokens.Add(new Token(TokenType.NUMBER, number));
                    continue;
                }

                // identifiers and keywords
                if (char.IsLetter(actualChar) || actualChar == '_')
                {
                    string word = "";
                    while (NotEnd()&& (char.IsLetterOrDigit(SourceCode[CurrentPosition]) || SourceCode[CurrentPosition] == '_'))
                    {
                        word += SourceCode[CurrentPosition];
                        CurrentPosition++;
                    }

                    if (Keywords.ContainsKey(word))
                    {
                        tokens.Add(new Token(Keywords[word], word));
                    }
                /* else if (Math.ContainsKey(word))
                    {
                        tokens.Add(new Token(Math[word], word));
                    }/*/
                    else
                    {
                        tokens.Add(new Token(TokenType.IDENTIFIER, word));
                    }
                    continue;
                }

                // Detectar operadores aritméticos
                if(actualChar == '+')
                {
                    tokens.Add(new Token(TokenType.PLUS, actualChar.ToString()));
                    CurrentPosition++;
                    continue; 
                }
                if(actualChar == '-')
                {
                    tokens.Add(new Token(TokenType.MINUS, actualChar.ToString()));
                    CurrentPosition++;
                    continue; 
                }
                if(actualChar == '*')
                {
                    tokens.Add(new Token(TokenType.MULTIPLY, actualChar.ToString()));
                    CurrentPosition++;
                    continue; 
                }
                if(actualChar == '^')
                {
                    tokens.Add(new Token(TokenType.POWER, actualChar.ToString()));
                    CurrentPosition++;
                    continue; 
                }
                if(actualChar == '&')
                {
                    tokens.Add(new Token(TokenType.MODULUS, actualChar.ToString()));
                    CurrentPosition++;
                    continue; 
                }
                if(actualChar == '/')
                {
                    tokens.Add(new Token(TokenType.DIVIDE, actualChar.ToString()));
                    CurrentPosition++;
                    continue; 
                }
                // Scan Logical Operators
                if (actualChar == '>')
                {
                    tokens.Add(new Token(TokenType.GREATER, actualChar.ToString()));
                    CurrentPosition++;
                    continue; 
                }
                if (actualChar == '<')
                {
                    tokens.Add(new Token(TokenType.LESS, actualChar.ToString()));
                    CurrentPosition++;
                    continue; 
                } 
                if (actualChar == '=')
                {
                    if (CurrentPosition + 1 < SourceCode.Length && SourceCode[CurrentPosition + 1] == '=')
                        {  
                            tokens.Add(new Token(TokenType.EQUAL, "=="));
                            CurrentPosition += 2;
                            continue;
                        }

                    else if (CurrentPosition + 1 < SourceCode.Length && SourceCode[CurrentPosition + 1] == '>')
                        {  
                            tokens.Add(new Token(TokenType.LAMBDA, "=>"));
                            CurrentPosition += 2;
                            continue;
                        }    
                        else
                    {
                        tokens.Add(new Token(TokenType.ASSIGN, "="));
                        CurrentPosition++;
                        continue;
                    }
                }
                if (actualChar == '!')
                {
                    if (CurrentPosition + 1 < SourceCode.Length && SourceCode[CurrentPosition + 1] == '=')
                        {  
                            tokens.Add(new Token(TokenType.NOT_EQUAL, "!="));
                            CurrentPosition += 2;
                            continue;
                        }
                        else
                    {
                        tokens.Add(new Token(TokenType.UNKNOWN, actualChar.ToString()));        
                        // Si no se reconoce el carácter, generar error léxico 
                        diagnostics.Add("Non nkown char at "+ CurrentPosition);
                        CurrentPosition++;
                        continue;
                    }
                }
                tokens.Add(new Token(TokenType.UNKNOWN, actualChar.ToString()));        
                // Si no se reconoce el carácter, generar error léxico 
                diagnostics.Add("Caracter desconocido en : "+ CurrentPosition);
                CurrentPosition++;
            }      
            return tokens;     
        }
        bool NotEnd()
        {
            return CurrentPosition < SourceCode.Length;
        }  
    }
}
