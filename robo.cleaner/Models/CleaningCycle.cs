namespace robo.cleaner.Models;

/// <summary>
/// represents a single cleaning cycle for the robot
/// </summary>
public class CleaningCycle
{
    public Coordinate InitialPosition { get; }

    public List<RobotMovement> RoboMovements { get; }

    public CleaningCycle(Coordinate initialPosition, List<RobotMovement> roboMovements)
    {
        InitialPosition = initialPosition;
        RoboMovements = roboMovements;
    }
}