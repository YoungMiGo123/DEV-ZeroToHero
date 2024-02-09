
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
}
public interface IMachine
{
    void Print(Document document);
    void Scan(Document document);
    void Fax(Document document);
}

public class MultiFunctionPrinter : IMachine
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


public class InterfaceSegregationViolationExample
{
    public static void Build()
    {
        Console.WriteLine("InterfaceSegregationViolationExample\n");

        IMachine multiFunctionPrinter = new MultiFunctionPrinter();
        multiFunctionPrinter.Print(new Document());
        multiFunctionPrinter.Scan(new Document());
        multiFunctionPrinter.Fax(new Document());
    }
}
