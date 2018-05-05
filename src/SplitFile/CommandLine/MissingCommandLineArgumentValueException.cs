using System;
using System.Runtime.Serialization;

namespace SplitFile.CommandLine {
    /// <summary>
    /// Represents errors that occur when a command-line argument value is omitted.
    /// </summary>
    [Serializable]
    public class MissingCommandLineArgumentValueException : CommandLineArgumentException {
        #region -  Constructors  -

            /// <summary>
            /// Initializes a new instance of the <see cref="MissingCommandLineArgumentValueException"/> class.
            /// </summary>
            public MissingCommandLineArgumentValueException()
                : base("The value for a command-line argument that requires a value was omitted.") { }

            /// <summary>
            /// Initializes a new instance of the <see cref="MissingCommandLineArgumentValueException"/> class with a specified error message.
            /// </summary>
            /// <param name="message">The message that describes the error.</param>
            public MissingCommandLineArgumentValueException(string message) : base(message) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="MissingCommandLineArgumentValueException"/> class with a specified error message.
            /// </summary>
            /// <param name="item">The duplicate item that was encountered.</param>
            public MissingCommandLineArgumentValueException(CommandLineArgument item)
                : base(string.Format("A value for the command-line argument with the short name '{0}' or long name '{1}' was omitted.", item.ShortName, item.LongName)) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="MissingCommandLineArgumentValueException"/> class with serialized data.
            /// </summary>
            /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
            /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
            protected MissingCommandLineArgumentValueException(SerializationInfo info, StreamingContext context)
                : base(info, context) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="MissingCommandLineArgumentValueException"/> class with a specified error message 
            /// and a reference to the inner exception that is the cause of this exception.
            /// </summary>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
            public MissingCommandLineArgumentValueException(string message, Exception innerException)
                : base(message, innerException) {}

        #endregion
    }
}