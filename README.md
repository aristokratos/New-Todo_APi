Week 7 Task

Intro :

This task is aimed at evaluating your understanding and implementation of Web API using ASP.NET Core.

Challenge

Your task is to create a Web application that models a Todo App. In this task you are required to implement the data access layer of your Todo app using EF Core and Linq

Task requirements

- Implement pagination

- Implement Swagger-UI for data visualisation and access to the API

- The data storage required for this project is either SqlLite or SQL-Server database.

- Use EFCore and LINQ

-

- The application should have the following endpoints to manage CRUD on Users records

· GET: http:localhost:[port]/User/all-users?page=[current number]

· GET: http:localhost:[port]/User/[id]

· GET: http:localhost:[port]/User/[email]

· GET: http:localhost:[port]/User/search?term=[search-term]

· POST: http:localhost:[port]/User/add-new

· PUT: http:localhost:[port]/User/update/[id]

· DELETE: http:localhost:[port]/User/delete/[id]

- All functional requirements should be completed.

Functional requirements

- User can add to the list

- User can edit list item

- User can delete an item by id/email

- User can get all list with pagination

- User can search for items by date/word

- Should be able to get single record of existing Todos either by id, email

Acceptance requirements

Proper documentation with swagger

All endpoints should work correctly

The endpoints should be a Restful Api

Task requirements

- All functional requirements should be completed.

- Task should be submitted on or before Wednesday, October 9, 2022. - Submission should be made to this github classroom