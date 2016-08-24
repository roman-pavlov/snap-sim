This is a WPF application built in VS 2015 for .Net 4.5.2
In order to compile it please restore Nuget packages. 
Solution is using Prism packages to fully support MVVM. (Please see packages.config for the details)


It took me about 7 hours to build this solution. Unfortunately for the first 90 minutes I managed to build some basic model and a UI skeleton. 
I decided to move forward in order to demonstrate an implementation using WPF properly.

The way I worked could be described in the follwing way:

1) I had to figure out the rules of the Snap. As I haven't played it before. I googled it and checked a video with a demo playing Snap.
2) I started thinking about a domain model for Snap.
3) I started creating a basic domain model starting from the Game class. At the same time I added additional classes to the Models namespace based on the requirements
4) I started thinking about an API provided by the Game clas and how it would be used for playing and for simulation. In order to get an idea , I switched to the building of a UI/ViewModel  skeleton. I started thinking about integration between the model and the UI using MVVM. 
5) I configured a basic WPF App and installed some packages to support MVVM. I connected UI with the VM layer and VM Layer wiith the model.
6) I ended up working with UI when I got a basic Simulation View model and an Empty View.
7) I started adding more logic to the Simulation View Model to prototype the Game model. 
8) Then I added more logic to the model. At that point I was more or less clear about the model.
9) When the model was ready I started thinking about UI and the layout.
10) I started working on the layout in XAML. I used Blend to incorporate some resource to the project.
11) I created basic layout and started adding controls on a toolbar and main canvas. At that point I added logic to the VM: major behavior/commands 
12) Then I was making changes in UI/VM/Model layers iteratively by adding more and more logic. The most focus was on intergration between UI.
The UI setup took most of the time. I was thinking how to present playing cards and reused a control template with basic layout. 

If I spent more time, I'd probably work more on the UI (specifically a playing card control), I'd add unit tests. Anyway, the original requirements should be fullfiled. 





