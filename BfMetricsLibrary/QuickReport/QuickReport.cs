// <copyright file="QuickReport.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace BfMetricsAddIn.QuickReportNS
{
    /// <summary>
    /// Static class for quickReport button
    /// </summary>
    public static class QuickReport
    {
        /// <summary>
        /// Main for quick report.
        /// </summary>
        /// <param name="xlApp">Excel Application</param>
        public static void QuickReportMain(Excel.Application xlApp)
        {
            // Get Data to show in form
            string openXlFileName = xlApp.ActiveWorkbook.FullName;
            DataTable dataTable = DataTableCreation.CreateDataTable(openXlFileName);
            BreastFeedingData breastFeedingData = new BreastFeedingData(dataTable);

            // Create and open form
            QuickReportWindow reportWindow = new QuickReportWindow(breastFeedingData);
            reportWindow.Show();
        }
    }
}