using robo.cleaner.Models;

namespace robo.cleaner.Interfaces;

/// <summary>
/// interface for reading the input from the user on console
/// </summary>
public interface IInputReader
{
    /// <summary>
    /// reads the number of direction commands that will given to robot for cleaning
    /// from the console
    /// </summary>
    /// <returns>parsed integer value from console for number of commands</returns>
    int NumberOfCommands();
    
    /// <summary>
    /// reads the initial position of the robot from the console
    /// </summary>
    /// <returns>initial coordinate object</returns>
    Coordinate GetInitialPosition();
    
    /// <summary>
    /// reads the robot direction and steps from the console
    /// </summary>
    /// <returns>robot's movement object representation</returns>
    RobotMovement GetRobotMovement();
    
    /// <summary>
    /// get one cleaning cycle for the robot
    /// </summary>
    /// <returns>representation of one cleaning cycle for the robo</returns>
    CleaningCycle GetCleaningCycle();
}