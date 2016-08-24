### Snap! Game Simulator
This is a test project created as part of a test assignment.  This is a WPF application built with VS 2015 for .Net 4.5.2

### Building the project
Open the solution in VS and restore Nuget packages before compilation. Press Ctrl+F5 (or F5)
The solution is using Prism packages to fully support MVVM. (Please see packages.config for the details)

## Snap! Game Simulator requirements
Simulate a simplified game of "Snap!" between two computer players using N packs of cards (standard 52 card, 4 suit packs).
The "Snap!" matching condition can be the face value of the card, the suit, or both. The program should ask:

- 	How many packs to use (i.e. define N)
- 	Which of the three matching conditions to use

Run a simulation of the cards being shuffled, then played one card at a time from the top of the common pile.
When two matching cards are played sequentially, a player is chosen randomly as having declared "Snap!" first and takes ownership of all cards played in that run.
Play continues until the pile is completely exhausted (any cards played without ending in a "Snap!" at the time the pile is exhausted are ignored).
Tally up the total number of cards each player has accumulated and declare the winner/draw.

## Thinking process
This section briefly describes a thinking process while doing the exercise.

1. I had to figure out the rules of the Snap! As I haven't played it before.
2. I started thinking about a domain model.
3. I created a basic domain model starting from the Game class. At the same time I added additional classes to the Models namespace based on the requirements
4. I started thinking about an API provided by the Game class and how it would be used for playing and for simulation. In order to get an idea, I switched to the building of a UI/View Model skeleton. I started thinking about integration between the model and the UI using MVVM. 
5. I configured a basic WPF App and installed some packages to support MVVM. I connected UI with the VM layer and VM Layer with the model.
6. I ended up working with UI when I got a basic Simulation View model and an Empty View.
7. I started adding more logic to the View Model layer to prototype the Game model.
8. Then I added more logic to the model. At that point I was more or less clear about the model and the API exposed.
9. When the model was ready I started thinking about UI and the layout.
10. I started working on the layout in XAML. I used Blend to incorporate some resource to the project.
11. I created basic layout and started adding controls on a toolbar and main canvas. At that point I added logic to the VM: major behaviour/commands 
12. Then I was making changes in UI/VM/Model layers iteratively by adding more and more logic. The most focus was on integration between UI.
The UI setup took most of the time. I was thinking how to present playing cards and reused a control template with basic layout. 

If I had spent more time, I'd have worked more on the UI (specifically a playing card control), I'd have added unit tests. 
Anyway, the original requirements should be fulfilled. 
