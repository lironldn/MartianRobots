# MartianRobots
Hello and welcome to Mars! This simple console application simulates the movement of robots on a grid on Mars.
Using the console input, you can make the robots move forward (F), turn left (L) or right (R).
As Mars is a flat planet (I know right?), the robots can be lost if they fall off the grid.
The application reads input from a file and outputs the final position of the robots - 'LOST' indicates a robot that fell of the edge.

To run the application, simply run the executable, providing the path to the input file as an argument.

Sample input:
```
5 3                          <- the size of the grid (x, y)
1 1 E                        <- the initial position of the first robot (x, y, direction facing)
RFRFRFRF                     <- the instructions for the robot

3 2 N                        <- 2nd robot
FRRFLLFFRRFLL

0 3 W                        <- 3rd robot etc.
LLFFFLFLFL
```

Sample output:
```
1 1 E
3 3 N LOST
2 3 S
```
