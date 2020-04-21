# Example Coding Exercise: Maze Test

The test is based on exploring any arbitrary maze (one is provided).

## User Story 1

As a world famous explorer of Mazes I would like a maze to exist
So that I can explore it

### Acceptance Criteria

* A Maze (as defined in ExampleMaze.txt consists of walls 'X', Empty spaces ' ', one and only one Start point 'S' and one and only one exit 'F'
* After a maze has been created the number of walls and empty spaces should be available to me
* After a maze has been created I should be able to put in a coordinate and know what exists at that point

## User Story 2

As a world famous explorer of Mazes I would like to exist in a maze and be able to navigate it so that I can explore it

### Acceptance Criteria

* Given a maze the explorer should be able to drop in to the Start point
* An explorer on a maze must be able to:
    Move forward
    Turn left and right
    Understand what is in front of them
    Understand all movement options from their given location
    Have a record of where they have been
* An explorer must be able to traverse and exit a maze, and on exit they must be able to state the route they took in an understandable fashion
