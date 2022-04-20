namespace robo.cleaner.Models;

/// <summary>
/// this class represents robots movement
/// </summary>
public class RobotMovement
{
    public char RobotDirection { get;}

    public int DirectionSteps { get; }
    
    public RobotMovement(char robotDirection, int directionSteps)
    {
        RobotDirection = robotDirection;
        DirectionSteps = directionSteps;
    }
}