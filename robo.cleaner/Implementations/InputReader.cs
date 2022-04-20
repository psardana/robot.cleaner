using robo.cleaner.Interfaces;
using robo.cleaner.Models;

namespace robo.cleaner.Implementations;

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
    
    /// <summary>
    /// reads the number of direction commands that will given to robot for cleaning
    /// from the console
    /// </summary>
    /// <returns>parsed integer value from console for number of commands</returns>
    public int NumberOfCommands()
    {
        return int.Parse(_consoleWrapper.ReadLine()!);
    }

    /// <summary>
    /// reads the initial position of the robot from the console
    /// </summary>
    /// <returns>initial coordinate object</returns>
    public Coordinate GetInitialPosition()
    {
        var inputCoordinates = _consoleWrapper.ReadLine()!.Split(' ');
        return new Coordinate(int.Parse(inputCoordinates[0]), int.Parse(inputCoordinates[1]));
    }

    /// <summary>
    /// reads the robot direction and steps from the console
    /// </summary>
    /// <returns>robot's movement object representation</returns>
    public RobotMovement GetRobotMovement()
    {
        var movement = _consoleWrapper.ReadLine()!.Split(' ');
        return new RobotMovement(char.Parse(movement[0]), int.Parse(movement[1]));
    }

    /// <summary>
    /// get one cleaning cycle for the robot
    /// </summary>
    /// <returns>representation of one cleaning cycle for the robo</returns>
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