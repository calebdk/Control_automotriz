using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;

namespace ControlCarros
{
    class imprimir
    {
         private DataGridView TheDataGridView; // control para imprimir el datagridview
    private PrintDocument ThePrintDocument; // mandar a imprimir el documento
    private bool IsCenterOnPage; // Determinar si el informe se imprimirá en la parte superior central de la página
    private bool IsWithTitle; // Determinar si la página contiene el texto del título
    private string TheTitleText; // El texto del título que desea imprimir en cada página (si IsWithTitle se establece en true)
    private Font TheTitleFont; //El tipo de letra que se utilizará con el texto del título (si IsWithTitle se establece en true)
    private Color TheTitleColor; // el color de letra que se utilizara en el texto (if IsWithTitle is set to true)
    private bool IsWithPaging; // determinar paginas

    static int CurrentRow; // parámetro estático que seguir la pista en la que la fila (en el control DataGridView) que debe ser impreso
    static int PageNumber;

    private int PageWidth;
    private int PageHeight;
    private int LeftMargin;
    private int TopMargin;
    private int RightMargin;
    private int BottomMargin;

    private float CurrentY; //Un parámetro que realizar un seguimiento de la coordenada y de la página, así que el siguiente objeto a imprimir se iniciará a partir de esta coordenada
    private float RowHeaderHeight;
    private List<float> RowsHeight;
    private List<float> ColumnsWidth;
    private float TheDataGridViewWidth;
        
    // Mantenga una lista genérica de pulsado start / stop puntos para la impresión de la columna
    // Esto será utilizado para envolver en situaciones donde el DataGridView no caben en una sola página
    private List<int[]> mColumnPoints;
    private List<float> mColumnPointsWidth;
    private int mColumnPoint;
        
    // esta es la clase que construira el archivo
    public imprimir(DataGridView aDataGridView, PrintDocument aPrintDocument, bool CenterOnPage, bool WithTitle, string aTitleText, Font aTitleFont, Color aTitleColor, bool WithPaging)
    {
        TheDataGridView = aDataGridView;
        ThePrintDocument = aPrintDocument;
        IsCenterOnPage = CenterOnPage;
        IsWithTitle = WithTitle;
        TheTitleText = aTitleText;
        TheTitleFont = aTitleFont;
        TheTitleColor = aTitleColor;
        IsWithPaging = WithPaging;

        PageNumber = 0;

        RowsHeight = new List<float>();
        ColumnsWidth = new List<float>();

        mColumnPoints = new List<int[]>();
        mColumnPointsWidth = new List<float>();

        //Cálculo del ancho de página y el alto de página
        if (!ThePrintDocument.DefaultPageSettings.Landscape)
        {
            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
        }
        else
        {
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
        }

        //El cálculo de los márgenes de la página
        LeftMargin = ThePrintDocument.DefaultPageSettings.Margins.Left;
        TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;
        RightMargin = ThePrintDocument.DefaultPageSettings.Margins.Right;
        BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;

        //En primer lugar, la fila actual a imprimir es la primera fila del control DataGridView
        CurrentRow = 0;
    }

