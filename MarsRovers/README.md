# MarsRover

## Overview

The premise for this project is straightforward. I took it as a challenge in the sense that most of the work I do is buried in many layers of abstraction, 
and I have not really dabbled with command line apps in a long time. Indeed, the bigger challenge was not to fall into the long-time adversary of programmers:
the calling to make mountains from molehills.

We have a simple parser that sets up a loop, broken only by either empty entries or an 'x' to exit. We only require two absolute classes: 
* SearchGrid - to encapsulate the creation of the two dimensional grid that is to be searched
* Rover - to encapsulate the positional aspects and commands needed to move the Rover around the grid

## Assumptions

* The rovers should never be able to exceed the bounds of the grid.
* If commanded to exceed the bounds of the grid, the rover will instead stop at the boundary.
* The rover controllers would want to enter multiple rovers' commands without exiting the program.
* The rover controllers would want to see the rover's last position before entering the next rover's commands.

