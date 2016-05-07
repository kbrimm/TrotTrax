using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TrotTrax
{
    class Reports
    {
        private DBDriver Database { get; set; }
        public string ClubID { get; private set; }
        public int Year { get; private set; }

        public void GenerateReport(ReportType type, int no)
        {
            string clubName = Database.GetCurrentClubName();
            string itemName = GetItemName(type, no);
            List<ResultItem> reportItems = GetReportItems(type, no);
            string reportBody = CreateReportBody(clubName, itemName, reportItems);
            string fileName = CreateFileName(itemName, clubName);
            CreateReportFile(fileName, reportBody);
            OpenReportFile(fileName);
        }

        private string GetItemName(ReportType type, int no)
        {
            string itemName = String.Empty;
            switch(type)
            {
                case ReportType.Category: itemName = Database.GetCategoryItem(no).Name; break;
                case ReportType.Class: itemName = Database.GetClassItem(no).Name; break;
                case ReportType.Horse: itemName = Database.GetHorseItem(no).Name; break;
                case ReportType.Rider: RiderItem riderItem = Database.GetRiderItem(no); 
                                       itemName = riderItem.FirstName + " " + riderItem.LastName; 
                                       break;
                case ReportType.Show: ShowItem showItem = Database.GetShowItem(no);
                                      itemName = showItem.Date.ToString("MM/dd/yyyy");
                                      if (showItem.Name != null) { itemName += " - " + showItem.Name; }
                                      break;
                case ReportType.Year: itemName = Year.ToString(); break;
            }
            return itemName;
        }

        private List<ResultItem> GetReportItems(ReportType type, int no)
        {
            return null;
        }

        private string CreateReportBody(string clubName, string itemName, List<ResultItem> reportItems)
        {
            string body = String.Empty;
            string header;

            foreach (var ResultItem in reportItems)
            {
                
            }

            body += String.Join("\n",
                "        </table>",
                "    </div>",
                "    </div>",
                "</body>",
                "</html>");
            return null;
        }

        private string GetHeaderName(ReportType type, ResultItem item)
        {
            string header = String.Empty;
            switch (type)
            {
                case ReportType.Category: header = item.ShowDate ; break;
                case ReportType.Class: header = item.ShowDate; break;
                //case ReportType.Horse: header = Database.GetHorseItem(no).Name; break;
                //case ReportType.Rider: RiderItem riderItem = Database.GetRiderItem(no);
                //    header = riderItem.FirstName + " " + riderItem.LastName;
                //    break;
                //case ReportType.Show: ShowItem showItem = Database.GetShowItem(no);
                //    header = showItem.Date.ToString("MM/dd/yyyy");
                //    if (showItem.Name != null) { header += " - " + showItem.Name; }
                //    break;
                case ReportType.Year: header = Year.ToString(); break;
                default: header = null; break;
            }
            return header;
        }

        private string CreateFileName(string itemName, string clubName)
        {
            string directory = @"Reports\" + clubName + "\\" + Year + "\\";
            string dateString = DateTime.Now.ToString().Replace(' ', '_');
            string reportString = itemName.Replace(' ', '_');
            reportString = reportString.Replace('&', '_');
            reportString = reportString.Replace('\\', '_');
            return directory + reportString + "_" + dateString + ".html";
        }

        private void CreateReportFile(string fileName, string reportBody)
        {
            // Creates new destination file for current report.
            File.Copy("ReportStyle.html", fileName, true);

            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.Write(reportBody);
            }	
        }

        private void OpenReportFile(string fileName)
        {
            System.Diagnostics.Process.Start(fileName);
        }
    }

    public enum ReportType
    {
        Category,
        Class,
        Horse,
        Rider,
        Show,
        Year
    }
}
