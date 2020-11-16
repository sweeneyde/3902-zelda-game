# 3902-zelda-game

A repo housing the semester project of:
* James Cross
* Brent Hasseman
* Roy Park
* Dennis Sweeney
* Joshua (Josh) D. White
* Will Chiraz

For CSE 3902 at The Ohio State University, Autumn 2020.

Program Controls:

* W & Up Arrow: Move Link Up
* A & Left Arrow: Move Link Left
* S & Down Arrow: Move Link Down
* D & Right Arrow: Move Link Right

* Z & N: Swing Link's Sword

* E: Damage Link

* 1: Use Bomb
* 2: Use Boomerang
* 3: Use Arrow

* T: Switch to previous Obstacle
* Y: Switch to next Obstacle

* U: Switch to previous Item
* I: Switch to next Item

* O: Switch to previous NPC
* P: Switch to next NPC

* Q: Quit Game
* R: Reset Game


Levels
---

Included within the project files is a namespace called 'Levels'. This namespace is responsible for organizing
the game's dungeon into rooms. The primary fixture of the 'Levels' namespace is the Map class. The Map class
handles the connection and drawing of all rooms as well as what is spawned within them. First, this section will
dive deeper into the 'Map' and the method by which the game stores this pertinent information. Secondly, this section
will further discuss 'Rooms' that the Map creates and by what means those are stored.

Map
---
As mentioned before, the map handles the connection and drawing of all rooms. Please refer to Figures 1 & 2 for complete
reference to the explanation. In short, there exists a 'Map.csv' file that, in each row, describes a room by a unique, three 
digit ID and the room connections above, below, left, right, and via stairs to it. This forms a complete Map layout where every
room is a row within the CSV file. Please see 'Figure 1' for the notes for the Map.csv creation. For rooms that do not have a connection
to another room via the 5 connection options (up, down, left, right, stairs), a '-1' is present at that particular entry within the CSV.
For details on particular room IDs, see 'Figure 2' which shows each room in the dungeon with the corresponding ID as it appears within
Map.csv. With the connections of each room settled within Map, the 'currentRoom' is what is drawn on screen. The next section will 
elaborate on Rooms similarly to how this section highlighted the Map.

Room
---
Like the map, every Room's content and visuals are stored within a CSV file. Unlike the map, however, there is a unique CSV file for each
unique room ID. Every CSV is named after what room it represents. For example, the room with the id = "002" has a corresponding CSV file named
"002.csv". Within those CSV files, there is a general structure that the files adhere to. As seen in 'Figure 3', the roomID.csv files must have the
tag on the first line "ROOM_"id where id is the unique three digit string that corresponds to the room. On the following lines of the file, there
will be a desired object types to spawn (valid classes to spawn are found implementing either IObstacle, INpc, or IWorldItem) using its exact namespace
followed by comma seperated integer values which serve as the x-coordinate and y-coordinate that indicate where to spawn the desired object. Please
see 'Figure 3' for full notes and an example on a simple room CSV file.
