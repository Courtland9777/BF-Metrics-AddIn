// <copyright file="IsWorkbookOpen.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace BfMetricsAddIn
{
    /// <summary>
    /// Check if Workbook is open.
    /// </summary>
    public static class IsWorkbookOpen
    {
        /// <summary>
        /// Is Workbook open check.
        /// </summary>
        /// <param name="wbook">Workbook file fullpath.</param>
        /// <param name="xlApp">Current Excel application.</param>
        /// <returns>If the Workbook is open or not bool.</returns>
        public static bool IsThisWorkbookOpen(string wbook, Excel.Application xlApp)
        {
            bool isOpened = true;
            try
            {
                Excel.Workbook workbook = xlApp.Workbooks.Item[wbook];
            }
            catch (COMException)
            {
                isOpened = false;
            }

            return isOpened;
        }
    }
}