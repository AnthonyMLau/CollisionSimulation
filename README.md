# Collision Simulation

This project is a simulation of the motion of particles in a closed 2D container. 

The simulation is event based rather than time-step based which increases accuracy and performance.

### How it works

This simulation works by calculating the time to collision of each particle with respect to each other

### Accuracy
Time-step method: If the time step is too large or if the speed of the particles is high, there is a high chance that the simulation will miss collisions since the particles will just "skip over" each other instead of colliding.

The event based method will not miss any collisions as it only steps the time stamp forwards to the nearest collision. 

### Efficiency


