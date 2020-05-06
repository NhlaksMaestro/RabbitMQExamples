# Python & CSharp RabbitMQExamples

A project demonstrating how RabbitMQ is used with Python and Csharp Programming Languages
Connecting to a MongoDB and PostGreSql Database 

## Getting Started

You will need Windows OS, visual studio, .NET Framework, PostGreSql, MongoDB and Python
in order to get the projects running.

We have both publishers and subscribers for both the C#.Net and python console applications.
Including flask rest controllers as a publisher and .net WebApi rest controller publisher
both publishing to any queue running and awaiting subscribing from which ever subscribing 
application that will boot up first either python or C#.Net.
### Prerequisites

## C# Console 
* RabbitMQ Examples containing subscribers and publishers
* Visual Studio 2019(Any version) OR Visual Studio Code
* * Python 3.7
PostGreSQL 12
* Pika
## C# WebApi & MVC project 
* Visual Studio 2019(Any version) OR Visual Studio Code
* .NET Framework 4.7.2
* MongoDB
* RabbitMQ.Client

## Python Console
* RabbitMQ Examples containing subscribers and publishers
* Visual Studio 2019(Any version) OR Visual Studio Code
* * Python 3.7
PostGreSQL 12
* Pika
## Python Flask Rest & MVC project 
* Visual Studio 2019(Any version) OR Visual Studio Code
* * Python 3.7
PostGreSQL 12
* Pika

### Installing
Once all required software has been installed and verified to be working

For the .NET Projects
User must right click solution and restore nuget packages for the C# 
Console and web application projects.

For the python projects
The user must open the root dictory for the python projects.
The user must run 
```
pip install -r requirements.txt
```
 To install Python packages for the python project.
 
 The Solution already has applications set to start.
 Meaning the application can be debugged by pressing the green play
 button or f5 on the visual studio instance to run the solution.

