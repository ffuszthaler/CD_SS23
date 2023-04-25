# Code Review Report
Course: C# Development SS 2023 (4 ECTS, 3 SWS)

Student ID: cc211008

BCC Group: A

Name: Florian Fussthaler

Your Project Topic: Flood Fill Algorithm

#

### A Short Summary about the Algorithm (What is the Background and the Motivation of having such an algorithm?): 
```
The flood fill algorithm is a well-known computer graphics algorithm that is used to fill a contiguous area of pixels with a specific color. 

The background of the flood fill algorithm can be traced back to the early days of computer graphics, where it was used to render 2D images. In those days, computers had limited processing power and memory, and so, efficient algorithms were required to achieve good performance.

The motivation behind the development of the flood fill algorithm was to provide a fast and easy way to fill shapes with colors. In particular, it was designed to address the problem of filling complex shapes with multiple boundaries and holes, which would be difficult and time-consuming to fill manually.

The algorithm has found many applications in computer graphics, including image processing, 3D rendering, and video games.
```

### Implementation Detail

#### Implementation Logic Explanation:
(Explain how you implement the idea step by step compactly and clearly.)
```
For my implementation, I divided my code into three functions, the already existing main which contains the entire input file logic and manages any kind of user input, such as the start coordinates of the algorithm.

Next the Fill function which contains the actual algorithm logic and performs them recursively, by looping over every connected "tile" and stops at any border, therefore marking a "flood".

And lastly the Print function which displays what the algorithm does and renders it as a nice ASCII animation, after that it also manages the creation of the output file.
```

#### Achievements:
(List down and explain what achievements you are proud of (e.g., features, techniques, etc.) in the project. Please explain in detail.)
```
1. The entire code base is almost less than 100 lines (Without comments it certainly is).
2. Made up of simple logic, so it isn't difficult to learn how the code / algorithm works.
3. Implementing a TUI which makes using the algorithm a lot nicer of an experience.
```

### Learned Knowledge from the Project

#### Major Challenges and Solutions:
(List down and explain the major challenges. Did you solve it? How? Please explain in detail.)
```
1. Taking the content of the text file and correctly transforming it into the data structure that my implementation of the algorithm uses. This was achieved by looping over the contents and correctly copying everything into the correct cell of the 2D string array.
```

#### Minor Challenges and Solutions:
(List down and explain the minor challenges. Did you solve it? How? Please explain in detail.)
```
1. Making it nice to use whithout having to modify the source code if all you wanted was to change the start coordinates. This was done by creating a TUI which helps you in using the application.
```

### Reflections on the Own Project:
(List down and explain what you could improve and add if you have more time.)
```
1. If I had more time, then I'd probably try to improve the experience of using the application, by allowing the user to have more setting.
2. Maybe try to visualize the coordinate picking part, similar to putting pins on a map.
```

### Reflections on the Projects learned during the Presentation:
(List down and explain what you have learned from your colleague’s codes and what you should pay attention to when writing codes next time.)
```
1. Item
```
