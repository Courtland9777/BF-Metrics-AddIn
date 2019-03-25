using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new MyRibbon();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace BF_Metrics_AddIn
{
    [ComVisible(true)]
    public class MyRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private bool IsEnabled = true;

        public MyRibbon()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string RibbonID)
        {
            return GetResourceText("BF_Metrics_AddIn.MyRibbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        //GetEnabled callbacks
        public bool SetEnabled(Office.IRibbonControl control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return IsEnabled;
        }

        public void ToggleButton(bool toggle)
        {
            IsEnabled = toggle;

            ribbon.Invalidate();
        }

        //Button click callbacks
        public void OnActionCallback(Office.IRibbonControl control)
        {
            try
            {
                switch (control.Id)
                {
                    case "fullReport":
                        MessageBox.Show("You clicked " + control.Id);
                        break;

                    case "quickReport":
                        MessageBox.Show("You clicked " + control.Id);
                        break;

                    case "saveNewFolder":
                        MessageBox.Show("You clicked " + control.Id);
                        break;

                    case "setFolder":
                        MessageBox.Show("You clicked " + control.Id);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("control.Id", control.Id, String.Format("Unknown button selected. Button Id: {0}", control.Id));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

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

        #endregion
    }
}
