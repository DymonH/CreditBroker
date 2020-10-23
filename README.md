# Decription
This solution is some sort of credit broker.
Consists of several projects, each designed by **Clean architecture** (contains Core, Application, Infrastructure and Presentation layers)
using **Domain Driven Design** (Entities, Repositories, Domain/Application Services, DTO's...) and **SOLID** principles

## Solution structure
* Common - common tools and utilities

* ARM - administrator's dashboard
    * ARM.Website
    
* Identification - idenity server   
    * Identification.Core    
    * Identification.Application
	* Identification.Infrastructure
	* Identification.API
	
* Tests	

Frontend code for all web applications is located in **front** folder of current repo. 

### Technologies
* .NET Core 3.1
* ASP.NET Core 3.1
* Entity Framework Core 3.1 (code-first)
* .NET Core Native DI
* AutoMapper
* MediatR
* Swagger
* XUnit
* JWT authentification
* Angular CLI

#### Architecture and patterns
* Clean Architecture
* Full architecture with responsibility separation of concerns
* SOLID and Clean Code
* Domain Driven Design (Layers and Domain Model Pattern)
* Unit of Work
* Repository and Generic Repository
* Specification Pattern

