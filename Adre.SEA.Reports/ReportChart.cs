using System.IO;
using Telerik.Reporting;


namespace Adre.SEA.Reports
{
    using System;
    using System.Drawing;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ReportChart.
    /// </summary>
    public partial class ReportChart : Report
    {
        private Image _pictureBox1Value;
        private Image _resultImage;
        private PictureBox resultPictureBox;

        public ReportChart(string path, string resultPath)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            if (!String.IsNullOrEmpty(path))
            {
                _pictureBox1Value = Image.FromStream(new MemoryStream(File.ReadAllBytes(path)));
                pictureBox1.Value = _pictureBox1Value;
            }
            else
            {
                pictureBox1.Visible = false;
            }

            if (!string.IsNullOrEmpty(resultPath))
            {
                _resultImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(resultPath)));
                resultPictureBox = new PictureBox() { Sizing = ImageSizeMode.ScaleProportional, Value = _resultImage };
                this.detail.Items.Add(resultPictureBox);
            }

            ResizeReport();
        }

        public void ResizeReport()
        {
            ResizeReport(Report.PageSettings);
        }

        public void ResizeReport(PageSettings newPageSettings)
        {
            if (pictureBox1.Visible == false)
                return;

            var image = _pictureBox1Value;

            Unit pageWidth = newPageSettings.PaperSize.Width - newPageSettings.Margins.Left - newPageSettings.Margins.Right;
            Unit pageHeight = newPageSettings.PaperSize.Height - newPageSettings.Margins.Top - newPageSettings.Margins.Bottom;

            Unit pageMarginLeft = newPageSettings.Margins.Left;
            Unit pageMarginRight = newPageSettings.Margins.Right;

            if (newPageSettings.Landscape)
            {
                pageWidth = newPageSettings.PaperSize.Height - newPageSettings.Margins.Top - newPageSettings.Margins.Bottom;
                pageHeight = newPageSettings.PaperSize.Width - newPageSettings.Margins.Left - newPageSettings.Margins.Right;
            }

            var imageRatioWidth = (double) _pictureBox1Value.Height / _pictureBox1Value.Width;
            var imageRatioHeight = (double) _pictureBox1Value.Width / _pictureBox1Value.Height;

            var e = pageWidth.Multiply(imageRatioWidth);
            var f = pageHeight;
            var g = pageFooterSection1.Height;
            var h = pageHeaderSection1.Height;

            var pageHeightExcludeHeaderAndFooter = f - h - g;
            var calculatedPictureBoxHeight = Unit.Min(e, pageHeightExcludeHeaderAndFooter);

            pictureBox1.Height = calculatedPictureBoxHeight;

            var i = pictureBox1.Height;
            var j = i * imageRatioHeight;

            pictureBox1.Width = j;

            if (resultPictureBox != null)
            {
                resultPictureBox.Width = Unit.Pixel(_resultImage.Width / 3);
                resultPictureBox.Height = Unit.Pixel(_resultImage.Height / 3);
                resultPictureBox.Left = pageWidth - resultPictureBox.Width - Unit.Pixel(50) - pageFooterSection1.Height;
                resultPictureBox.Top = pageHeightExcludeHeaderAndFooter - resultPictureBox.Height - Unit.Pixel(50);
            }
        }

        private void Report1_Disposed(object sender, EventArgs e)
        {
            _pictureBox1Value.Dispose();
            _pictureBox1Value = null;
        }
    }
}