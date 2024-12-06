using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

public class ExcelDataReader
{
    public static List<WorkItem> ReadWorkItemsFromExcel(string filePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        var workItems = new List<WorkItem>();

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
            int totalRows = worksheet.Dimension.End.Row;

            for (int row = 2; row <= totalRows; row++)
            {
                try
                {
                    var workItem = new WorkItem
                    {
                        ID = int.Parse(worksheet.Cells[row, 1].Text),
                        WorkItemType = worksheet.Cells[row, 2].Text,
                        Title = worksheet.Cells[row, 3].Text,
                        AssignedTo = worksheet.Cells[row, 4].Text,
                        State = worksheet.Cells[row, 5].Text,
                        IterationPath = worksheet.Cells[row, 6].Text,
                        AreaPath = worksheet.Cells[row, 7].Text,
                        StoryPoints = string.IsNullOrEmpty(worksheet.Cells[row, 8].Text) ? 0 : double.TryParse(worksheet.Cells[row, 8].Text, out double sp) ? (double?)sp : null,
                        NumberOfCommitsPerStory = string.IsNullOrEmpty(worksheet.Cells[row, 9].Text) ? 0 : int.Parse(worksheet.Cells[row, 9].Text),
                        NumberOfBugsRaised = string.IsNullOrEmpty(worksheet.Cells[row, 10].Text) ? 0 :  int.Parse(worksheet.Cells[row, 10].Text),
                        NumberOfReviewCommentsPerMergeRequest = string.IsNullOrEmpty(worksheet.Cells[row, 11].Text) ? 0 : int.Parse(worksheet.Cells[row, 11].Text),
                        NumberOfDaysToCloseTheStory = string.IsNullOrEmpty(worksheet.Cells[row, 12].Text) ? 0 :  int.Parse(worksheet.Cells[row, 12].Text),
                        BlockerTime = string.IsNullOrEmpty(worksheet.Cells[row, 13].Text) ? 0 : double.TryParse(worksheet.Cells[row, 13].Text, out double bt) ? (double?)bt : null,
                        OriginalEstimateInHours = string.IsNullOrEmpty(worksheet.Cells[row, 14].Text) ? 0 : double.TryParse(worksheet.Cells[row, 14].Text, out double oeh) ? (double?)oeh : null,
                        CompletedEstimateInHours = string.IsNullOrEmpty(worksheet.Cells[row, 15].Text) ? 0 : double.TryParse(worksheet.Cells[row, 15].Text, out double ceh) ? (double?)ceh : null
                    };
                    workItems.Add(workItem);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        return workItems;
    }
}
