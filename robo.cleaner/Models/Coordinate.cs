namespace robo.cleaner.Models;

/// <summary>
/// class to map the coordinates of the robot
/// </summary>
public class Coordinate
{
    public int Y { get;}

    public int X  { get;}
    
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}