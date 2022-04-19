using System;
using System.Diagnostics;
using Moq;
using NUnit.Framework;
using robo.cleaner.Interfaces;

namespace robo.cleaner.tests;

public class InputReaderTests
{
    private IInputReader _inputReader;
    private Mock<IConsoleWrapper> _consoleWrapperMock;

    [SetUp]
    public void Setup()
    {
        _consoleWrapperMock = new Mock<IConsoleWrapper>();
    }
    
    [Test]
    public void ShouldReturnTypeOfInteger_WhenNumberOfCommandsIsInteger()
    {
        //Arrange
        _inputReader = new InputReader(_consoleWrapperMock.Object);
        _consoleWrapperMock.Setup(x => x.ReadLine()).Returns("1");

        // Act
        var result = _inputReader.NumberOfCommands();
        
        // Assert
        Assert.That(result, Is.TypeOf<int>());
 
    }
    
    [Test]
    public void ShouldThrowException_WhenNumberOfCommandsIsString()
    {
        //Arrange
        _inputReader = new InputReader(_consoleWrapperMock.Object);
        _consoleWrapperMock.Setup(x => x.ReadLine()).Returns("ABC");

        // Act
        var result =  Assert.Throws<FormatException>(() => _inputReader.NumberOfCommands());        
        
        // Assert
        Debug.Assert(result != null, nameof(result) + " != null");
        Assert.That(result.Message, Is.EqualTo("Input string was not in a correct format."));
 
    }
    
    [Test]
    public void ShouldReturnInitialCoordinates_WhenEnteredCorrectly()
    {
        //Arrange
        _inputReader = new InputReader(_consoleWrapperMock.Object);
        _consoleWrapperMock.Setup(x => x.ReadLine()).Returns("10 22");

        // Act
        var result =  _inputReader.GetInitialPosition();        
        
        // Assert
        Assert.That(result.X, Is.EqualTo(10));
        Assert.That(result.Y, Is.EqualTo(22));
    }
    
    [Test]
    public void ShouldThrowException_WhenCoordinatesPairIsNotEnteredCorrectly()
    {
        //Arrange
        _inputReader = new InputReader(_consoleWrapperMock.Object);
        _consoleWrapperMock.Setup(x => x.ReadLine()).Returns("10 AB");

        // Act
        var result =  Assert.Throws<FormatException>(() => _inputReader.GetInitialPosition());        
        
        // Assert
        Debug.Assert(result != null, nameof(result) + " != null");
        Assert.That(result.Message, Is.EqualTo("Input string was not in a correct format."));
 
    }
    
    [Test]
    public void ShouldReturnRobotsMovement_WhenEnteredCorrectly()
    {
        //Arrange
        _inputReader = new InputReader(_consoleWrapperMock.Object);
        _consoleWrapperMock.Setup(x => x.ReadLine()).Returns("E 22");

        // Act
        var result =  _inputReader.GetRobotMovement();        
        
        // Assert
        Assert.That(result.RoboDirection, Is.EqualTo('E'));
        Assert.That(result.DirectionSteps, Is.EqualTo(22));
    }
    
    [Test]
    public void ShouldThrowException_WhenRobotMovementIsNotEnteredCorrectly()
    {
        //Arrange
        _inputReader = new InputReader(_consoleWrapperMock.Object);
        _consoleWrapperMock.Setup(x => x.ReadLine()).Returns("11 10");

        // Act
        var result =  Assert.Throws<FormatException>(() => _inputReader.GetRobotMovement());        
        
        // Assert
        Debug.Assert(result != null, nameof(result) + " != null");
        Assert.That(result.Message, Is.EqualTo("String must be exactly one character long."));
 
    }
    
    [Test]
    public void ShouldReturnACleaningCycle_WhenEnteredCorrectly()
    {
        //Arrange
        _inputReader = new InputReader(_consoleWrapperMock.Object);
        _consoleWrapperMock.SetupSequence(x => x.ReadLine())
            .Returns("2")
            .Returns("10 22")
            .Returns("E 2")
            .Returns("N 1");

        // Act
        var result =  _inputReader.GetCleaningCycle();        
        
        // Assert
        Assert.That(result.InitialPosition.X, Is.EqualTo(10));
        Assert.That(result.InitialPosition.Y, Is.EqualTo(22));
        Assert.That(result.RoboMovements.Count, Is.EqualTo(2));
        Assert.That(result.RoboMovements[0].RoboDirection, Is.EqualTo('E'));
        Assert.That(result.RoboMovements[0].DirectionSteps, Is.EqualTo(2));
        Assert.That(result.RoboMovements[1].RoboDirection, Is.EqualTo('N'));
        Assert.That(result.RoboMovements[1].DirectionSteps, Is.EqualTo(1));
    }
    
}