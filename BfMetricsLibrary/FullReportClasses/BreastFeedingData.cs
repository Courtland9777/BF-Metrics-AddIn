// <copyright file="BreastFeedingData.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using System.Data;

namespace BfMetricsAddIn
{
    /// <summary>
    /// One month of breast feeding data.
    /// </summary>
    public class BreastFeedingData
    {
        // Column names
        private const string MFullName = "Full Name";

        private const string MMRN = "MRN";
        private const string MOHFColumnName = "Time to First Feeding (min)";
        private const string MSTSColumnNameC = "Skin to Skin within 1 hour - Cesarean (1=Yes, 0=No)";
        private const string MSTSColumnNameV = "Skin to Skin within 1 hour - Vaginal (1=Yes, 0=No)";
        private const string MIRColumnName = "Ever Breastfed? (1=Yes, 0=No)";
        private const string MERColumnName = "Exclusive?  (1=Yes, 0=No)";
        private const string MDDColumName = "Discharge Date/Time";

        // Constants for String to search for in row
        private const string MNBCountRowName = "Mother/Infant - Count distinct";

        private const string MNBStatRowName = "Mother/Infant - Total";

        private DateTime fileDate;
        private double oneHourFeeding;
        private double skinToSkin;
        private double initiationRate;
        private double exclusivityRate;
        private int numberOfNewborns;

        /// <summary>
        /// Initializes a new instance of the <see cref="BreastFeedingData"/> class.
        /// </summary>
        /// <param name="dt">DataTable created from Excel workbook</param>
        public BreastFeedingData(DataTable dt)
        {
            if (dt == null)
            {
                throw new ArgumentNullException(nameof(dt));
            }

            this.ReadFromDataTable(dt);
        }

        /// <summary>
        /// Gets the number of newborns for the month.
        /// </summary>
        public int NumberOfNewborns
        {
            get => this.numberOfNewborns;
            internal set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException($"_numberOfNewborns = {value}");
                }
                else
                {
                    this.numberOfNewborns = value;
                }
            }
        }

        /// <summary>
        /// Gets the number of newborns fed within the first hour.
        /// </summary>
        public double OneHourFeeding
        {
            get => (double)this.oneHourFeeding / this.NumberOfNewborns;

            internal set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException($"_oneHourFeeding = {value}");
                }
                else
                {
                    this.oneHourFeeding = value;
                }
            }
        }

        /// <summary>
        /// Gets the number of newborns with skin to skin within the first hour.
        /// </summary>
        public double SkinToSkin
        {
            get => (double)this.skinToSkin / this.NumberOfNewborns;

            internal set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException($"_skinToSkin = {value}");
                }
                else
                {
                    this.skinToSkin = value;
                }
            }
        }

        /// <summary>
        /// Gets the number of newborns that have breast fed this month.
        /// </summary>
        public double InitiationRate
        {
            get => (double)this.initiationRate / this.NumberOfNewborns;

            internal set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException($"_initiationRate = {value}");
                }
                else
                {
                    this.initiationRate = value;
                }
            }
        }

        /// <summary>
        /// Gets the number of newborns that have only breast fed this month.
        /// </summary>
        public double ExclusivityRate
        {
            get => (double)this.exclusivityRate / this.NumberOfNewborns;

            internal set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException($"_exclusivityRate = {value}");
                }
                else
                {
                    this.exclusivityRate = value;
                }
            }
        }

        /// <summary>
        /// Gets the month and year associated with the data.
        /// </summary>
        public DateTime FileDate
        {
            get => this.fileDate;

            internal set
            {
                if (value == DateTime.MinValue)
                {
                    throw new ArgumentOutOfRangeException($"_fileDate = {value}");
                }
                else
                {
                    this.fileDate = value;
                }
            }
        }

        private void ReadFromDataTable(DataTable dt)
        {
            int oHFCounter = 0;
            bool firstRowFlag = false;
            bool keyValueFlagA = false;
            bool keyValueFlagB = false;

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    bool isSuccess;

                    if (!firstRowFlag)
                    {
                        string strDateTime = row[MDDColumName].ToString();
                        isSuccess = DateTime.TryParse(strDateTime, out DateTime dateTime);

                        if (isSuccess)
                        {
                            this.FileDate = dateTime;
                        }

                        firstRowFlag = true;
                    }

                    // keyValue is the first column value.
                    string keyValue = row[MFullName].ToString();

                    string oneHourFeeding = row[MOHFColumnName].ToString();
                    isSuccess = int.TryParse(oneHourFeeding, out int oHFItem);

                    if (isSuccess && oHFItem <= 60 && oHFItem > 0)
                    {
                        oHFCounter++;
                    }

                    if (keyValue.Equals(MNBCountRowName, StringComparison.Ordinal))
                    {
                        keyValueFlagA = true;

                        string numberOfNewborns = row[MMRN].ToString();
                        isSuccess = int.TryParse(numberOfNewborns, out int intNumberOfNewborns);

                        if (isSuccess)
                        {
                            this.NumberOfNewborns = intNumberOfNewborns;
                        }
                    }

                    if (keyValue.Equals(MNBStatRowName, StringComparison.Ordinal))
                    {
                        keyValueFlagB = true;

                        string s2sV = row[MSTSColumnNameV].ToString();
                        isSuccess = int.TryParse(s2sV, out int ints2sV);

                        string s2sC = row[MSTSColumnNameC].ToString();
                        isSuccess = int.TryParse(s2sV, out int ints2sC);

                        if (isSuccess)
                        {
                            this.SkinToSkin = ints2sC + ints2sV;
                        }

                        string initiationRate = row[MIRColumnName].ToString();
                        isSuccess = int.TryParse(initiationRate, out int intInitiationRate);

                        if (isSuccess)
                        {
                            this.InitiationRate = intInitiationRate;
                        }

                        string exclusivityRate = row[MERColumnName].ToString();
                        isSuccess = int.TryParse(exclusivityRate, out int intExclusivityRate);

                        if (isSuccess)
                        {
                            this.ExclusivityRate = intExclusivityRate;
                        }
                    }
                }

                if (!keyValueFlagA || !keyValueFlagB)
                {
                    throw new ArgumentException($"Both values must be true. keyValueFlagA: {keyValueFlagA} keyValueFlagB: {keyValueFlagB}.");
                }

                this.OneHourFeeding = oHFCounter;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception)
            {
                throw;
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }
    }
}