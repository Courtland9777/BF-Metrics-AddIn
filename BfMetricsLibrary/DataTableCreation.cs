// <copyright file="DataTableCreation.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BfMetricsAddIn
{
    /// <summary>
    /// Creates a DataTable from Excel workbook.
    /// </summary>
    public static class DataTableCreation
    {
        private const string MNewbornsWS = "Newborns_3";

        /// <summary>
        /// Create a DataTable from Excel workbook
        /// </summary>
        /// <param name="fileName">full path of Excel worksheet.</param>
        /// <returns>DataTable from Excel workbook.</returns>
        internal static DataTable CreateDataTable(string fileName)
        {
            DataTable dt = null;
            OleDbConnection myConnection = null;
            try
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + fileName +
                    ";Extended Properties='Excel 12.0 xml;HDR=Yes;IMEX=1'";

                myConnection = new OleDbConnection(connectionString);
                myConnection.Open();

                const string sheetName = MNewbornsWS + "$";

                OleDbDataAdapter myCommand = new OleDbDataAdapter("select * from [" + sheetName + "]", myConnection);
                dt = new DataTable();
                myCommand.Fill(dt);
            }

#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception)
            {
                throw;
            }
#pragma warning restore CA1031 // Do not catch general exception types
            finally
            {
                myConnection.Close();
            }

            return dt;
        }
    }
}
