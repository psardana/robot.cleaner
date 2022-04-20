using robo.cleaner.Interfaces;
using robo.cleaner.Models;

namespace robo.cleaner.Implementations;

/// <summary>
/// implements the functionality of the robot engine
/// </summary>
public class RobotEngine : IRobotEngine
{ 
    /// <summary>
    /// iterates through the cleaning cycle and set dirty coordinates
    /// </summary>
    /// <param name="cleaningCycle"></param>
    /// <returns>dirty coordinates in a cleaning cycle</returns>
    public List<Coordinate> GetDirtyCoordinates(CleaningCycle cleaningCycle)
    {
        var dirtyCoordinates = new List<Coordinate>
        {
            cleaningCycle.InitialPosition
        };
        var currentPosition = cleaningCycle.InitialPosition;
        foreach (var robotMovement in cleaningCycle.RoboMovements)
        {
            for (var i = 0; i < robotMovement.DirectionSteps; i++)
            {
                currentPosition = GetNextPosition(currentPosition, robotMovement.RobotDirection);
                if (!dirtyCoordinates.Any(l=> 
                        l.X == currentPosition.X 
                        && l.Y == currentPosition.Y))
                {
                    dirtyCoordinates.Add(currentPosition);
                }
            }
        }
        return dirtyCoordinates;
    }

    /// <summary>
    /// finds the next position based on the direction
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <param name="robotDirection"></param>
    /// <returns></returns>
    private Coordinate GetNextPosition(Coordinate currentPosition, char robotDirection)
    {
        switch (robotDirection)
        {
            case 'N':
                return new Coordinate(currentPosition.X, currentPosition.Y + 1);
            case 'E':
                return new Coordinate(currentPosition.X + 1, currentPosition.Y);
            case 'S':
                return new Coordinate(currentPosition.X, currentPosition.Y - 1);
            case 'W':
                return new Coordinate(currentPosition.X - 1, currentPosition.Y);
            default:
                return currentPosition;
        }
    }
}