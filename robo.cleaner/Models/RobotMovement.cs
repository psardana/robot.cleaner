namespace robo.cleaner.Models;

/// <summary>
/// this class represents robo's movement
/// </summary>
public class RobotMovement
{
    public char RoboDirection { get; }

    public int DirectionSteps { get; }
    
    public RobotMovement(char roboDirection, int directionSteps)
    {
        RoboDirection = roboDirection;
        DirectionSteps = directionSteps;
    }
}