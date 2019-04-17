// <copyright file="ErrorHandler.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using System.Text;
using System.Windows.Forms;

namespace BfMetricsAddIn.ErrorHandlingHelper
{
    /// <summary>
    /// Error Handling is managed from this Class
    /// </summary>
    public static class ErrorHandler
    {
        /// <summary>
        /// Create a message describing error to user
        /// </summary>
        /// <param name="ex">Error object</param>
        public static void DisplayMessage(Exception ex)
        {
            var sf = new System.Diagnostics.StackFrame(1);
            var caller = sf.GetMethod();
            var currentProcedure = caller.Name.Trim();

            var userMessage = new StringBuilder()
            .AppendLine("Contact your system administrator. A record has been created in the log file.")
            .AppendLine("Procedure: " + currentProcedure)
            .AppendLine("Description: " + ex.ToString())
            .ToString();

            MessageBox.Show(userMessage, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}