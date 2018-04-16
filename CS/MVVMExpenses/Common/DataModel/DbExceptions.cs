using System;
using System.Linq;

namespace MVVMExpenses.Common.DataModel {
    /// <summary>
    /// The database-independent exception used in Data Layer and View Model Layer to handle database errors.
    /// </summary>
    public class DbException : Exception {

        /// <summary>
        /// Initializes a new instance of the DbRepository class.
        /// </summary>
        /// <param name="errorMessage">An error message text.</param>
        /// <param name="errorCaption">An error message caption text.</param>
        /// <param name="innerException">An underlying exception.</param>
        public DbException(string errorMessage, string errorCaption, Exception innerException)
            : base(innerException.Message, innerException) {
            ErrorMessage = errorMessage;
            ErrorCaption = errorCaption;
        }

        /// <summary>The error message text.</summary>
        public string ErrorMessage { get; private set; }

        /// <summary>The error message caption text.</summary>
        public string ErrorCaption { get; private set; }
    }
}