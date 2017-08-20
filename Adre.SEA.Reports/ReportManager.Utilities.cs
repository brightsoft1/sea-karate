using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using Telerik.Reporting;

namespace Adre.SEA.Reports
{
    public static partial class ReportManager
    {
        public static void AddBasicReportParameters(InstanceReportSource reportSource)
        {
            var settings = new List<string>
            {
                "ReportMainHeaderLabel",
                "ReportLeftLogoPath",
                "ReportRightLogoPath",
                "ReportRightLogoLabel"
            };

            foreach (var setting in settings) reportSource.Parameters.Add(setting, ConfigurationManager.AppSettings[setting]);
        }

        public static void AddReportParameters(InstanceReportSource reportSource, dynamic dynamicObject)
        {
            var props = dynamicObject.GetType().GetProperties();

            foreach (var prop in props)
            {
                reportSource.Parameters.Add(prop.Name, prop.GetValue(dynamicObject));
            }
        }


        public static InstanceReportSource LoadInstanceReportSourceFromFile(string path)
        {
            InstanceReportSource result = null;

            var combinedPath = Path.Combine(ConfigurationManager.AppSettings["ReportPath"], path);

            using (var sourceStream = File.OpenRead(combinedPath))
            {
                var reportPackager = new ReportPackager();
                var report = (Report)reportPackager.UnpackageDocument(sourceStream);
                if (report != null) result = new InstanceReportSource { ReportDocument = report };
            }

            return result;
        }

        private static InstanceReportSource LoadInstanceReportSourceFromClass(IReportDocument report)
        {
            var reportSource = new InstanceReportSource { ReportDocument = report };
            return reportSource;
        }

        private static InstanceReportSource LoadInstanceReportSourceFromClass<T>() where T : new()
        {
            var reportSource = new InstanceReportSource { ReportDocument = (IReportDocument)new T() };


            return reportSource;
        }

        public static DataSet GenerateDataSetFromDynamicObject(List<dynamic> dynamicObjects)
        {
            var result = new DataSet();
            var table = new DataTable();

            foreach (var dynamicObject in dynamicObjects)
            {
                var newRow = table.NewRow();

                if (dynamicObject is ExpandoObject)
                {
                    foreach (KeyValuePair<string, object> prop in dynamicObject)
                    {
                        if (!table.Columns.Contains(prop.Key))
                        {
                            table.Columns.Add(prop.Key);
                        }

                        newRow[prop.Key] = prop.Value;
                    }

                }
                else
                {
                    var props = dynamicObject.GetType().GetProperties();

                    foreach (var prop in props)
                    {
                        if (!table.Columns.Contains(prop.Name))
                        {
                            table.Columns.Add(prop.Name);
                        }

                        newRow[prop.Name] = prop.GetValue(dynamicObject);
                    }
                }

                table.Rows.Add(newRow);
            }

            result.Tables.Add(table);

            return result;
        }

        public static Table FindTable(InstanceReportSource reportSource, string tableName)
        {
            return FindTable(reportSource.ReportDocument, tableName);
        }

        public static Table FindTable(IReportDocument reportDocument, string tableName)
        {
            return (Table)((Report)reportDocument).Items.Find(tableName, true).FirstOrDefault();
        }

        public static TextBox FindTextBox(InstanceReportSource reportSource, string textboxName)
        {
            return FindTextBox(reportSource.ReportDocument, $"txt{textboxName}");
        }

        public static TextBox FindTextBox(IReportDocument reportDocument, string textboxName)
        {
            return (TextBox)((Report)reportDocument).Items.Find(textboxName, true).FirstOrDefault();
        }

        public static void SetTextBoxValue(this InstanceReportSource reportSource, string textboxName, string value)
        {
            var textBox = FindTextBox(reportSource, textboxName);
            if (textBox != null) textBox.Value = value;
        }

        private static void SetReportTableDataSource(InstanceReportSource reportSource, string tableName, DataSource dataSource)
        {
            var table = FindTable(reportSource, tableName);
            if (table != null) table.DataSource = dataSource;
        }

        private static void SetReportDataSource(InstanceReportSource reportSource, ObjectDataSource objectDataSource)
        {
            ((Report)reportSource.ReportDocument).DataSource = objectDataSource;
        }
    }
}
