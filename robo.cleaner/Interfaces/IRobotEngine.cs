using robo.cleaner.Models;

namespace robo.cleaner.Interfaces;

/// <summary>
/// interface for robot cleaner's movement
/// </summary>
public interface IRobotEngine
{
    List<Coordinate> GetDirtyCoordinates(CleaningCycle cleaningCycle);
}