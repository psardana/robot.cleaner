using robo.cleaner;
using robo.cleaner.Implementations;
using robo.cleaner.Interfaces;

IConsoleWrapper consoleWrapper = new ConsoleWrapper();
IInputReader inputReader = new InputReader(consoleWrapper);
IRobot robot = new Robot();
consoleWrapper.WriteLine($"=> Cleaned: {robot.CleanOffice(inputReader.GetCleaningCycle())}");