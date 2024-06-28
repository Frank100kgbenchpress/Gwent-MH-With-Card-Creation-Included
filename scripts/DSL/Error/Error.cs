using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL
{
    /// <summary>
    /// Represents an error that occurs during the execution of the interpreter.
    /// </summary>
    public class Error : Exception
    {
        public string Message { get; private set; }         // The error message
        public ErrorType ErrorType { get; private set; }    // The type of the error
        public Error(ErrorType errorType, string message): base(message)
        {
            ErrorType = errorType;
            Message = message;
        }
        /// <summary>
        /// Returns a string representation of the error.
        /// </summary>
        public string Report()
        {
            return $"! {ErrorType} ERROR: {Message}";
        }
    }
}