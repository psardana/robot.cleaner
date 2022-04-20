using System.Collections.Generic;
using NUnit.Framework;
using robo.cleaner.Implementations;
using robo.cleaner.Interfaces;
using robo.cleaner.Models;

namespace robo.cleaner.tests.IntegrationTests;

public class RobotTests
{
    private readonly IRobot _robot;
    
    public RobotTests()
    {
        _robot = new Robot();
    }
    
    [Test]
    public void ShouldReturnCorrectCleaningSteps_WhenValidInputIsGiven()
    {
        //Arrange
        CleaningCycle cleaningCycle = new CleaningCycle
        (
            new Coordinate(0, 0),
            new List<RobotMovement>
            {
                new RobotMovement('E', 2),
                new RobotMovement('W', 2)
            }
        );

        //Act
        var result = _robot.CleanOffice(cleaningCycle);

        //Asset
        Assert.AreEqual(3, result);
    }
}