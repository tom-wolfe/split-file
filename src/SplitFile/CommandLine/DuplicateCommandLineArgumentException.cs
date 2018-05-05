using System;
using System.Runtime.Serialization;

namespace SplitFile.CommandLine {
    /// <summary>
    /// Represents errors that occur when a duplicate command-line argument is discovered.
    /// </summary>
    [Serializable]
    public class DuplicateCommandLineArgumentException : CommandLineArgumentException {
        #region -  Constructors  -

            /// <summary>
            /// Initializes a new instance of the <see cref="DuplicateCommandLineArgumentException"/> class.
            /// </summary>
            public DuplicateCommandLineArgumentException()
                : base("A duplicate command-line argument was discovered while parsing.") {}

            /// <summary>
            /// Initializes a new instance of the <see cref="DuplicateCommandLineArgumentException"/> class with a specified error message.
            /// </summary>
            /// <param name="message">The message that describes the error.</param>
            public DuplicateCommandLineArgumentException(string message) : base(message) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="DuplicateCommandLineArgumentException"/> class with a specified error message.
            /// </summary>
            /// <param name="item">The duplicate item that was encountered.</param>
            public DuplicateCommandLineArgumentException(CommandLineArgument item)
                : base(string.Format("A command-line argument with the short name '{0}' or long name '{1}' has already been added previously.", item.ShortName, item.LongName)) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="DuplicateCommandLineArgumentException"/> class with serialized data.
            /// </summary>
            /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
            /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
            protected DuplicateCommandLineArgumentException(SerializationInfo info, StreamingContext context)
                : base(info, context) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="DuplicateCommandLineArgumentException"/> class with a specified error message 
            /// and a reference to the inner exception that is the cause of this exception.
            /// </summary>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
            public DuplicateCommandLineArgumentException(string message, Exception innerException)
                : base(message, innerException) {}

        #endregion
    }
}