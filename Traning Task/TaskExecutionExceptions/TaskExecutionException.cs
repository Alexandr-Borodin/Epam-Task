using System;

namespace TaskExecutionExceptions
{
    /// <summary>
    /// Describe task execution exception
    /// </summary>
    public class TaskExecutionException : Exception
    {
        /// <summary>
        /// Constructor of task execution exception.
        /// </summary>
        /// <param name="message">Message to show after pushed exception.</param>
        public TaskExecutionException(string message) : base(message) { }
    }
}
