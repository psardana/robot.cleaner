using System.Collections.Generic;
using NUnit.Framework;
using robo.cleaner.Implementations;
using robo.cleaner.Interfaces;
using robo.cleaner.Models;

namespace robo.cleaner.tests.UnitTests;

public class RobotEngineTests
{
    private readonly IRobotEngine _robotEngine;

    public RobotEngineTests()
    {
        _robotEngine = new RobotEngine();
    }
    
    [Test]
    public void ShouldReturnThreeCoordinates_WhenOnlyOneDirectionWithTwoStepsIsGiven()
    {
        // Arrange
        CleaningCycle cleaningCycle = new CleaningCycle (new Coordinate(0, 0),new()
            {
                new RobotMovement( 'E', 2)
            }
        );
        
        // Act
        var result = _robotEngine.GetDirtyCoordinates(cleaningCycle);
        
        // Assert
        Assert.AreEqual(3, result.Count);
    }
    
    [Test]
    public void ShouldReturnUniqueCoordinates_WhenReverseDirectionsIsGiven()
    {
        // Arrange
        CleaningCycle cleaningCycle = new CleaningCycle (new Coordinate(0, 0),new List<RobotMovement>
            {
                new RobotMovement( 'E', 2),
                new RobotMovement('W', 2)
            }
        );
        
        // Act
        var result = _robotEngine.GetDirtyCoordinates(cleaningCycle);
        
        // Assert
        Assert.AreEqual(3, result.Count);
    }
}