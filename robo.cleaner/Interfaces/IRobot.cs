using robo.cleaner.Models;

namespace robo.cleaner.Interfaces;

/// <summary>
/// interface for the robot's user interface
/// </summary>
public interface IRobot
{
    /// <summary>
    /// cleans the office for a given cleaning cycle
    /// </summary>
    /// <param name="cleaningCycle"></param>
    /// <returns>number of unique places that were cleaned</returns>
    int CleanOffice(CleaningCycle cleaningCycle);
}