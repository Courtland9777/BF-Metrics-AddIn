// <copyright file="MyRibbon.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace BfMetricsAddIn
{
    /// <summary>
    /// Controls communication with XML
    /// </summary>
    [ComVisible(true)]
    public class MyRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private bool isEnabled = true;

        /// <inheritdoc/>
        public string GetCustomUI(string RibbonID)
        {
            return GetResourceText("BF_Metrics_AddIn.MyRibbon.xml");
        }

        // Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        /// <summary>
        /// SetEnabled: Callback from XLM
        /// </summary>
        /// <param name="control">Ribbon control from XLM</param>
        /// <returns>The isEnabled value</returns>
        public bool SetEnabled(Office.IRibbonControl control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return this.isEnabled;
        }

        /// <summary>
        /// ToggleButton: change isEnabled variable
        /// </summary>
        /// <param name="toggle">Is control visable.</param>
        public void ToggleButton(bool toggle)
        {
            this.isEnabled = toggle;

            this.ribbon.Invalidate();
        }

        // Button click callbacks

        /// <summary>
        /// OnActionCallback: callback from XML button
        /// </summary>
        /// <param name="control">Button control from XML</param>
        /// <exception cref="ArgumentException">The control.id is not recognized.</exception>
        public void OnActionCallback(Office.IRibbonControl control)
        {
            try
            {
                switch (control.Id)
                {
                    case "fullReport":
                        FullReport.FullReportMain(Globals.ThisAddIn.Application);
                        break;

                    case "quickReport":
                        QuickReportNS.QuickReport.QuickReportMain(Globals.ThisAddIn.Application);
                        break;

                    case "saveNewFolder":
                        IButtonsaveNewFolder saveFileAs = new SaveFileAs(Globals.ThisAddIn.Application);
                        saveFileAs.SaveAs();
                        break;

                    default:
                        throw new ArgumentException("Unknown button selected.", control.Id);
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
            {
                DialogResult dialogResult = MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        /// <summary>
        /// Ribbon_Load: method called from XLM file
        /// </summary>
        /// <param name="ribbonUI">Called from XML file to load UI.</param>
        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }

            return null;
        }
    }
}