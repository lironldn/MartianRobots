# MartianRobots
Hello and welcome to Mars! This simple console application simulates the movement of robots on a grid on Mars.
Using the input from ground control, you can make the robots move forward (F), turn left (L) or right (R).
As Mars is a flat planet (I know right?), the robots can be lost if they fall off the grid.
But not to worry, they leave a heavenly scent behind, so that other robots can keep safe.
The application reads input from a file and outputs the final position of the robots - 'LOST' indicating a robot that fell of the edge.

To run the application, simply run the executable, providing the path to the input file as an argument.
An example AccTest.txt file is provided in the MartianRobots.AcceptanceTests folder.


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

# MartianRobots - The Making Of
This project was created using .NET 8.0 and C#.
The project is split into 3 main parts:

## MartianRobots
The main project, containing the logic for the robots and the grid.
In a bigger project this would be split further,
but for this small project it was kept together to follow the KISS principle.

## MartianRobots.Tests
The unit tests for the project.

## MartianRobots.AcceptanceTests
uses the sample input file to test the application end-to-end.
	
The main idea is that the map is a grid containing robots. Other than receiving instructions on updating their position, the grid does not know anything about the robots, keeping a separation of concerns - i.e. the grid is just a database.
The robots are responsible for their own movement and position, however they need to update the grid when they move, so the grid can keep track of the robots (a requirement as the robots are sentient of each other's tragic loss).
The robots rely on the grid to know where its edges are, this is not information that the robots hold themselves.
Various design patterns were used to keep the code clean and maintainable.

Using interfaces, the unit tests can mock the grid and the robots, allowing for easy testing of the logic.
The acceptance tests use the actual implementation of the grid and robots, to test the application end-to-end.
The commit history shows the TDD approach used to develop the project.

A parser and writer are used for I/O, to allow the application to be easily extended to read from other sources, such as a web service or a database.

Co-pilot helped accelarate the coding, at times I found it annoying (when it would not let me type LIKE RIGHT NOW! or when it sometimes got it wrong), but overall it was a good experience. I would use it again. 

Hope you find this project interesting and fun! :)
Liron
