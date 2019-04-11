// <copyright file="CatchExceptions.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using System.Windows.Forms;

namespace BfMetricsAddIn
{
    /// <summary>
    /// CatchExceptions: singleton to create error message.
    /// </summary>
    public sealed class CatchExceptions
    {
        private CatchExceptions()
        {
        }

        /// <summary>
        /// Gets the instance of CatchExceptions
        /// </summary>
        public static CatchExceptions Instance { get; } = new CatchExceptions();

        /// <summary>
        /// Shows the exception method message
        /// </summary>
        /// <param name="ex">Exception object</param>
        public static void ShowExceptionMessage(Exception ex)
        {
            string errorMessage = "Error: ";
            errorMessage = string.Concat(errorMessage, ex.Message);
            errorMessage = string.Concat(errorMessage, " Line: ");
            errorMessage = string.Concat(errorMessage, ex.StackTrace);

            MessageBox.Show(errorMessage, "Error");
        }
    }
}