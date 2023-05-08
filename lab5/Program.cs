Main();

void Main()
{
    var firstLine = new DirectLine
    {
        VarA = GetDoubleFromCommandLine("first.A"),
        VarB = GetDoubleFromCommandLine("first.B"),
        VarC = GetDoubleFromCommandLine("first.C")
    };

    var secondLine = new DirectLine
    {
        VarA = GetDoubleFromCommandLine("second.A"),
        VarB = GetDoubleFromCommandLine("second.B"),
        VarC = GetDoubleFromCommandLine("second.C")
    };

    var resultWithoutException = DirectLinesExistsWithoutException(firstLine, secondLine);
    Console.WriteLine($"Две прямые{(resultWithoutException ? "" : " не")} существуют");

    try
    {
        DirectLinesExistsWithException(firstLine, secondLine);
        Console.WriteLine("Две прямые существуют");
    }
    catch (Exception error)
    {
        Console.WriteLine(error.Message);
    }
    
    try
    {
        DirectLinesExistsWithConcreteException(firstLine, secondLine);
        Console.WriteLine("Две прямые существуют");
    }
    catch (Exception error)
    {
        Console.WriteLine(error.Message);
    }
    
    try
    {
        DirectLinesExistsWithMyException(firstLine, secondLine);
        Console.WriteLine("Две прямые существуют");
    }
    catch (Exception error)
    {
        Console.WriteLine(error.Message);
    }
}

bool DirectLinesExistsWithoutException(
    DirectLine firstLine,
    DirectLine secondLine
)
{
    return firstLine.VarA * secondLine.VarB - secondLine.VarA * firstLine.VarB != 0;
}

void DirectLinesExistsWithException(
    DirectLine firstLine,
    DirectLine secondLine
)
{
    if (firstLine.VarA * secondLine.VarB - secondLine.VarA * firstLine.VarB == 0)
        throw new Exception("Две прямые не существуют");
}

void DirectLinesExistsWithConcreteException(
    DirectLine firstLine,
    DirectLine secondLine
)
{
    if (firstLine.VarA * secondLine.VarB - secondLine.VarA * firstLine.VarB == 0)
        throw new ArithmeticException("Две прямые не существуют");
}

void DirectLinesExistsWithMyException(
    DirectLine firstLine,
    DirectLine secondLine
)
{
    if (firstLine.VarA * secondLine.VarB - secondLine.VarA * firstLine.VarB == 0)
        throw new LinesNotExists();
}

double GetDoubleFromCommandLine(string variableName = "variable")
{
    string GetNotNullableVariable()
    {
        while (true)
        {
            Console.Write($"Enter {variableName} value: ");
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }

            Console.WriteLine("The entered value cannot be null.");
        }
    }

    while (true)
    {
        var stringNumber = GetNotNullableVariable();

        if (double.TryParse(stringNumber, out var parsed)) return parsed;

        Console.WriteLine("The entered number must be of type int.");
    }
}

internal class LinesNotExists : ArithmeticException
{
    public LinesNotExists(string message = "Две прямые не существуют") : base(message)
    {
    }
}