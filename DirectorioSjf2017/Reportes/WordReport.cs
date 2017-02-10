using DirectorioSjf2017.Dto;
using DirectorioSjf2017.Singletons;
using Microsoft.Office.Interop.Word;
using PadronApi.Dto;
using PadronApi.Singletons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioSjf2017.Reportes
{
    public class WordReport
    {

        private string ordenMateriasTcEncargados = ConfigurationManager.AppSettings["OrdenMatTCEncargados"].ToString();

        Microsoft.Office.Interop.Word.Application oWord;
        Microsoft.Office.Interop.Word.Document aDoc;
        object oMissing = System.Reflection.Missing.Value;
        object oEndOfDoc = "\\endofdoc";


        public void ListadoEncargados()
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            oWord.Visible = true;
            aDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);


            Microsoft.Office.Interop.Word.Paragraph oPara1;
            oPara1 = aDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = ConfigurationManager.AppSettings["TituloTCEncargados"].ToString();
            oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
            oPara1.Range.InsertParagraphAfter();
            oPara1.Range.InsertParagraphAfter();

            foreach (string materia in ordenMateriasTcEncargados.Split(','))
            {
                foreach (Ordinales circuito in OrdinalSingleton.Ordinales)
                {
                    var organismosPrint = (from n in OrganismoDirSingleton.Organismos
                                           where n.TipoOrganismo == 2 && n.Materia.StartsWith(materia) && n.Circuito == circuito.IdOrdinal
                                          orderby n.Ordinal
                                          select n);

                    List<TribEncargados> relacionEncargados = new List<TribEncargados>();

                    foreach (Organismo org in (from n in organismosPrint orderby n.Ordinal select n))
                    {
                        List<Encargado> encargados = (from n in EncargadosSingleton.Encargados
                                                      where n.IdOrganismo == org.IdOrganismo
                                                      orderby n.Apellidos
                                                      select n).ToList();

                        if (encargados.Count > 0)
                            relacionEncargados.Add(new TribEncargados(this.TribunalOrdinal(org.Ordinal), this.BuildEncargadosString(encargados),MateriaTribunal(org.Materia).ToUpper()));
                    }

                    if (relacionEncargados.Count > 0)
                    {

                        string strText;

                        Microsoft.Office.Interop.Word.Range wrdRng = aDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        Microsoft.Office.Interop.Word.Table objTable = aDoc.Tables.Add(wrdRng, relacionEncargados.Count + 2, 2, ref oMissing, ref oMissing);

                        objTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                        objTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                        //objTable.Range.ParagraphFormat.SpaceAfter = 7;
                        strText = String.Format("{0} CIRCUITO {1}", circuito.Ordinal.ToUpper(),relacionEncargados[0].Materia);
                        objTable.Rows[1].Range.Text = strText;
                        objTable.Rows[1].Range.Font.Bold = 1;
                        objTable.Rows[1].Range.Font.Size = 12;
                        objTable.Rows[1].Range.Font.Position = 1;
                        objTable.Rows[1].Range.Font.Name = "Arial";
                        objTable.Rows[1].Cells[1].Merge(objTable.Rows[1].Cells[2]);
                        objTable.Cell(1, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                        objTable.Rows[2].Range.Font.Size = 12;
                        objTable.Rows[2].Range.Font.Bold = 1;
                        objTable.Cell(2, 1).Range.Text = "TRIBUNAL COLEGIADO DE CIRCUITO";
                        objTable.Cell(2, 2).Range.Text = "ENCARGADO";
                        objTable.Cell(2, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        objTable.Cell(2, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                        int currentRow = 3;

                        foreach (TribEncargados data in relacionEncargados)
                        {
                            objTable.Cell(currentRow, 1).Range.Text = data.Tribunal.ToUpper();
                            objTable.Cell(currentRow, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            objTable.Cell(currentRow, 2).Range.Text = data.Encargados;
                            objTable.Cell(currentRow, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            currentRow++;
                        }

                        oPara1 = aDoc.Content.Paragraphs.Add(ref oMissing);
                        oPara1.Range.Text = String.Empty;
                        oPara1.Range.InsertParagraphAfter();
                        oPara1.Range.InsertParagraphAfter();
                    }

                }
            }

           

            
        }




        private string BuildEncargadosString(List<Encargado> encargados)
        {
            if (encargados.Count == 1)
            {
                return String.Format("{0} {1} {2}", AbrevTitulo(encargados[0].IdTitulo), encargados[0].Nombre, encargados[0].Apellidos);
            }
            else
            {
                return "Aquí hay varios encargados";
            }

            return String.Empty;
        }



        private string AbrevTitulo(int idTitulo)
        {
            Titulo titulo = TituloSingleton.Titulos.FirstOrDefault(x => x.IdTitulo == idTitulo);

            return titulo.TituloAbr;
        }


        private string TribunalOrdinal(int ordinal)
        {
            return string.Format("{0} TRIBUNAL", OrdinalSingleton.Ordinales.FirstOrDefault(x => x.IdOrdinal == ordinal).Ordinal);
        }

        private ObservableCollection<Materia> listaMaterias;
        private string MateriaTribunal(string materia)
        {
            if (listaMaterias == null)
                listaMaterias = new Materia().GetMaterias();

            char[] materias = materia.ToCharArray();

            List<string> matStr = new List<string>();

            foreach (char mat in materias)
            {
                string myMat = listaMaterias.FirstOrDefault(x => x.IdMateria == Convert.ToInt16(mat.ToString())).MateriaDesc;
                matStr.Add(myMat);
            }

            if (matStr.Count == 1)
                return String.Format("(MATERIA {0})", matStr[0]);
            else
                return string.Format("(MATERIAS {0} Y {1})", matStr[0], matStr[1]);

        }
        
    }

    public class TribEncargados
    {
        private string tribunal;
        private string encargados;
        private string materia;

        public TribEncargados(string tribunal, string encargados, string materia)
        {
            this.tribunal = tribunal;
            this.encargados = encargados;
            this.materia = materia;
        }
         public string Tribunal
        {
            get
            {
                return this.tribunal;
            }
        }

        public string Encargados
        {
            get
            {
                return this.encargados;
            }
        }

        public string Materia
        {
            get
            {
                return this.materia;
            }
        }

       
    }
}
