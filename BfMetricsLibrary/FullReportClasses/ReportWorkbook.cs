// <copyright file="ReportWorkbook.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace BfMetricsAddIn
{
    /// <summary>
    /// Excel workbook that will hold monthly stats report.
    /// </summary>
    public class ReportWorkbook
    {
        private readonly Excel.Application xlApp;
        private readonly BreastFeedingData[] sorted;
        private Excel.Worksheet worksheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportWorkbook"/> class.
        /// </summary>
        /// <param name="xlApp">An current instance of the Excel Application.</param>
        /// <param name="sorted">Array of BreastFeedingData objects sorted by date.</param>
        public ReportWorkbook(Excel.Application xlApp, BreastFeedingData[] sorted)
        {
            this.xlApp = xlApp;
            this.sorted = sorted;
            this.Workbook = this.xlApp.Workbooks.Add(Type.Missing);
        }

        /// <summary>
        /// Gets created workbook.
        /// </summary>
        public Excel.Workbook Workbook { get; }

        /// <summary>
        /// Adds the data to the workbook
        /// </summary>
        public void AddData()
        {
            this.worksheet = this.Workbook.ActiveSheet;
            this.worksheet.Name = "StatReport";
            string[] rowNames = new string[]
                { "Date", "One Hour Feeding", "Skin to Skin", "Initiation Rate", "Exclusivity Rate", "Number of Babies" };

            for (int r = 0; r < rowNames.Length; r++)
            {
                this.worksheet.Cells[r + 1, 1].Value = rowNames[r];
            }

            for (int c = 0; c < this.sorted.Length; c++)
            {
                int r = 1;
                this.worksheet.Cells[r++, c + 2].Value = "'" + this.sorted[c].FileDate.ToString("MMMyy", CultureInfo.CurrentCulture);
                this.worksheet.Cells[r++, c + 2].Value = this.sorted[c].OneHourFeeding;
                this.worksheet.Cells[r++, c + 2].Value = this.sorted[c].SkinToSkin;
                this.worksheet.Cells[r++, c + 2].Value = this.sorted[c].InitiationRate;
                this.worksheet.Cells[r++, c + 2].Value = this.sorted[c].ExclusivityRate;
                this.worksheet.Cells[r++, c + 2].Value = this.sorted[c].NumberOfNewborns;
                r = 1;
            }

            // Formatting
            Excel.Range xlDataRange = this.worksheet.Range[
                this.worksheet.Cells[1, 2], this.worksheet.Cells[6, this.sorted.Length + 2]];

            // Format doubles to percentage
            Excel.Range xlDoublesRange = this.worksheet.Range[
                this.worksheet.Cells[2, 2], this.worksheet.Cells[5, this.sorted.Length + 2]];
            xlDoublesRange.NumberFormat = "##%";

            // Set Alignment to center
            xlDataRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // AutoFit first column
            Excel.Range rowNameColumn = this.worksheet.Columns[1];
            rowNameColumn.EntireColumn.AutoFit();
        }
    }
}