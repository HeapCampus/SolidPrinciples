#define DependencyInversionPrinciple 
#define Provide

namespace SolidPrinciples
{
    internal class Program
    {
#if SingleResponsibility

#if Provide
public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }

    public void Save()
    {
        // Save employee to database
    }

    public void GenerateReport()
    {
        // Generate report for employee
    }
}

#endif

#if Provide
public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
}

public class EmployeeDatabase
{
    public void Save(Employee employee)
    {
        // Save employee to database
    }
}

public class EmployeeReport
{
    public void GenerateReport(Employee employee)
    {
        // Generate report for employee
    }
}

#endif

#endif

#if OpenClosed

#if NotProvide
public class Shape
{
    public double Radius { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public string ShapeType { get; set; }

    public double CalculateArea()
    {
        if (ShapeType == "Circle")
        {
            return Math.PI * Radius * Radius;
        }
        else if (ShapeType == "Rectangle")
        {
            return Width * Height;
        }
        throw new InvalidOperationException("Invalid shape type");
    }
}

#endif

#if Provide
public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

#endif

#endif

#if LiskovSubstitutionPrinciple

#if NotProvide
public class Document
{
    public virtual void Print()
    {
        // Print the document
    }
}

public class ReadOnlyDocument : Document
{
    public override void Print()
    {
        throw new NotImplementedException("Read-only documents can't be printed");
    }
}

#endif

#if Provide
public abstract class Document
{
    public abstract void Print();
}

public class RegularDocument : Document
{
    public override void Print()
    {
        // Print the document
    }
}

public class PdfDocument : Document
{
    public override void Print()
    {
        // Print the PDF document
    }
}

#endif

#endif

#if InterfaceSegregationPrinciple

#if NotProvide
public interface IWorker
{
    void Work();
    void Eat();
}

public class Worker : IWorker
{
    public void Work()
    {
        // Working
    }

    public void Eat()
    {
        // Eating
    }
}

public class Robot : IWorker
{
    public void Work()
    {
        // Working
    }

    public void Eat()
    {
        throw new NotImplementedException("Robots don't eat");
    }
}

#endif

#if Provide
public interface IWorker
{
    void Work();
}

public interface IEater
{
    void Eat();
}

public class Worker : IWorker, IEater
{
    public void Work()
    {
        // Working
    }

    public void Eat()
    {
        // Eating
    }
}

public class Robot : IWorker
{
    public void Work()
    {
        // Working
    }
}

#endif

#endif

#if DependencyInversionPrinciple

#if NotProvide
public class EmailSender
{
    public void SendMessage(string message)
    {
        // Send email
    }
}

public class Notification
{
    private readonly EmailSender _emailSender;

    public Notification()
    {
        _emailSender = new EmailSender();
    }

    public void Notify(string message)
    {
        _emailSender.SendMessage(message);
    }
}

#endif

#if Provide
public interface IMessageSender
{
    void SendMessage(string message);
}

public class EmailSender : IMessageSender
{
    public void SendMessage(string message)
    {
        // Send email
    }
}

public class SmsSender : IMessageSender
{
    public void SendMessage(string message)
    {
        // Send SMS
    }
}

public class Notification
{
    private readonly IMessageSender _messageSender;

    public Notification(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public void Notify(string message)
    {
        _messageSender.SendMessage(message);
    }
}

#endif

#endif

    }
}
