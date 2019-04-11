// <copyright file="XlFileDialog.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;
using FileDialog = Microsoft.Office.Core.FileDialog;
using Office = Microsoft.Office.Core;

namespace BfMetricsAddIn
{
    /// <summary>
    /// The file dialog box selector in Excel.
    /// </summary>
    public static class XlFileDialog
    {
        /// <summary>
        /// Debugging preselected files.
        /// </summary>
        /// <returns>Predefined Array for testing.</returns>
        public static string[] SelectFiles()
        {
            string folderPath = string.Format(
                CultureInfo.CurrentCulture, @"C:\Users\{0}\Documents\BFMetrics\OriginalMonthFiles\", Environment.UserName);

            // Debugging file paths
            string[] pathArray = new string[3];
            pathArray[0] = folderPath + "BreastfeedingMetrics(Nov18).xlsx";
            pathArray[1] = folderPath + "BreastfeedingMetrics(Dec18).xlsx";
            pathArray[2] = folderPath + "BreastfeedingMetrics(Aug18).xlsx";
            return pathArray;
        }

        /// <summary>
        /// User selects files to collect data from.
        /// </summary>
        /// <param name="xlApp">Excel Application</param>
        /// <returns>Array of full file path strings.</returns>
        public static string[] SelectFiles(Excel.Application xlApp)
        {
            FileDialog dialog = xlApp.FileDialog[Office.MsoFileDialogType.msoFileDialogOpen];
            dialog.AllowMultiSelect = true;
            dialog.Filters.Add("Excel Files", "*.xlsx", 1);
            dialog.InitialFileName = string.Format(
                CultureInfo.CurrentCulture, @"C:\Users\{0}\Documents\BFMetrics\OriginalMonthFiles", Environment.UserName);

            if (dialog.Show() > 0)
            {
                string[] pathArray = new string[dialog.SelectedItems.Count];

                for (int i = 1; i < dialog.SelectedItems.Count; i++)
                {
                    pathArray[i - 1] = dialog.SelectedItems.Item(i);
                }

                if (pathArray.Length > 0)
                {
                    return pathArray;
                }

                throw new ArgumentException($"{pathArray} has a length of zero.");
            }
            else
            {
                throw new ArgumentException("File selection canceled by user.");
            }
        }
    }
}