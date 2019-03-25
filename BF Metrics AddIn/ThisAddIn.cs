using System;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace BF_Metrics_AddIn
{
    public partial class ThisAddIn
    {
        private MyRibbon myRibbon;

        //Check to see if worksheet exists. Called from event.
        public void Application_ActiveWorkbookChanges(Excel.Workbook Wb)
        {
            const string newbornsWs = "Newborns_3";
            try
            {
                foreach (Excel.Worksheet worksheet in Wb.Worksheets)
                {
                    if (worksheet.Name == newbornsWs)
                    {
                        myRibbon.ToggleButton(true);
                        return;
                    }
                }
                myRibbon.ToggleButton(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.WorkbookActivate += new Excel.AppEvents_WorkbookActivateEventHandler
                (Application_ActiveWorkbookChanges);
            this.Application.WorkbookDeactivate += new Excel.AppEvents_WorkbookDeactivateEventHandler
                 (Application_ActiveWorkbookChanges);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region Create myRibbon

        protected override Office.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            myRibbon = new MyRibbon();
            return myRibbon;
        }

        #endregion

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
