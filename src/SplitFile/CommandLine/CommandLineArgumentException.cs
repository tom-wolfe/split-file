using System;
using System.Runtime.Serialization;

namespace SplitFile.CommandLine {
    /// <summary>
    /// Represents errors that occur during command-line argument parsing.
    /// </summary>
    [Serializable]
    public abstract class CommandLineArgumentException : Exception {
        #region -  Constructors  -

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineArgumentException"/> class.
        /// </summary>
        protected CommandLineArgumentException()
            : base("An error was encountered while parsing the command-line arguments.") {}

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineArgumentException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the exception.</param>
        protected CommandLineArgumentException(string message) : base(message) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineArgumentException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected CommandLineArgumentException(SerializationInfo info, StreamingContext context)
            : base(info, context) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineArgumentException"/> class with a specified error message 
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        protected CommandLineArgumentException(string message, Exception innerException) : base(message, innerException) {}

        #endregion
    }
}