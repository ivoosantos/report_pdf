// See https://aka.ms/new-console-template for more information
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Canvas;
//using System.Drawing;

string path = "C:/iTextPDF_Testes/RelatórioIEQ_Start.pdf";

using (PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new FileStream(path, FileMode.Create, FileAccess.Write))))
{
    using (Document document = new Document(pdfDocument))
    {

        #region
        //Paragraph heading = new Paragraph("Hello world").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(50);
        //document.Add(heading);

        //string intro = "Hello my name is Ivo. I'm using iText 7 Core.";
        //Paragraph content = new Paragraph(intro);
        //document.Add(content);
        //Paragraph secondHeading = new Paragraph("What I am do right now.").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(40);
        //document.Add(secondHeading);
        #endregion

        #region
        //Table table = new Table(1).UseAllAvailableWidth();
        //Cell cell = new Cell().Add(new Paragraph("Relatório de Produtos").SetFontSize(14))
        //    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
        //    .SetBorder(Border.NO_BORDER);
        //table.AddCell(cell);
        //cell = new Cell().Add(new Paragraph("Produtos existentes"))
        //    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
        //    .SetBorder(Border.NO_BORDER);
        //table.AddCell(cell);

        //document.Add(table);
        #endregion

        #region Code commit
        //for (int i = 0; i < 10; i++)
        //{
        //    var value = 8 * i;
        //    var totalItens = i * i;
        //    _cell = new Cell().Add(new Paragraph(i.ToString())).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
        //    _table.AddCell(_cell);
        //    _cell = new Cell().Add(new Paragraph("Item" + i.ToString())).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
        //    _table.AddCell(_cell);
        //    _cell = new Cell().Add(new Paragraph($"R${value},00")).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
        //    _table.AddCell(_cell);
        //    _cell = new Cell().Add(new Paragraph($"{totalItens}")).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
        //    if(totalItens < 10)
        //        _table.AddCell(_cell.SetBackgroundColor(ColorConstants.RED));
        //    else 
        //        _table.AddCell(_cell.SetBackgroundColor(ColorConstants.MAGENTA));
        //}
        #endregion

        //Início da montagem do relatório
        document.SetMargins(35, 35, 35, 35);
        PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);

        string pathimg = "img/logo_ieq.jpg";
        Image img = new Image(ImageDataFactory.Create(pathimg));
        //pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler(img));
        pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FooterEventHandler());

        Style styleCell = new Style().SetBackgroundColor(ColorConstants.LIGHT_GRAY)
            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

        #region First Table
        Table _table = new Table(4).UseAllAvailableWidth();
        Cell _cell = new Cell(2, 1).Add(img.SetAutoScale(true)).SetWidth(50);
        _table.AddCell(_cell);
        //_table.AddCell(_cell.AddStyle(styleCell));
        _cell = new Cell(1, 2).Add(new Paragraph("IGREJA DO EVANGELHO QUADRANGULAR " +
            "\n REFC - Relatório Estatístico e Financeiro de Culto"))
            .SetFontSize(8)
            .SetFont(bold)
            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
        _table.AddCell(_cell);

        _cell = new Cell(1, 1).Add(new Paragraph("Nº"))
            .SetFontSize(5)
            .SetMaxWidth(20);
        _table.AddCell(_cell.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT));

        _cell = new Cell().Add(new Paragraph("Igreja:")).SetFontSize(6).SetWidth(40);
        _cell.Add(new Paragraph("216 - IEQ-MORRO GRANDE/CAPITAL-SP")).SetFontSize(8);
        _table.AddCell(_cell);

        _cell = new Cell().Add(new Paragraph("CNPJ")).SetFontSize(5);
        _table.AddCell(_cell);

        _cell = new Cell(1, 1).Add(new Paragraph("Data")).SetFontSize(5).SetMaxWidth(20);
        _table.AddCell(_cell.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT));

        _cell = new Cell(1, 2).Add(new Paragraph("Pastor: ")).SetFontSize(6);
        _table.AddCell(_cell);
        _cell = new Cell(1, 2).Add(new Paragraph("Prontuário: ")).SetFontSize(6);
        _table.AddCell(_cell);
        #endregion


        document.Add(_table);

        #region Second Table
        Table secondTable = new Table(6).UseAllAvailableWidth();
        Cell _cell2 = null;
        _cell2 = new Cell(2, 1).Add(new Paragraph("Dia da Semana")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(70);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(2, 1).Add(new Paragraph("Horário")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(50);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).Add(new Paragraph("Testemunhos de Cura")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(70);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).Add(new Paragraph("      ")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(30);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).Add(new Paragraph("Conversões")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(50);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).Add(new Paragraph("      ")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(30);
        secondTable.AddCell(_cell2);


        _cell2 = new Cell(1, 1).Add(new Paragraph("Batizados no Espírito Santo")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).Add(new Paragraph("Visitantes")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        secondTable.AddCell(_cell2);


        _cell2 = new Cell(1, 1).Add(new Paragraph("Diáconos em Serviço")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).Add(new Paragraph("Crianças apresentadas")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).Add(new Paragraph("Total de presentes")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        secondTable.AddCell(_cell2);
        _cell2 = new Cell(1, 1).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        secondTable.AddCell(_cell2);

        document.Add(secondTable);
        #endregion


        #region tree table
        Table treeTable = new Table(2).UseAllAvailableWidth();
        Cell _cell3 = null;
        _cell3 = new Cell(1, 1).Add(new Paragraph("Pastores Presentes")).SetFontSize(6).SetFont(bold).SetTextAlignment(TextAlignment.CENTER);
        treeTable.AddCell(_cell3);
        _cell3 = new Cell(1, 1).Add(new Paragraph("Visitas Especiais")).SetFontSize(6).SetFont(bold).SetTextAlignment(TextAlignment.CENTER);
        treeTable.AddCell(_cell3);

        _cell3 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        treeTable.AddCell(_cell3);
        _cell3 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        treeTable.AddCell(_cell3);
        _cell3 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        treeTable.AddCell(_cell3);
        _cell3 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        treeTable.AddCell(_cell3);

        _cell3 = new Cell(1, 1).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        treeTable.AddCell(_cell3);
        _cell3 = new Cell(1, 1).Add(new Paragraph("Pregador: ")).SetFontSize(6).SetTextAlignment(TextAlignment.LEFT);
        treeTable.AddCell(_cell3);

        document.Add(treeTable);
        #endregion


        #region four Table
        Table titleFourTable = new Table(1).UseAllAvailableWidth();
        Cell title = new Cell().Add(new Paragraph("DEMONSTRATIVO DE ARRECADAÇÕES").SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).SetFont(bold));
        titleFourTable.AddCell(title);
        document.Add(titleFourTable);

        Table fourTable = new Table(6).UseAllAvailableWidth();
        Cell _cell4 = null;
        _cell4 = new Cell(1, 1).Add(new Paragraph("01")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(20);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("Dízimos")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(50);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(70);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("05")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(20);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("Outras Entradas")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(50);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(30);
        fourTable.AddCell(_cell4);


        _cell4 = new Cell(1, 1).Add(new Paragraph("02")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("Ofertas Gerais")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 2).Add(new Paragraph("06. TOTAL DE ARRECADAÇÃO")).SetFontSize(6).SetTextAlignment(TextAlignment.LEFT).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        fourTable.AddCell(_cell4);


        _cell4 = new Cell(1, 1).Add(new Paragraph("03")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("Ofertas Especiais")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("10")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).Add(new Paragraph("Ofertas Missões (3º dom)")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        fourTable.AddCell(_cell4);
        _cell4 = new Cell(1, 1).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        fourTable.AddCell(_cell4);

        document.Add(fourTable);
        #endregion

        #region Five Table
        Table fiveTable = new Table(5).UseAllAvailableWidth();
        Cell _cell5 = new Cell(1, 5).Add(new Paragraph("DIZIMISTAS")).SetFontSize(6).SetFont(bold).SetTextAlignment(TextAlignment.CENTER);
        _cell5.Add(new Paragraph("(Caso não haja espaço suficiente, utilize o RDC)")).SetFontSize(6).SetFont(bold).SetTextAlignment(TextAlignment.CENTER);
        fiveTable.AddCell(_cell5);

        _cell5 = new Cell(1, 1).Add(new Paragraph("")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(20);
        fiveTable.AddCell(_cell5);
        _cell5 = new Cell(1, 1).Add(new Paragraph("Nome do dizimista")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(100);
        fiveTable.AddCell(_cell5);
        _cell5 = new Cell(1, 1).Add(new Paragraph("Nº do cheque")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(40);
        fiveTable.AddCell(_cell5);
        _cell5 = new Cell(1, 1).Add(new Paragraph("Nº Banco")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(30);
        fiveTable.AddCell(_cell5);
        _cell5 = new Cell(1, 1).Add(new Paragraph("Valor")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(40);
        fiveTable.AddCell(_cell5);

        for (int i = 1; i <= 10; i++)
        {
            string value = i.ToString();
            if (i < 10)
                value = $"{0}{i}";

            _cell5 = new Cell(1, 1).Add(new Paragraph($"{value}")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
            fiveTable.AddCell(_cell5);
            _cell5 = new Cell(1, 1).Add(new Paragraph("")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
            fiveTable.AddCell(_cell5);
            _cell5 = new Cell(1, 1).Add(new Paragraph("")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
            fiveTable.AddCell(_cell5);
            _cell5 = new Cell(1, 1).Add(new Paragraph("")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
            fiveTable.AddCell(_cell5);
            _cell5 = new Cell(1, 1).Add(new Paragraph("")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
            fiveTable.AddCell(_cell5);
        }

        document.Add(fiveTable);
        #endregion


        #region Six table
        Table titleSixTable = new Table(2).UseAllAvailableWidth();
        Cell _cellTotais = null;
        _cellTotais = new Cell(1, 1).Add(new Paragraph("VALORES TRANSPORTADOS DO(S) RDC(S) Nº:")).SetFontSize(8).SetFont(bold).SetTextAlignment(TextAlignment.RIGHT).SetWidth(250);
        titleSixTable.AddCell(_cellTotais);
        _cellTotais = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(30);
        titleSixTable.AddCell(_cellTotais);

        _cellTotais = new Cell(1, 1).Add(new Paragraph("TOTAL DE DÍZIMOS ENTREGUE NESTE CULTO:")).SetFontSize(8).SetFont(bold).SetTextAlignment(TextAlignment.RIGHT).SetWidth(250);
        titleSixTable.AddCell(_cellTotais);
        _cellTotais = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(30);
        titleSixTable.AddCell(_cellTotais);

        document.Add(titleSixTable);


        Table sixTable = new Table(2).UseAllAvailableWidth();
        Cell _cell6 = null;

        _cell6 = new Cell(1, 1).Add(new Paragraph("Nome dos diáconos responsáveis")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(75);
        sixTable.AddCell(_cell6);
        _cell6 = new Cell(1, 1).Add(new Paragraph("Assinatura")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER).SetWidth(75);
        sixTable.AddCell(_cell6);

        _cell6 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        sixTable.AddCell(_cell6);
        _cell6 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        sixTable.AddCell(_cell6);
        _cell6 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        sixTable.AddCell(_cell6);
        _cell6 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        sixTable.AddCell(_cell6);
        _cell6 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        sixTable.AddCell(_cell6);
        _cell6 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        sixTable.AddCell(_cell6);
        _cell6 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        sixTable.AddCell(_cell6);
        _cell6 = new Cell(1, 1).Add(new Paragraph("")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER);
        sixTable.AddCell(_cell6);

        _cell6 = new Cell(1, 1).Add(new Paragraph("Nome do Tesoureiro: ")).SetHeight(8).SetFontSize(6).SetTextAlignment(TextAlignment.LEFT);
        sixTable.AddCell(_cell6);
        _cell6 = new Cell(1, 1).Add(new Paragraph("Assinatura: ")).SetFontSize(6).SetTextAlignment(TextAlignment.LEFT);
        sixTable.AddCell(_cell6);

        document.Add(sixTable);
        #endregion

        document.Close();
        //Fim da montagem do relatório
    }
}


Console.WriteLine("Documento gerado!");

public class HeaderEventHandler : IEventHandler
{
    Image Img;
    public HeaderEventHandler(Image img)
    {
        Img = img;
    }
    public void HandleEvent(Event @event)
    {
        PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
        PdfDocument pdfDoc = docEvent.GetDocument();
        PdfPage page = docEvent.GetPage();

        PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
        Rectangle rootArea = new Rectangle(35, page.GetPageSize().GetTop() - 75, page.GetPageSize().GetRight() - 70, 55);
        new Canvas(canvas, rootArea).Add(getTable(docEvent));

        //Rectangle rootArea = new Rectangle(35, page.GetPageSize().GetTop() - 70, page.GetPageSize().GetRight() - 70, 50);

        //Canvas canvas = new Canvas(page, rootArea);
        //canvas
        //    .Add(getTable(docEvent))
        //    .ShowTextAligned("Este es el encabezado de página", 10, 0, iText.Layout.Properties.TextAlignment.CENTER)
        //    .ShowTextAligned("Este el el pie página", 10, 10, iText.Layout.Properties.TextAlignment.CENTER)
        //    .ShowTextAligned("Texto agregado", 612, 0, iText.Layout.Properties.TextAlignment.RIGHT)
        //    .Close();

    }

    public Table getTable(PdfDocumentEvent docEvent)
    {
        float[] celWidth = { 20f, 80f };
        Table tableEvent = new Table(UnitValue.CreatePercentArray(celWidth)).UseAllAvailableWidth();

        Style styleCell = new Style()
            .SetBorder(Border.NO_BORDER);

        Style styleText = new Style()
            .SetTextAlignment(TextAlignment.RIGHT).SetFontSize(10f);

        //Cell cell = new Cell().Add(Img.SetAutoScale(true)).SetBorder(new SolidBorder(ColorConstants.BLACK, 1));
        Cell cell = new Cell().Add(Img.SetAutoScale(true));

        tableEvent.AddCell(cell.AddStyle(styleText).SetTextAlignment(TextAlignment.LEFT));

        PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);

        cell = new Cell()
            .Add(new Paragraph("Reporte diario\n").SetFont(bold))
            .Add(new Paragraph("Departamento de Recursos Materiais\n").SetFont(bold))
            .Add(new Paragraph("Fecha de emisión" + DateTime.Now.ToShortDateString()))
            .AddStyle(styleText).AddStyle(styleCell);

        tableEvent.AddCell(cell);

        return tableEvent;
    }
}

public class FooterEventHandler : IEventHandler
{
    public void HandleEvent(Event @event)
    {
        PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
        PdfDocument pdfDoc = docEvent.GetDocument();
        PdfPage page = docEvent.GetPage();

        PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
        Rectangle rootArea = new Rectangle(35, 20, page.GetPageSize().GetRight() - 70, 55);
        new Canvas(canvas, rootArea).Add(getTable(docEvent));



    }

    public Table getTable(PdfDocumentEvent docEvent)
    {
        float[] celWidth = { 92f, 8f };
        Table tableEvent = new Table(UnitValue.CreatePercentArray(celWidth)).UseAllAvailableWidth();

        int pageNum = docEvent.GetDocument().GetPageNumber(docEvent.GetPage());

        Style styleCell = new Style()
            .SetPadding(5)
            .SetBorder(Border.NO_BORDER)
            .SetBorderTop(new SolidBorder(ColorConstants.BLACK, 2));

        //Cell cell = new Cell().Add(Img.SetAutoScale(true)).SetBorder(new SolidBorder(ColorConstants.BLACK, 1));
        Cell cell = new Cell().Add(new Paragraph(DateTime.Now.ToLongDateString()));

        tableEvent.AddCell(cell
            .AddStyle(styleCell)
            .SetTextAlignment(TextAlignment.RIGHT)
            .SetFontColor(ColorConstants.LIGHT_GRAY));

        cell = new Cell().Add(new Paragraph(pageNum.ToString()));
        cell.AddStyle(styleCell)
            .SetBackgroundColor(ColorConstants.BLACK)
            .SetFontColor(ColorConstants.WHITE)
            .SetTextAlignment(TextAlignment.CENTER);
        //PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);

        //cell = new Cell()
        //    .Add(new Paragraph("Reporte diario\n").SetFont(bold))
        //    .Add(new Paragraph("Departamento de Recursos Materiais\n").SetFont(bold))
        //    .Add(new Paragraph("Fecha de emisión" + DateTime.Now.ToShortDateString()))
        //    .AddStyle(styleText).AddStyle(styleCell);

        tableEvent.AddCell(cell);

        return tableEvent;
    }
}
