using robo.cleaner.Interfaces;
using robo.cleaner.Models;

namespace robo.cleaner.Implementations;

/// <summary>
/// implements robot's user interface
/// </summary>
public class Robot : IRobot
{
    private readonly IRobotEngine _robotEngine;
    private readonly IDictionary<Coordinate, bool> _cleanedCoordinates;

    public Robot()
    {
        _robotEngine = new RobotEngine();
        _cleanedCoordinates = new Dictionary<Coordinate, bool>();
    }

    public int CleanOffice(CleaningCycle cleaningCycle)
    {
        //get dirty coordinates from a cleaning cycle
        var dirtyCoordinates = _robotEngine.GetDirtyCoordinates(cleaningCycle);
        
        //start cleaning dirty coordinates
        foreach (var dirtyCoordinate in dirtyCoordinates)
        {
            CleanCoordinate(dirtyCoordinate);
        }

        return _cleanedCoordinates.Count;
    }
    
    /// <summary>
    /// cleans a coordinate
    /// </summary>
    /// <param name="dirtyCoordinate"></param>
    private void CleanCoordinate(Coordinate dirtyCoordinate)
    {
        _cleanedCoordinates.Add(dirtyCoordinate, true);
    }
}