    //La función que calcular la altura de cada fila (incluyendo la fila de encabezado), la anchura de cada columna (de acuerdo con el texto más largo en todas sus células, incluyendo la celda de encabezado), y toda la anchura DataGridView 
    private void Calculate(Graphics g)
    {
        if (PageNumber == 0) //Sólo calcular una vez
        {
            SizeF tmpSize = new SizeF();
            Font tmpFont;
            float tmpWidth;

            TheDataGridViewWidth = 0;
            for (int i = 0; i < TheDataGridView.Columns.Count; i++)
            {
                tmpFont = TheDataGridView.ColumnHeadersDefaultCellStyle.Font;
                if (tmpFont == null) //Si no hay un estilo especial Cabecera de fuente, a continuación, utilizar el estilo de fuente DataGridView predeterminada
                    tmpFont = TheDataGridView.DefaultCellStyle.Font;

                tmpSize = g.MeasureString(TheDataGridView.Columns[i].HeaderText, tmpFont);
                tmpWidth = tmpSize.Width;
                RowHeaderHeight = tmpSize.Height;

                for (int j = 0; j < TheDataGridView.Rows.Count; j++)
                {
                    tmpFont = TheDataGridView.Rows[j].DefaultCellStyle.Font;
                    if (tmpFont == null) //Si no hay un estilo de fuente especial de la CurrentRow, a continuación, utilice la opción por defecto asociado al control DataGridView
                        tmpFont = TheDataGridView.DefaultCellStyle.Font;

                    tmpSize = g.MeasureString("Anything", tmpFont);
                    RowsHeight.Add(tmpSize.Height);

                    tmpSize = g.MeasureString(TheDataGridView.Rows[j].Cells[i].EditedFormattedValue.ToString(), tmpFont);
                    if (tmpSize.Width > tmpWidth)
                        tmpWidth = tmpSize.Width;
                }
                if (TheDataGridView.Columns[i].Visible)
                    TheDataGridViewWidth += tmpWidth;
                ColumnsWidth.Add(tmpWidth);
            }

            //Definir el inicio / parada de los puntos de columna basado en el ancho de la página y el ancho DataGridView
            //Vamos a utilizar este permiso para determinar las columnas que se señalan en cada página y cómo se manejará el envoltorio
            //De forma predeterminada, el envoltorio se producirá de manera que el número máximo de columnas en una página será determinar
            int k;

            int mStartPoint = 0;
            for (k = 0; k < TheDataGridView.Columns.Count; k++)
                if (TheDataGridView.Columns[k].Visible)
                {
                    mStartPoint = k;
                    break;
                }

            int mEndPoint = TheDataGridView.Columns.Count;
            for (k = TheDataGridView.Columns.Count - 1; k >= 0; k--)
                if (TheDataGridView.Columns[k].Visible)
                {
                    mEndPoint = k + 1;
                    break;
                }

            float mTempWidth = TheDataGridViewWidth;
            float mTempPrintArea = (float)PageWidth - (float)LeftMargin - (float)RightMargin;

            //Sólo nos preocupamos por el manejo que el ancho total DataGridView es más grande que el área de impresión
            if (TheDataGridViewWidth > mTempPrintArea)
            {
                mTempWidth = 0.0F;
                for (k = 0; k < TheDataGridView.Columns.Count; k++)
                {
                    if (TheDataGridView.Columns[k].Visible)
                    {
                        mTempWidth += ColumnsWidth[k];
                        //Si la anchura es mayor que el área de la página, a continuación, definir un nuevo rango de impresión columna
                        if (mTempWidth > mTempPrintArea)
                        {
                            mTempWidth -= ColumnsWidth[k];
                            mColumnPoints.Add(new int[] { mStartPoint, mEndPoint });
                            mColumnPointsWidth.Add(mTempWidth);
                            mStartPoint = k;
                            mTempWidth = ColumnsWidth[k];
                        }
                    }
                    //El punto final es en realidad un índice por encima del índice actual
                    mEndPoint = k + 1;
                }
            }
            //Añadir el último conjunto de columnas
            mColumnPoints.Add(new int[] { mStartPoint, mEndPoint });
            mColumnPointsWidth.Add(mTempWidth);
            mColumnPoint = 0;
        }
    }

    //La función que imprime el título, número de página, y la fila de encabezado
    private void DrawHeader(Graphics g)
    {
        CurrentY = (float)TopMargin;

        //Impresión del número de página (si isWithPaging se establece en true)
        if (IsWithPaging)
        {
            PageNumber++;
            string PageString = "Page " + PageNumber.ToString();

            StringFormat PageStringFormat = new StringFormat();
            PageStringFormat.Trimming = StringTrimming.Word;
            PageStringFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            PageStringFormat.Alignment = StringAlignment.Far;

            Font PageStringFont = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);

            RectangleF PageStringRectangle = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(PageString, PageStringFont).Height);

