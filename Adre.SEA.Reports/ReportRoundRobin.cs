using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace Adre.SEA.Reports
{
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ReportRoundRobin.
    /// </summary>
    public partial class ReportRoundRobin : Report
    {
        public ReportRoundRobin(List<string> contingents, ObjectDataSource tableRoundRobinOds)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            var index = 0;

            detail.Items.Remove(detail.Items.Find("TableRoundRobin", true)[0]);


            // Round Robin Table Generator

            var OldTableLocation = TableRoundRobin.Location;

            TableRoundRobin = new Table();

            var columnWidth = Unit.Cm(2.9897913932800293D / 1.5);
            var rowHeight = Unit.Cm(0.60854166746139526D);

            var tableItems = new List<ReportItemBase>();

            var detailTableGroup = new TableGroup();
            detailTableGroup.Groupings.Add(new Grouping(null));

            var columns = new List<string>() { };

            var totalColumns = 1 + (contingents.Count * 2) + 2 + 1 + 1;
            var totalRows = 1 + (contingents.Count * 3);

            columns.InsertRange(0, contingents);

            // Add columns
            for (var i = 0; i < totalColumns; i++)
            {
                TableRoundRobin.ColumnGroups.Add(new TableGroup());
                TableRoundRobin.Body.Columns.Add(new TableBodyColumn(columnWidth));
            }

            // Add rows
            for (var i = 0; i < totalRows; i++)
            {
                var rowTableGroup = new TableGroup();
                detailTableGroup.ChildGroups.Add(rowTableGroup);
                TableRoundRobin.Body.Rows.Add(new TableBodyRow(Unit.Cm(0.60854160785675049D)));
            }

            // required for rows
            TableRoundRobin.RowGroups.Add(detailTableGroup);

            // Render First Column Header
            var tbz = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "CONT" };
            ApplyTextBoxStyle(tbz);
            tbz.Style.Font.Bold = true;
            TableRoundRobin.Body.SetCellContent(0, 0, tbz, 1, 1);
            tableItems.Add(tbz);

            // Render Contingents Headers
            foreach (var column in columns)
            {

                var tb = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = column };

                tb.Style.TextAlign = HorizontalAlign.Center;
                tb.Style.BorderStyle.Default = BorderType.Solid;
                tb.Style.BorderWidth.Default = new Unit(1);
                tb.Style.VerticalAlign = VerticalAlign.Middle;
                tb.Style.Font.Bold = true;

                TableRoundRobin.Body.SetCellContent(0, 1 + (index * 2), tb, 1, 2);

                tableItems.Add(tb);
                index++;
            }

            index = 0;

            // Render Total Column Header
            tbz = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "TOTAL" };
            ApplyTextBoxStyle(tbz);
            tbz.Style.Font.Bold = true;
            TableRoundRobin.Body.SetCellContent(0, 1 + (columns.Count * 2), tbz, 1, 2);
            tableItems.Add(tbz);

            // Render PT DIFF Column Header
            tbz = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "PT DIFF" };
            ApplyTextBoxStyle(tbz);
            tbz.Style.Font.Bold = true;
            TableRoundRobin.Body.SetCellContent(0, 1 + (columns.Count * 2) + 2, tbz, 1, 1);
            tableItems.Add(tbz);

            // Render RANKING Column Header
            tbz = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "RANKING" };
            ApplyTextBoxStyle(tbz);
            tbz.Style.Font.Bold = true;
            TableRoundRobin.Body.SetCellContent(0, 1 + (columns.Count * 2) + 2 + 1, tbz, 1, 1);
            tableItems.Add(tbz);

            // Render Row Headers
            foreach (var contingent in contingents)
            {
                var tb = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = contingent };

                tb.Style.TextAlign = HorizontalAlign.Center;
                tb.Style.BorderStyle.Default = BorderType.Solid;
                tb.Style.BorderWidth.Default = new Unit(1);
                tb.Style.VerticalAlign = VerticalAlign.Middle;
                tb.Style.Font.Bold = true;

                TableRoundRobin.Body.SetCellContent(1 + (index * 3), 0, tb, 3, 1);

                tableItems.Add(tb);

                index++;
            }

            for (var i = 0; i < contingents.Count; i++)
            {
                var contingent = contingents[i];

                for (var j = 0; j < contingents.Count; j++)
                {
                    var vsContingent = contingents[j];
                    var contingentVsContingent = (contingent + vsContingent).Replace(" ", "");

                    if (contingent == vsContingent)
                    {
                        var tb = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "" };

                        tb.Style.TextAlign = HorizontalAlign.Center;
                        tb.Style.BorderStyle.Default = BorderType.Solid;
                        tb.Style.BorderWidth.Default = new Unit(1);
                        tb.Style.VerticalAlign = VerticalAlign.Middle;
                        tb.Style.BackgroundColor = Color.DarkGray;

                        TableRoundRobin.Body.SetCellContent(1 + (i * 3), 1 + (j * 2), tb, 3, 2);

                        tableItems.Add(tb);
                    }
                    else
                    {
                        var dataSet = tableRoundRobinOds.DataSource as DataSet;

                        if (dataSet != null && dataSet.Tables[0].Columns.Contains("Point" + contingentVsContingent))
                        {
                            var initialRowPoint = 1 + (i * 3);
                            var initialColumnPoint = 1 + (j * 2);

                            var tbPoint = new TextBox
                            {
                                Size = new SizeU(columnWidth, rowHeight),
                                Value = "=Fields.Point" + contingentVsContingent
                            };
                            ApplyTextBoxStyle(tbPoint);
                            TableRoundRobin.Body.SetCellContent(initialRowPoint, initialColumnPoint, tbPoint, 1, 2);
                            tableItems.Add(tbPoint);

                            var tbSetA = new TextBox
                            {
                                Size = new SizeU(columnWidth, rowHeight),
                                Value = "=Fields.SetA" + contingentVsContingent
                            };
                            ApplyTextBoxStyle(tbSetA);
                            TableRoundRobin.Body.SetCellContent(initialRowPoint + 1, initialColumnPoint, tbSetA);
                            tableItems.Add(tbSetA);

                            var tbSetB = new TextBox
                            {
                                Size = new SizeU(columnWidth, rowHeight),
                                Value = "=Fields.SetB" + contingentVsContingent
                            };
                            ApplyTextBoxStyle(tbSetB);
                            TableRoundRobin.Body.SetCellContent(initialRowPoint + 1, initialColumnPoint + 1, tbSetB);
                            tableItems.Add(tbSetB);

                            var tbSmallPointA =
                                new TextBox
                                {
                                    Size = new SizeU(columnWidth, rowHeight),
                                    Value = "=Fields.SmallPointA" + contingentVsContingent
                                };
                            ApplyTextBoxStyle(tbSmallPointA);
                            TableRoundRobin.Body.SetCellContent(initialRowPoint + 2, initialColumnPoint, tbSmallPointA);
                            tableItems.Add(tbSmallPointA);

                            var tbSmallPointB =
                                new TextBox
                                {
                                    Size = new SizeU(columnWidth, rowHeight),
                                    Value = "=Fields.SmallPointB" + contingentVsContingent
                                };
                            ApplyTextBoxStyle(tbSmallPointB);
                            TableRoundRobin.Body.SetCellContent(initialRowPoint + 2, initialColumnPoint + 1,
                                tbSmallPointB);
                            tableItems.Add(tbSmallPointB);
                        }
                        else
                        {
                            var tb = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "No Match Data" };

                            ApplyTextBoxStyle(tb);
                            tb.Style.BorderStyle.Default = BorderType.Solid;
                            tb.Style.BackgroundColor = ColorTranslator.FromHtml("#ffdfe6");
                            tb.Style.Color = Color.Black;
                            
                            TableRoundRobin.Body.SetCellContent(1 + (i * 3), 1 + (j * 2), tb, 3, 2);

                            tableItems.Add(tb);
                        }
                    }
                }

                // Render Total Score
                var initialRowPoint2 = 1 + (i * 3);
                var initialColumnPoint2 = 1 + ((contingents.Count) * 2);

                var safeContingent = contingent.Replace(" ", "");

                var tbPointTotal = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "=Fields.PointTotal" + safeContingent };
                ApplyTextBoxStyle(tbPointTotal);
                TableRoundRobin.Body.SetCellContent(initialRowPoint2, initialColumnPoint2, tbPointTotal, 1, 2);
                tableItems.Add(tbPointTotal);

                var tbSetATotal = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "=Fields.SetATotal" + safeContingent };
                ApplyTextBoxStyle(tbSetATotal);
                TableRoundRobin.Body.SetCellContent(initialRowPoint2 + 1, initialColumnPoint2, tbSetATotal);
                tableItems.Add(tbSetATotal);

                var tbSetBTotal = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "=Fields.SetBTotal" + safeContingent };
                ApplyTextBoxStyle(tbSetBTotal);
                TableRoundRobin.Body.SetCellContent(initialRowPoint2 + 1, initialColumnPoint2 + 1, tbSetBTotal);
                tableItems.Add(tbSetBTotal);

                var tbSmallPointATotal = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "=Fields.SmallPointATotal" + safeContingent };
                ApplyTextBoxStyle(tbSmallPointATotal);
                TableRoundRobin.Body.SetCellContent(initialRowPoint2 + 2, initialColumnPoint2, tbSmallPointATotal);
                tableItems.Add(tbSmallPointATotal);

                var tbSmallPointBTotal = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "=Fields.SmallPointBTotal" + safeContingent };
                ApplyTextBoxStyle(tbSmallPointBTotal);
                TableRoundRobin.Body.SetCellContent(initialRowPoint2 + 2, initialColumnPoint2 + 1, tbSmallPointBTotal);
                tableItems.Add(tbSmallPointBTotal);

                // Render Point Difference
                initialRowPoint2 = 1 + (i * 3);
                initialColumnPoint2 = 1 + ((contingents.Count) * 2) + 2;

                var tbb = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "=Fields.PointDiff" + safeContingent };
                ApplyTextBoxStyle(tbb);
                TableRoundRobin.Body.SetCellContent(initialRowPoint2, initialColumnPoint2, tbb);
                tableItems.Add(tbb);

                tbb = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "=Fields.SetDiff" + safeContingent };
                ApplyTextBoxStyle(tbb);
                TableRoundRobin.Body.SetCellContent(initialRowPoint2 + 1, initialColumnPoint2, tbb);
                tableItems.Add(tbb);

                tbb = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = "=Fields.SmallPointDiff" + safeContingent };
                ApplyTextBoxStyle(tbb);
                TableRoundRobin.Body.SetCellContent(initialRowPoint2 + 2, initialColumnPoint2, tbb);
                tableItems.Add(tbb);

                // Render Ranking
                var initialRowPoint3 = 1 + (i * 3);
                var initialColumnPoint3 = 1 + ((contingents.Count) * 2) + 2 + 1;

                var tbRank = new TextBox { Size = new SizeU(columnWidth, rowHeight), Value = (i + 1).ToString() };
                ApplyTextBoxStyle(tbRank);
                tbRank.Style.Font.Bold = true;
                TableRoundRobin.Body.SetCellContent(initialRowPoint3, initialColumnPoint3, tbRank, 3, 1);
                tableItems.Add(tbRank);
            }

            TableRoundRobin.Location = OldTableLocation;
            TableRoundRobin.Size = new SizeU(columnWidth.Multiply(columns.Count), Unit.Cm(1.1085416078567505D));
            TableRoundRobin.Name = "TableRoundRobin";

            TableRoundRobin.Items.AddRange(tableItems.ToArray());
            detail.Items.AddRange(new ReportItemBase[] { TableRoundRobin });

            TableRoundRobin.DataSource = tableRoundRobinOds;
        }

        public void ApplyTextBoxStyle(TextBox tb)
        {
            tb.Style.TextAlign = HorizontalAlign.Center;
            tb.Style.BorderStyle.Default = BorderType.Solid;
            tb.Style.BorderWidth.Default = new Unit(1);
            tb.Style.VerticalAlign = VerticalAlign.Middle;
        }
    }
}