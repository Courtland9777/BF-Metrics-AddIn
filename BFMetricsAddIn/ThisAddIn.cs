// <copyright file="ThisAddIn.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace BfMetricsAddIn
{
    /// <summary>
    /// Part of ThisAddIn available to user.
    /// </summary>
    public partial class ThisAddIn
    {
        private MyRibbon myRibbon;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        /// <summary>
        /// Fires when a Workbook is saved
        /// </summary>
        /// <param name="wb">Workbook that was saved.</param>
        /// <param name="isSaved">Was the save successful?</param>
        public static void Application_WorkbookAfterSave(Excel.Workbook wb, bool isSaved)
        {
            if (!isSaved)
            {
                MessageBox.Show($"Workbook: {wb.Name} is not saved.");
            }
        }

        /// <summary>
        /// Check for Newborn_3 worksheet
        /// </summary>
        /// <param name="wb">Workbook reference provided by event handler</param>
        public void Application_ActiveWorkbookChanges(Excel.Workbook wb)
        {
            const string newbornsWs = "Newborns_3";

            foreach (Excel.Worksheet worksheet in wb.Worksheets)
            {
                if (worksheet.Name == newbornsWs)
                {
                    this.myRibbon.ToggleButton(true);
                    return;
                }
            }

            this.myRibbon.ToggleButton(false);
        }

        /// <inheritdoc/>
        protected override Office.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            this.myRibbon = new MyRibbon();
            return this.myRibbon;
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.WorkbookActivate += new Excel.AppEvents_WorkbookActivateEventHandler(
                this.Application_ActiveWorkbookChanges);
            this.Application.WorkbookDeactivate += new Excel.AppEvents_WorkbookDeactivateEventHandler(
                 this.Application_ActiveWorkbookChanges);
            this.Application.WorkbookAfterSave += new Excel.AppEvents_WorkbookAfterSaveEventHandler(
                Application_WorkbookAfterSave);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += this.ThisAddIn_Startup;
            this.Shutdown += this.ThisAddIn_Shutdown;
        }
    }

#pragma warning restore CA1707 // Identifiers should not contain underscores
}