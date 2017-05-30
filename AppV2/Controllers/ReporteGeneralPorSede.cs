using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using Entidades;
namespace AppV2.Controllers
{
    public class ReporteGeneralPorSede
    {

        
        WorkbookPart wbPart = null;
        SpreadsheetDocument document = null;
        Presupuesto presup = null;

        public ReporteGeneralPorSede(string fuente,string destino,Presupuesto presup)
        {
            CopyFile(fuente, destino);
            document = SpreadsheetDocument.Open(destino, true);
            wbPart = document.WorkbookPart;
            this.presup = presup;
        }

        private string CopyFile(string source, string dest)
        {
            string result = "Copied file";
            try
            {
                // Overwrites existing files
                File.Copy(source, dest, true);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        private Cell InsertCellInWorksheet(Worksheet ws, string addressName)
        {
            SheetData sheetData = ws.GetFirstChild<SheetData>();
            Cell cell = null;

            UInt32 rowNumber = GetRowIndex(addressName);
            Row row = GetRow(sheetData, rowNumber);

            // If the cell you need already exists, return it.
            // If there is not a cell with the specified column name, insert one.  
            Cell refCell = row.Elements<Cell>().
                Where(c => c.CellReference.Value == addressName).FirstOrDefault();
            if (refCell != null)
            {
                cell = refCell;
            }
            else
            {
                cell = CreateCell(row, addressName);
            }
            return cell;
        }

        // Add a cell with the specified address to a row.
        private Cell CreateCell(Row row, String address)
        {
            Cell cellResult;
            Cell refCell = null;

            // Cells must be in sequential order according to CellReference. 
            // Determine where to insert the new cell.
            foreach (Cell cell in row.Elements<Cell>())
            {
                if (string.Compare(cell.CellReference.Value, address, true) > 0)
                {
                    refCell = cell;
                    break;
                }
            }

            cellResult = new Cell();
            cellResult.CellReference = address;

            row.InsertBefore(cellResult, refCell);
            return cellResult;
        }

        // Return the row at the specified rowIndex located within
        // the sheet data passed in via wsData. If the row does not
        // exist, create it.
        private Row GetRow(SheetData wsData, UInt32 rowIndex)
        {
            var row = wsData.Elements<Row>().
            Where(r => r.RowIndex.Value == rowIndex).FirstOrDefault();
            if (row == null)
            {
                row = new Row();
                row.RowIndex = rowIndex;
                wsData.Append(row);
            }
            return row;
        }

        // Given an Excel address such as E5 or AB128, GetRowIndex
        // parses the address and returns the row index.
        private UInt32 GetRowIndex(string address)
        {
            string rowPart;
            UInt32 l;
            UInt32 result = 0;

            for (int i = 0; i < address.Length; i++)
            {
                if (UInt32.TryParse(address.Substring(i, 1), out l))
                {
                    rowPart = address.Substring(i, address.Length - i);
                    if (UInt32.TryParse(rowPart, out l))
                    {
                        result = l;
                        break;
                    }
                }
            }
            return result;
        }

        public bool UpdateValue(string sheetName, string addressName, string value,
                                UInt32Value styleIndex, bool isString)
        {
            // Assume failure.
            bool updated = false;

            Sheet sheet = wbPart.Workbook.Descendants<Sheet>().Where(
                (s) => s.Name == sheetName).FirstOrDefault();

            if (sheet != null)
            {
                Worksheet ws = ((WorksheetPart)(wbPart.GetPartById(sheet.Id))).Worksheet;
                Cell cell = InsertCellInWorksheet(ws, addressName);

                if (isString)
                {
                    // Either retrieve the index of an existing string,
                    // or insert the string into the shared string table
                    // and get the index of the new item.
                    int stringIndex = InsertSharedStringItem(wbPart, value);

                    cell.CellValue = new CellValue(stringIndex.ToString());
                    cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                }
                else
                {
                    cell.CellValue = new CellValue(value);
                    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                }

                if (styleIndex > 0)
                    cell.StyleIndex = styleIndex;

                // Save the worksheet.
                ws.Save();
                updated = true;
            }

            return updated;
        }

        // Given the main workbook part, and a text value, insert the text into 
        // the shared string table. Create the table if necessary. If the value 
        // already exists, return its index. If it doesn't exist, insert it and 
        // return its new index.
        private int InsertSharedStringItem(WorkbookPart wbPart, string value)
        {
            int index = 0;
            bool found = false;
            var stringTablePart = wbPart
                .GetPartsOfType<SharedStringTablePart>().FirstOrDefault();

            // If the shared string table is missing, something's wrong.
            // Just return the index that you found in the cell.
            // Otherwise, look up the correct text in the table.
            if (stringTablePart == null)
            {
                // Create it.
                stringTablePart = wbPart.AddNewPart<SharedStringTablePart>();
            }

            var stringTable = stringTablePart.SharedStringTable;
            if (stringTable == null)
            {
                stringTable = new SharedStringTable();
            }

            // Iterate through all the items in the SharedStringTable. 
            // If the text already exists, return its index.
            foreach (SharedStringItem item in stringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == value)
                {
                    found = true;
                    break;
                }
                index += 1;
            }

            if (!found)
            {
                stringTable.AppendChild(new SharedStringItem(new Text(value)));
                stringTable.Save();
            }

            return index;
        }

        private bool RemoveCellValue(string sheetName, string addressName)
        {
            bool returnValue = false;

            Sheet sheet = wbPart.Workbook.Descendants<Sheet>().
                Where(s => s.Name == sheetName).FirstOrDefault();
            if (sheet != null)
            {
                Worksheet ws = ((WorksheetPart)(wbPart.GetPartById(sheet.Id))).Worksheet;
                Cell cell = InsertCellInWorksheet(ws, addressName);

                // If there is a cell value, remove it to force a recalculation
                // on this cell.
                if (cell.CellValue != null)
                {
                    cell.CellValue.Remove();
                }

                // Save the worksheet.
                ws.Save();
                returnValue = true;
            }

            return returnValue;
        }

        // Create a new Portfolio report
        public void CreateReport()
        {


            string wsName = "";

            foreach (DetallePresupuesto detPresup in presup.TiposPresupuestos)
            {
                if (detPresup.tipoPresupuesto.idTipoPresupuesto == 1) {
                    wsName = "Gasto Capital";
                    UpdateValue(wsName, "B6", presup.nombrePresupuesto, 0, true);
                    UpdateValue(wsName, "B3 ", "FORMULACION PRESUPUESTAL - "+ presup.fechaValIni.Date.Year , 0, true);
                    int fila = 11;

                    UpdateValue(wsName, "B" + fila, "Materiales y suministros", 0, true);
                    fila = fila + 1;
                    foreach (DetalleVersion detVer in detPresup.detalleDeVersiones)
                    {
                        if (detVer.tipo == 1)
                        {
                            
                            UpdateValue(wsName, "B" + fila, detVer.NombreMaterialSoli, 0, true);
                            UpdateValue(wsName, "C" + fila, detVer.cantidadSoli.ToString(), 0, false);
                            UpdateValue(wsName, "D" + fila, detVer.codCentroCosto, 0, true);
                            UpdateValue(wsName, "E" + fila, detVer.totalSoli.ToString(), 0, false);
                            UpdateValue(wsName, "F" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Enero) ? "X" : "", 0, true);
                            UpdateValue(wsName, "G" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Febrero) ? "X" : "", 0, true);
                            UpdateValue(wsName, "H" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Marzo) ? "X" : "", 0, true);
                            UpdateValue(wsName, "I" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Abril) ? "X" : "", 0, true);
                            UpdateValue(wsName, "J" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Mayo) ? "X" : "", 0, true);
                            UpdateValue(wsName, "K" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Junio) ? "X" : "", 0, true);
                            UpdateValue(wsName, "L" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Julio) ? "X" : "", 0, true);
                            UpdateValue(wsName, "M" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Agosto) ? "X" : "", 0, true);
                            UpdateValue(wsName, "N" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Setiembre) ? "X" : "", 0, true);
                            UpdateValue(wsName, "O" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Octubre) ? "X" : "", 0, true);
                            UpdateValue(wsName, "P" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Noviembre) ? "X" : "", 0, true);
                            UpdateValue(wsName, "Q" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Diciembre) ? "X" : "", 0, true);
                            UpdateValue(wsName, "R" + fila, detVer.sustento, 0, true);
                            fila = fila + 1;
                        }
                    }

                    UpdateValue(wsName, "B" + fila, "Servicios", 0, true);
                    fila = fila + 1;
                    foreach (DetalleVersion detVer in detPresup.detalleDeVersiones)
                    {
                        if (detVer.tipo == 2)
                        {
                            
                            UpdateValue(wsName, "B" + fila, detVer.NombreMaterialSoli, 0, true);
                            UpdateValue(wsName, "C" + fila, detVer.cantidadSoli.ToString(), 0, false);
                            UpdateValue(wsName, "D" + fila, detVer.codCentroCosto, 0, true);
                            UpdateValue(wsName, "E" + fila, detVer.totalSoli.ToString(), 0, false);
                            UpdateValue(wsName, "F" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Enero) ? "X" : "", 0, true);
                            UpdateValue(wsName, "G" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Febrero) ? "X" : "", 0, true);
                            UpdateValue(wsName, "H" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Marzo) ? "X" : "", 0, true);
                            UpdateValue(wsName, "I" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Abril) ? "X" : "", 0, true);
                            UpdateValue(wsName, "J" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Mayo) ? "X" : "", 0, true);
                            UpdateValue(wsName, "K" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Junio) ? "X" : "", 0, true);
                            UpdateValue(wsName, "L" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Julio) ? "X" : "", 0, true);
                            UpdateValue(wsName, "M" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Agosto) ? "X" : "", 0, true);
                            UpdateValue(wsName, "N" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Setiembre) ? "X" : "", 0, true);
                            UpdateValue(wsName, "O" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Octubre) ? "X" : "", 0, true);
                            UpdateValue(wsName, "P" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Noviembre) ? "X" : "", 0, true);
                            UpdateValue(wsName, "Q" + fila, detVer.contieneMesSoli((int)MesEntSoli.Meses.Diciembre) ? "X" : "", 0, true);
                            UpdateValue(wsName, "R" + fila, detVer.sustento, 0, true);
                            fila = fila + 1;
                        }
                    }

                }
                                
                
            }
            

           

      
            // Force re-calc when the workbook is opened
            //this.RemoveCellValue("Portfolio Summary", "D17");
            //this.RemoveCellValue("Portfolio Summary", "E17");

            // All done! Close and save the document.
            document.Close();
        }

    }
}