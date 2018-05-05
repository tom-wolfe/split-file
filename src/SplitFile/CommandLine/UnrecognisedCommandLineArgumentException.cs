using System;
using System.Runtime.Serialization;

namespace SplitFile.CommandLine {
    /// <summary>
    /// Represents errors that occur when an unrecognised argument name is specified.
    /// </summary>
    [Serializable]
    public class UnrecognisedCommandLineArgumentException : CommandLineArgumentException {
        #region -  Constructors  -

            /// <summary>
            /// Initializes a new instance of the <see cref="UnrecognisedCommandLineArgumentException"/> class.
            /// </summary>
            public UnrecognisedCommandLineArgumentException()
                : base("The name of an unrecognised argument was discovered while parsing.") {}

            /// <summary>
            /// Initializes a new instance of the <see cref="UnrecognisedCommandLineArgumentException"/> class with a specified error message.
            /// </summary>
            /// <param name="message">The message that describes the error.</param>
            public UnrecognisedCommandLineArgumentException(string message) : base(message) { }

            /// <summary>
            /// Initializes a new instance of the <see cref="UnrecognisedCommandLineArgumentException"/> class with serialized data.
            /// </summary>
            /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
            /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
            protected UnrecognisedCommandLineArgumentException(SerializationInfo info, StreamingContext context)
                : base(info, context) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="UnrecognisedCommandLineArgumentException"/> class with a specified error message 
            /// and a reference to the inner exception that is the cause of this exception.
            /// </summary>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
            public UnrecognisedCommandLineArgumentException(string message, Exception innerException)
                : base(message, innerException) {}

        #endregion
    }
}