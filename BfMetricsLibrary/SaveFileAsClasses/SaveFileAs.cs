// <copyright file="SaveFileAs.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using FileDialog = Microsoft.Office.Core.FileDialog;
using Office = Microsoft.Office.Core;

namespace BfMetricsAddIn
{
    /// <summary>
    /// SaveFileAs: saves a new month file with correct name and date.
    /// </summary>
    public sealed class SaveFileAs : IButtonsaveNewFolder
    {
        private const string FileName = @"\OriginalMonthFiles\BreastfeedingMetrics(";
        private const string HeaderToRemove = "Reporting Group: Mother/Infant";
        private const string HdrDischargeDate = "Discharge Date/Time";
        private readonly Excel.Application xlApp;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveFileAs"/> class.
        /// </summary>
        /// <param name="xlApp">Current instance of the Excel Application</param>
        public SaveFileAs(Excel.Application xlApp)
        {
            this.xlApp = xlApp;
        }

        /// <summary>
        /// SaveAs() is entry point for saving SaveFileAs class.
        /// </summary>
        void IButtonsaveNewFolder.SaveAs()
        {
            Excel.Workbook activeWorkbook = this.xlApp.ActiveWorkbook;
            Excel.Worksheet newbornWorksheet = activeWorkbook.Worksheets["Newborns_3"];

            CheckforHeaders(newbornWorksheet);

            string defaultSavePath = string.Format(
                CultureInfo.CurrentCulture, @"C:\Users\{0}\Documents\BFMetrics", Environment.UserName);

            FileDialog dialog = this.xlApp.FileDialog[Office.MsoFileDialogType.msoFileDialogSaveAs];
            dialog.AllowMultiSelect = false;
            dialog.InitialFileName = defaultSavePath + FileName +
                GetDateString(newbornWorksheet, GetColumnForDateString(newbornWorksheet)) + ")";
            if (dialog.Show() != 0)
            {
                string savePath = dialog.SelectedItems.Item(1);
                activeWorkbook.SaveAs(savePath, 51);
            }
        }

        /// <summary>
        /// GetColumnForDateString returns the last column being used in the first row of a range.
        /// </summary>
        /// <param name="newbornWorksheet">Worksheet named Newborns_3</param>
        /// <exception cref="ArgumentOutOfRangeException">Can't find column name</exception>
        /// <returns>Column number to check for date.</returns>
        private static int GetColumnForDateString(Excel.Worksheet newbornWorksheet)
        {
            int lastCol = GetLastFromRange.Column(newbornWorksheet);
            Excel.Range rngCells = newbornWorksheet.Range[newbornWorksheet.Cells[1, 1], newbornWorksheet.Cells[1, lastCol]];
            for (int i = 1; i <= lastCol; i++)
            {
                string cellValue = rngCells.Cells[1, i].Value.ToString();
                if (cellValue == HdrDischargeDate)
                {
                    return i;
                }
            }

            // throw new Exception(String.Format("Can not find column header with the name: {0}", hdrDischargeDate));
            throw new ArgumentOutOfRangeException($"All headers checked in row 1. Column 1 to {lastCol}", HdrDischargeDate);
        }

        private static string GetDateString(Excel.Worksheet newbornWorksheet, int dateColumn)
        {
            DateTime dischargeDate = newbornWorksheet.Cells[2, dateColumn].Value;
            return string.Format(CultureInfo.CurrentCulture, "{0:MMMyy}", dischargeDate);
        }

        /// <summary>
        /// CheckForHeaders ensures the first row has been remove so headers are now in the top row.
        /// </summary>
        /// <param name="newbornWorksheet">Worksheet named Newborns_3</param>
        private static void CheckforHeaders(Excel.Worksheet newbornWorksheet)
        {
            Excel.Range cells = newbornWorksheet.Range["A1"];

            if (cells.Value.ToString() == HeaderToRemove)
            {
                Excel.Range toDel = cells.EntireRow;
                toDel.Delete();
            }
        }
    }
}