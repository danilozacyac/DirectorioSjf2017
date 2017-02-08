using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioSjf2017.Reportes
{
    public class WordReport
    {
       
        Microsoft.Office.Interop.Word.Application oWord;
        Microsoft.Office.Interop.Word.Document aDoc;
        object oMissing = System.Reflection.Missing.Value;
        object oEndOfDoc = "\\endofdoc";


        public void ListadoEncargados()
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            oWord.Visible = true;
            aDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            int i = 0;
            int j = 0;
            Microsoft.Office.Interop.Word.Table objTable;
            Microsoft.Office.Interop.Word.Range wrdRng = aDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

            string strText;
            objTable = aDoc.Tables.Add(wrdRng, 4, 2, ref oMissing, ref oMissing);
            objTable.Range.ParagraphFormat.SpaceAfter = 7;
            strText = "ABC Company";
            objTable.Rows[1].Range.Text = strText;
            objTable.Rows[1].Range.Font.Bold = 1;
            objTable.Rows[1].Range.Font.Size = 12;
            objTable.Rows[1].Range.Font.Position = 1;
            objTable.Rows[1].Range.Font.Name = "Times New Roman";
            objTable.Rows[1].Cells[1].Merge(objTable.Rows[1].Cells[2]);
            objTable.Cell(1, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

            objTable.Rows[2].Range.Font.Size = 12;
            objTable.Rows[1].Range.Font.Bold = 1;
            objTable.Cell(2, 1).Range.Text = "TRIBUNAL COLEGIADO DE CIRCUITO";
            objTable.Cell(2, 2).Range.Text = "ENCARGADO";
            objTable.Cell(2, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            objTable.Cell(2, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

            for (i = 3; i <= 4; i++)
            {
                objTable.Rows[i].Range.Font.Bold = 0;
                objTable.Rows[i].Range.Font.Italic = 0;
                objTable.Rows[i].Range.Font.Size = 12;
                for (j = 1; j <= 2; j++)
                {
                    if (j == 1)
                        objTable.Cell(i, j).Range.Text = "Item " + (i - 1);
                    else
                        objTable.Cell(i, j).Range.Text = "Price of " + (i - 1);
                }
            }

            try
            {
                objTable.Borders.Shadow = true;
                objTable.Borders.Shadow = true;
            }
            catch
            {
            }
        }



    }
}
