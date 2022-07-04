# MetaData Configuration

MetaData Configuration Project is used to create dynamic fields per entity. There are endpoints to perform get and save call.

The solution comprises of three projects <br>

- MetaDataConfiguration.Shared
- MetaDataConfiguration.API
- MetaDataConfiguration.Tests

<br>

## Solution Detailed Description

All the shared code is placed in MetaDataConfiguraion.Shared, API endpoints goes in MetaDataConfiguration.API and the unit testing goes in MetaDataConfiguration.Tests.

<br>

## Environment

- Visual Studio 2022
- DotNet Framework: .NET 6
- MS SQL 2017

<br>

## Technology Stack

- C#
- ASP.NET Web API
- Entity Framework Core
- MS Test

<br>

## Solution Setup:

- Update the connection string in appsettings.json file of MetaDataConfiguration.API project.
- Also open the MetaDataConfiguration.Tests project in new visual studio instace, to run the test application. Since the test application makes use of the API calls from API project.

<br>

## Query Solution / Technical Debt

- If any field is removed from any of the source, we can expose an API which will specifically takes care of delete of that field. Here we can verify from both the source that field is no longer needed and can remove the field configuration from database.
