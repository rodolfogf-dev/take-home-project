# TakeHomeAssignment :computer:
Hi, I'm Rodolfo (rodolfogf.dev@gmail.com) and here's the code project related to [vigil's take home assignment](https://github.com/new-ft/aspnet-take-home-assignment)
For this challenge I choose to use the following principles:
- Clean Arch & DDD: folder structures & organization were based towards the "Person" entity and any events related to it;
- CRQS: Used to process commands/queries spliting based on use cases ("addPerson", "getall", etc..);
- Repository Pattern: Allowing different implementations for each repository, but sharing common usage (even if the database technology changes);
- Docker
- Ef Core
- Minimal API 

## Prerequisites
- Visual Studio
- Docker

## How to run the project

- After downloading the project, please open the .sln file (TakeHomeAssignment.sln) using visual studio;
- Click on "Docker Compose" command, or initiate it by docker-compose project;
- The project will create the respective docker images and container on the background.
- The sql database will be available at "localhost, 1433"

## Future improvements if given more time
- Add missing implementations (DomainEvents, Healtcheks..)
- Refactoring code smells and bad constant usage (sql connection string in appsettings, remove hardcorded values..)
- Add missing relevant tests
- Add better endpoint structure

## Usage:
For all requests please use "12345" as x-client-id
- ![image](https://github.com/user-attachments/assets/7a1c782e-3096-4689-a195-840902202e98)
- ![image](https://github.com/user-attachments/assets/954ae18f-592d-488d-bb5b-4218481e15ca)


