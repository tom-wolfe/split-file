using System;
using System.Runtime.Serialization;

namespace SplitFile.CommandLine {
    /// <summary>
    /// Represents errors that occur when a required command-line argument is omitted.
    /// </summary>
    [Serializable]
    public class MissingRequiredCommandLineArgumentException : CommandLineArgumentException {
        #region -  Constructors  -

            /// <summary>
            /// Initializes a new instance of the <see cref="MissingRequiredCommandLineArgumentException"/> class.
            /// </summary>
            public MissingRequiredCommandLineArgumentException()
                : base("A required command-line argument was omitted.") { }

            /// <summary>
            /// Initializes a new instance of the <see cref="MissingRequiredCommandLineArgumentException"/> class with a specified error message.
            /// </summary>
            /// <param name="message">The message that describes the error.</param>
            public MissingRequiredCommandLineArgumentException(string message) : base(message) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="MissingRequiredCommandLineArgumentException"/> class with a specified error message.
            /// </summary>
            /// <param name="item">The duplicate item that was encountered.</param>
            public MissingRequiredCommandLineArgumentException(CommandLineArgument item)
                : base(string.Format("A required command-line argument with the short name '{0}' or long name '{1}' was omitted.", item.ShortName, item.LongName)) { }

            /// <summary>
            /// Initializes a new instance of the <see cref="MissingRequiredCommandLineArgumentException"/> class with serialized data.
            /// </summary>
            /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
            /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
            protected MissingRequiredCommandLineArgumentException(SerializationInfo info, StreamingContext context)
                : base(info, context) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="MissingRequiredCommandLineArgumentException"/> class with a specified error message 
            /// and a reference to the inner exception that is the cause of this exception.
            /// </summary>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
            public MissingRequiredCommandLineArgumentException(string message, Exception innerException)
                : base(message, innerException) {}

        #endregion
    }
}