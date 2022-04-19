namespace robo.cleaner.Interfaces;

public interface IConsoleWrapper
{
    /// <summary>
    /// write a message to the console
    /// </summary>
    /// <param name="message"></param>
    void WriteLine(string message);


    /// <summary>
    /// read a message from the console
    /// </summary>
    /// <returns></returns>
    string ReadLine();

}