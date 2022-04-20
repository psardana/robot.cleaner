# Robot Cleaner
The basic robot cleaner is implemented as a console application where the imput is given on multiple lines. The

First line inputs number of commands that will be given to the robot for cleaning. Input range 0 <= n <= 10,000
Second line inputs the inital position of the robot, separated by spaces. (e.g. x y). Input range x (-100000 <= x <= 100000), y (-100000 <= y <= 100000) 
Third and subsequent lines are for inputting the actual directions. (e.g. E 2) where E is the direction ('E', 'N', 'W', 'S') and 2 is the steps the robo will move, Input range 0 < s < 100000

Output will be the total spaces the robot cleaned based on the given input.

Example Input:
2
10 22
E 2 
N 1

Output:
=> Cleaned: 4