            g.DrawString(PageString, PageStringFont, new SolidBrush(Color.Black), PageStringRectangle, PageStringFormat);

            CurrentY += g.MeasureString(PageString, PageStringFont).Height;
        }

        //Impresión del título (si IsWithTitle se establece en true)
        if (IsWithTitle)
        {
            StringFormat TitleFormat = new StringFormat();
            TitleFormat.Trimming = StringTrimming.Word;
            TitleFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            if (IsCenterOnPage)
                TitleFormat.Alignment = StringAlignment.Center;
            else
                TitleFormat.Alignment = StringAlignment.Near;

            RectangleF TitleRectangle = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(TheTitleText, TheTitleFont).Height);

            g.DrawString(TheTitleText, TheTitleFont, new SolidBrush(TheTitleColor), TitleRectangle, TitleFormat);

            CurrentY += g.MeasureString(TheTitleText, TheTitleFont).Height;
        }

        //Cálculo de la coordenada x de partida que el proceso de impresión se iniciará a partir
        float CurrentX = (float)LeftMargin;
        if (IsCenterOnPage)            
            CurrentX += (((float)PageWidth - (float)RightMargin - (float)LeftMargin) - mColumnPointsWidth[mColumnPoint]) / 2.0F;

        //Ajuste el estilo HeaderFore
        Color HeaderForeColor = TheDataGridView.ColumnHeadersDefaultCellStyle.ForeColor;
        if (HeaderForeColor.IsEmpty) // If there is no special HeaderFore style, then use the default DataGridView style
            HeaderForeColor = TheDataGridView.DefaultCellStyle.ForeColor;
        SolidBrush HeaderForeBrush = new SolidBrush(HeaderForeColor);

        // ajustes  de estilos HeaderBack 
        Color HeaderBackColor = TheDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
        if (HeaderBackColor.IsEmpty) // If there is no special HeaderBack style, then use the default DataGridView style
            HeaderBackColor = TheDataGridView.DefaultCellStyle.BackColor;
        SolidBrush HeaderBackBrush = new SolidBrush(HeaderBackColor);

        //Ajuste de la LinePen que se utiliza para dibujar líneas y rectángulos (derivados de la propiedad Color de cuadrícula del control DataGridView)
        Pen TheLinePen = new Pen(TheDataGridView.GridColor, 1);

        //Ajuste el estilo de fuente Header
        Font HeaderFont = TheDataGridView.ColumnHeadersDefaultCellStyle.Font;
        if (HeaderFont == null) // If there is no special HeaderFont style, then use the default DataGridView font style
            HeaderFont = TheDataGridView.DefaultCellStyle.Font;

        //Calcular y dibujar las HeaderBounds      
        RectangleF HeaderBounds = new RectangleF(CurrentX, CurrentY, mColumnPointsWidth[mColumnPoint], RowHeaderHeight);
        g.FillRectangle(HeaderBackBrush, HeaderBounds);

        //Ajuste del formato que se utilizará para imprimir cada celda de la fila de encabezado
        StringFormat CellFormat = new StringFormat();
        CellFormat.Trimming = StringTrimming.Word;
        CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

        //Impresión de cada celda visible de la fila de encabezado
        RectangleF CellBounds;
        float ColumnWidth;        
        for (int i = (int)mColumnPoints[mColumnPoint].GetValue(0); i < (int)mColumnPoints[mColumnPoint].GetValue(1); i++)
        {
            if (!TheDataGridView.Columns[i].Visible) continue; // If the column is not visible then ignore this iteration

            ColumnWidth = ColumnsWidth[i];

            //Compruebe la alineación actual celular y aplicarlo a la CellFormat
            if (TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Right"))
                CellFormat.Alignment = StringAlignment.Far;
            else if (TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Center"))
                CellFormat.Alignment = StringAlignment.Center;
            else
                CellFormat.Alignment = StringAlignment.Near;

            CellBounds = new RectangleF(CurrentX, CurrentY, ColumnWidth, RowHeaderHeight);

            //La impresión del texto de la celda
            g.DrawString(TheDataGridView.Columns[i].HeaderText, HeaderFont, HeaderForeBrush, CellBounds, CellFormat);

            //Dibujo de los límites de celdas
            if (TheDataGridView.RowHeadersBorderStyle != DataGridViewHeaderBorderStyle.None) // Draw the cell border only if the HeaderBorderStyle is not None
                g.DrawRectangle(TheLinePen, CurrentX, CurrentY, ColumnWidth, RowHeaderHeight);

            CurrentX += ColumnWidth;
        }

        CurrentY += RowHeaderHeight;
    }

    //La función que imprime un montón de filas que caben en una página
    //Cuando se devuelve true, lo que significa que hay más filas aún no se han impreso, por lo que se requiere otra página Imprimir esta acción
    //Cuando se devuelve false, lo que significa que todas las filas se imprimen (el parámetro CureentRow llega a la última fila del control DataGridView) y no se requiere ninguna acción adicional PagePrint
    private bool DrawRows(Graphics g)
    {
        //Ajuste de la LinePen que se utiliza para dibujar líneas y rectángulos (derivados de la propiedad Color de cuadrícula del control DataGridView)
        Pen TheLinePen = new Pen(TheDataGridView.GridColor, 1);

        //Los parámetros de estilo que se utilizarán para imprimir cada celda 
        Font RowFont;
        Color RowForeColor;
        Color RowBackColor;
        SolidBrush RowForeBrush;
        SolidBrush RowBackBrush;
        SolidBrush RowAlternatingBackBrush;

        //Ajuste del formato que se utiliza para imprimir cada celda
        StringFormat CellFormat = new StringFormat();
        CellFormat.Trimming = StringTrimming.Word;
        CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;

        //Impresión de cada celda visible
        RectangleF RowBounds;
        float CurrentX;
        float ColumnWidth;
        while (CurrentRow < TheDataGridView.Rows.Count)
        {
            if (TheDataGridView.Rows[CurrentRow].Visible) // Print the cells of the CurrentRow only if that row is visible
            {
                //Ajuste el estilo de fuente fila
                RowFont = TheDataGridView.Rows[CurrentRow].DefaultCellStyle.Font;
                if (RowFont == null) //Si no hay un estilo de fuente especial de la CurrentRow, a continuación, utilice la opción por defecto asociado al control DataGridView
                    RowFont = TheDataGridView.DefaultCellStyle.Font;

                // Ajuste del estilo RowFore
                RowForeColor = TheDataGridView.Rows[CurrentRow].DefaultCellStyle.ForeColor;
                if (RowForeColor.IsEmpty) //Si no hay un estilo RowFore especial del CurrentRow, a continuación, utilice la opción por defecto asociado al control DataGridView
                    RowForeColor = TheDataGridView.DefaultCellStyle.ForeColor;
                RowForeBrush = new SolidBrush(RowForeColor);

                //Ajuste de la RowBack (para las filas pares) y la RowAlternatingBack (para las filas impares) estilos
                RowBackColor = TheDataGridView.Rows[CurrentRow].DefaultCellStyle.BackColor;
                if (RowBackColor.IsEmpty) //Si no hay un estilo RowBack especial del CurrentRow, a continuación, utilice la opción por defecto asociado al control DataGridView
                {
                    RowBackBrush = new SolidBrush(TheDataGridView.DefaultCellStyle.BackColor);
                    RowAlternatingBackBrush = new SolidBrush(TheDataGridView.AlternatingRowsDefaultCellStyle.BackColor);
                }
                else //Si hay un estilo RowBack especial del CurrentRow, a continuación, utilizarlo tanto para el RowBack y los estilos RowAlternatingBack
                {
                    RowBackBrush = new SolidBrush(RowBackColor);
                    RowAlternatingBackBrush = new SolidBrush(RowBackColor);
                }

                //Cálculo de la coordenada x de partida que el proceso de impresión se iniciará a partir
                CurrentX = (float)LeftMargin;
                if (IsCenterOnPage)                    
                    CurrentX += (((float)PageWidth - (float)RightMargin - (float)LeftMargin) - mColumnPointsWidth[mColumnPoint]) / 2.0F;

                //Cálculo de la totalidad de los límites CurrentRow             
                RowBounds = new RectangleF(CurrentX, CurrentY, mColumnPointsWidth[mColumnPoint], RowsHeight[CurrentRow]);

                //Llenado de la parte posterior de la CurrentRow
                if (CurrentRow % 2 == 0)
                    g.FillRectangle(RowBackBrush, RowBounds);
                else
                    g.FillRectangle(RowAlternatingBackBrush, RowBounds);

                //Impresión de cada celda visible de la CurrentRow            
                for (int CurrentCell = (int)mColumnPoints[mColumnPoint].GetValue(0); CurrentCell < (int)mColumnPoints[mColumnPoint].GetValue(1); CurrentCell++)
                {
                    if (!TheDataGridView.Columns[CurrentCell].Visible) continue; //Si la célula está pertenecen a la columna invisible, entonces ignorar esta iteración

                    //Compruebe la alineación actual de la celda y aplicarlo al formato de celda
                    if (TheDataGridView.Columns[CurrentCell].DefaultCellStyle.Alignment.ToString().Contains("Right"))
                        CellFormat.Alignment = StringAlignment.Far;
                    else if (TheDataGridView.Columns[CurrentCell].DefaultCellStyle.Alignment.ToString().Contains("Center"))
                        CellFormat.Alignment = StringAlignment.Center;
                    else
                        CellFormat.Alignment = StringAlignment.Near;
                    
                    ColumnWidth = ColumnsWidth[CurrentCell];
                    RectangleF CellBounds = new RectangleF(CurrentX, CurrentY, ColumnWidth, RowsHeight[CurrentRow]);

                    // imprimir la siguientes celdas
                    g.DrawString(TheDataGridView.Rows[CurrentRow].Cells[CurrentCell].EditedFormattedValue.ToString(), RowFont, RowForeBrush, CellBounds, CellFormat);

                    //Dibujo de los límites  de las celdas
                    if (TheDataGridView.CellBorderStyle != DataGridViewCellBorderStyle.None) // Draw the cell border only if the CellBorderStyle is not None
                        g.DrawRectangle(TheLinePen, CurrentX, CurrentY, ColumnWidth, RowsHeight[CurrentRow]);

                    CurrentX += ColumnWidth;
                }
                CurrentY += RowsHeight[CurrentRow];

                // Verificando la  celda es superior a los límites de la página
                //Si es así, salir de la función y devolver verdadero significado se requiere otra página Imprimir esta acción
                if ((int)CurrentY > (PageHeight - TopMargin - BottomMargin))
                {
                    CurrentRow++;
                    return true;
                }
            }
            CurrentRow++;
        }

        CurrentRow = 0;
        mColumnPoint++; //Continuar para imprimir el siguiente grupo de columnas
        if (mColumnPoint == mColumnPoints.Count) //Lo que significa que todas las columnas se imprimen
        {
            mColumnPoint = 0;
            return false;
        }
        else
            return true;
    }

    //metodo para llamar a las otras funciones
    public bool DrawDataGridView(Graphics g)
    {
        try
        {
            Calculate(g);
            DrawHeader(g);
            bool bContinue = DrawRows(g);
            return bContinue;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Operation failed: " + ex.Message.ToString(), Application.ProductName + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    }
}
