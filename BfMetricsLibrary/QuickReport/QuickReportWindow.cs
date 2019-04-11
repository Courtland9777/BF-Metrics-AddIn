// <copyright file="QuickReportWindow.cs" company="Courtland9777">
// Copyright (c) Courtland9777. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using System.Windows.Forms;

namespace BfMetricsAddIn.QuickReportNS
{
    /// <summary>
    /// Form to display one month's worth of data.
    /// </summary>
    public partial class QuickReportWindow : Form
    {
        private readonly BreastFeedingData breastFeedingData;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuickReportWindow"/> class.
        /// </summary>
        /// <param name="breastFeedingData">One month's worth of data</param>
        public QuickReportWindow(BreastFeedingData breastFeedingData)
        {
            this.InitializeComponent();
            this.breastFeedingData = breastFeedingData ?? throw new ArgumentNullException(nameof(breastFeedingData));
        }

        private void QuickReportWindow_Load(object sender, EventArgs e)
        {
            this.tbDate.Text = this.breastFeedingData.FileDate.ToString("MMMyy", CultureInfo.CurrentCulture);
            this.tbOneHourFeeding.Text = this.breastFeedingData.OneHourFeeding.ToString(
                "0.00%", CultureInfo.CurrentCulture);
            this.tbSkinToSkin.Text = this.breastFeedingData.SkinToSkin.ToString(
                "0.00%", CultureInfo.CurrentCulture);
            this.tbInitiationRate.Text = this.breastFeedingData.InitiationRate.ToString(
                "0.00%", CultureInfo.CurrentCulture);
            this.tbExclusivityRate.Text = this.breastFeedingData.ExclusivityRate.ToString(
                "0.00%", CultureInfo.CurrentCulture);
            this.tbNumberOfNewborns.Text = this.breastFeedingData.NumberOfNewborns.ToString(CultureInfo.CurrentCulture);
        }

        private void BtnOkay_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}