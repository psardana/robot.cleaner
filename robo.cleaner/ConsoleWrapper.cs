using robo.cleaner.Interfaces;

namespace robo.cleaner;

public class ConsoleWrapper : IConsoleWrapper
{
    /// <summary>
    /// write a message to the console
    /// </summary>
    /// <param name="message"></param>
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// read a message from the console
    /// </summary>
    /// <returns></returns>
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}