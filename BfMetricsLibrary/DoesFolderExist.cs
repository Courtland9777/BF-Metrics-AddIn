// <copyright file="DoesFolderExist.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BfMetricsAddIn
{
    /// <summary>
    /// Check if required folders exist
    /// </summary>
    public static class DoesFolderExist
    {
        /// <summary>
        /// Check to see if the required folders Exist.
        /// </summary>
        public static void CheckForFolder()
        {
            string bfMetricsPath = string.Format(
                CultureInfo.CurrentCulture, @"C:\Users\{0}\Documents\BFMetrics", Environment.UserName);
            string reportFiles = string.Format(
                CultureInfo.CurrentCulture, @"C:\Users\{0}\Documents\BFMetrics\ReportFiles", Environment.UserName);
            string originalMonthFiles = string.Format(
                CultureInfo.CurrentCulture, @"C:\Users\{0}\Documents\BFMetrics\OriginalMonthFiles", Environment.UserName);

            if (File.Exists(reportFiles) && File.Exists(originalMonthFiles))
            {
                return;
            }
            else if (!File.Exists(bfMetricsPath))
            {
                Directory.CreateDirectory(bfMetricsPath);
                Directory.CreateDirectory(reportFiles);
                Directory.CreateDirectory(originalMonthFiles);
                return;
            }
            else
            {
                if (!File.Exists(reportFiles))
                {
                    Directory.CreateDirectory(reportFiles);
                }

                if (!File.Exists(originalMonthFiles))
                {
                    Directory.CreateDirectory(originalMonthFiles);
                }

                return;
            }
        }
    }
}
