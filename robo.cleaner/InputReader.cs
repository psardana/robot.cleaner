using robo.cleaner.Interfaces;
using robo.cleaner.Models;

namespace robo.cleaner;

/// <summary>
/// implementation for input reader
/// </summary>
public class InputReader : IInputReader
{
    private readonly IConsoleWrapper _consoleWrapper;
    
    public InputReader(IConsoleWrapper consoleWrapper)
    {
        _consoleWrapper = consoleWrapper;
    }
    public int NumberOfCommands()
    {
        return int.Parse(_consoleWrapper.ReadLine()!);
    }

    public Coordinate GetInitialPosition()
    {
        var inputCoordinates = _consoleWrapper.ReadLine()!.Split(' ');
        return new Coordinate(int.Parse(inputCoordinates[0]), int.Parse(inputCoordinates[1]));
    }

    public RobotMovement GetRobotMovement()
    {
        var movement = _consoleWrapper.ReadLine()!.Split(' ');
        return new RobotMovement(char.Parse(movement[0]), int.Parse(movement[1]));
    }

    public CleaningCycle GetCleaningCycle()
    {
        var amountOfCommands = NumberOfCommands();
        var initialPosition = GetInitialPosition();
        var commands = new List<RobotMovement>();
        while (commands.Count < amountOfCommands)
        {
            commands.Add(GetRobotMovement());
        }
        var cleaningCycle = new CleaningCycle(initialPosition, commands);
        return cleaningCycle;
    }
}