// <copyright file="FullReport.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace BfMetricsAddIn
{
    /// <summary>
    /// Static Class for FullReport button.
    /// </summary>
    public static class FullReport
    {
        /// <summary>
        /// Main for the FullReport.
        /// </summary>
        /// <param name="xlApp">Excel application</param>
        public static void FullReportMain(Excel.Application xlApp)
        {
#if DEBUG
            string[] pathArray = XlFileDialog.SelectFiles();
#else
            string[] pathArray = XlFileDialog.SelectFiles(xlApp);
#endif
            BreastFeedingData[] breastFeedingDataArr = new BreastFeedingData[pathArray.Length];

            for (int i = 0; i < pathArray.Length; i++)
            {
                DataTable dataTable = DataTableCreation.CreateDataTable(pathArray[i]);
                breastFeedingDataArr[i] = new BreastFeedingData(dataTable);
            }

            // Sort Array by date.
            BreastFeedingData[] sorted = breastFeedingDataArr.OrderBy(c => c.FileDate).ToArray();

            // Create a new workbook
            ReportWorkbook repWorkbook = new ReportWorkbook(xlApp, sorted);

            try
            {
                // Add data to newly created workbook
                repWorkbook.AddData();
            }
            catch (Exception)
            {
                repWorkbook.Workbook.Close(false);
                throw;
            }

            // Save new workbook
            string savePath = string.Format(
            CultureInfo.CurrentCulture, @"C:\Users\{0}\Documents\BFMetrics\ReportFiles", Environment.UserName);

            // Save in default location
            const string fileName = @"\" + "BFMetricsReport";
            repWorkbook.Workbook.SaveAs(savePath + fileName);
        }
    }
}