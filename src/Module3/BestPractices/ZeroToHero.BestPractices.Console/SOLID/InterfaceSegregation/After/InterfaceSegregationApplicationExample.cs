
namespace ZeroToHero.BestPractices.Console.SOLID.InterfaceSegregation.After;

using System;

public enum FormatType
{
    PDF,
    DOCX,
    XLSX
}
public class Document
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public FormatType Format { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}\nName: {Name}\nContext: {Content}\nFormat: {Format}";
    }
}

// Interface containing methods for printing
public interface IPrinter
{
    void Print(Document document);
}

// Interface containing methods for scanning
public interface IScanner
{
    void Scan(Document document);
}

// Interface containing methods for faxing
public interface IFax
{
    void Fax(Document document);
}
// Multi-function printer implementing specific interfaces
public class MultiFunctionPrinter : IPrinter, IScanner, IFax
{
    public void Print(Document document)
    {
        Console.WriteLine("Printing document");
    }

    public void Scan(Document document)
    {
        Console.WriteLine("Scanning document");
    }

    public void Fax(Document document)
    {
        Console.WriteLine("Faxing document");
    }
}

public class InterfaceSegregationApplicationExample
{
    public static void Build()
    {
        Console.WriteLine("InterfaceSegregationApplicationExample\n");

        var document = new Document
        {
            Id = Guid.NewGuid(),
            Name = "Sample Document",
            Content = "This is a sample document",
            Format = FormatType.PDF
        };

        IPrinter printer = new MultiFunctionPrinter();
        printer.Print(document);

        document = new Document
        {
            Id = Guid.NewGuid(),
            Name = "Sample Document",
            Content = "This is a sample document",
            Format = FormatType.DOCX
        };

        IScanner scanner = new MultiFunctionPrinter();
        scanner.Scan(document);

        document = new Document
        {
            Id = Guid.NewGuid(),
            Name = "Sample Document",
            Content = "This is a sample document",
            Format = FormatType.XLSX
        };

        IFax fax = new MultiFunctionPrinter();
        fax.Fax(document);
    }
}
