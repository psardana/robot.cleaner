namespace robo.cleaner.Models;

/// <summary>
/// class to map the coordinates of the robot
/// </summary>
public class Coordinate
{
    public int Y { get; set; }

    public int X  { get; set; }
    
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}