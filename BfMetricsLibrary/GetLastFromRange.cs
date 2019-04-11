// <copyright file="GetLastFromRange.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace BfMetricsAddIn
{
    /// <summary>
    /// GetLastFromRange: holds methods to return last row/column from an Excel range
    /// </summary>
    public static class GetLastFromRange
    {
        /// <summary>
        /// Column: returns the last column used on the first row of the worksheet.
        /// </summary>
        /// <param name="worksheet">The worksheet to have it's headers checked.</param>
        /// <returns>The last column in the first row of worksheet.</returns>
        public static int Column(Excel.Worksheet worksheet)
        {
            int cellCount = worksheet.Columns.Count;
            int lastCell = worksheet.Cells[1, cellCount].End[Excel.XlDirection.xlToLeft].Column;
            LastCellDefaultValue(lastCell);
            return lastCell;
        }

        /// <summary>
        /// Column returns the last column used on the first row of the worksheet.
        /// </summary>
        /// <param name="worksheet">The worksheet to have it's headers checked.</param>
        /// <returns>The last row in the first column of worksheet.</returns>
        public static int Row(Excel.Worksheet worksheet)
        {
            int cellCount = worksheet.Rows.Count;
            int lastCell = worksheet.Cells[cellCount, 1].End[Excel.XlDirection.xlUp].Row;
            LastCellDefaultValue(lastCell);
            return lastCell;
        }

        /// <summary>
        /// LastCellNull: Checks to make sure the int does not equal zero.
        /// </summary>
        /// <param name="lastCell">Last cell or row from worksheet</param>
        private static void LastCellDefaultValue(int lastCell)
        {
            if (lastCell == 0)
            {
                throw new ArgumentException("Last cell value can not equal zero.");
            }
        }
    }
}