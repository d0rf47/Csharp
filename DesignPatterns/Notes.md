# Design Patterns

- Design Principals are are general **high level** guidelines that support better design for flexibility & maintainability
- Are a reusable solution framework to recurring problems
- Are a way to understand recurring problems and the types of solutions that are effective for solving the problem
- In software these problems are related to storing, passing and/or modifying information in some way
- Design patterns in software allow us to recognize situations where a pattern belongs. It allows us to combine patterns in a way that produces the optimal solution to a problem.
- Design Patterns also allow us to create code that can be easily recognized and understood by others

## Object Oriented Programming (OOP)

- Everything is some kind of object with a set lifetime
- it is a structured organization of properties (class variables) and method (functions)
- Important note is that OOP is really about how information is transferred and used throughout an application and how it is stored
- OOP is a set of concepts about how & where data + Actions come together
- It is an organizational strategy that makes it easier to build and maintain applications over time
- Key Principals of OOP

### Encapsulation

- Keep information as local as possible. i.e Don't share what doesn't need to be shared.
- This is where interfaces come into play. All class define an interface whether explicit or not. This is what is made available (the properties & method) outside of the class itself through access modifiers (public, private, protected)
- Nothing that does not need to be exposed should be exposed (keep implementation details private)

### Abstraction

- Is based on layers of understanding. i.e we don't need to understand how machine code works to write a web application.
  - In this sense the lower layers are abstracted away through API's and interfaces or Modern Languages and their features (like JS)

### Inheritance

- is the principal of being able to extend existing code without changing it.
- this is the foundations of modern frameworks. We can start from more than 0 by building on what the framework provides
- Sets the basis for Code reuse without having to change the code or causing breaking changes. This is foundational for most of the principals of modern development.

### Polymorphism

- Build on the foundation of inheritance
- it allows derived objects to be used/treated as the type they are extending
- C# Exceptions are the best example of this.
  - All exceptions have a message which can be displayed.
  - If one exception does not implement a message than code cannot treat **all** exceptions the same which causes problems

## Design Pattern Categories

### Creational Patterns

- Deal with how & when objects are instantiated
- Deals with the create and lifetime of objects within an application
- Factory, Abstract Factory, Builder, Singleton, Prototype

#### Factory Method

- Separates the concrete object from the consumer who requested the object
- Allows the creation of an object to be deferred until runtime. This allow the use of dynamic context to decide what to build.
- Example: Logger Factory
  - Code requests an object with the interface of logger. And a service provider builds and returns a concrete logger based on dynamic configuration or situations. The logger factory can return an email logger, or a console logger, or a database logger. The requesting code doesn't need to know anything about what kind of logger is being returned.
  - Allows for decoupled code that is easier to maintain and test

![Factory Pattern](.\W3sDesign_Factory_Method_Design_Pattern_UML.jpg)

#### Abstract Factory

    - Is an interface for a factory which ensures the correct factory can be provided in a dynamic situation
    - Allows for the creation of related concrete objects (grouped into families)
    - Consumer of objects does not need to know the details of particular objects or its dependents
    - Example: IHTTPClientFactory is an example built directly into the .Net Ecosystem
        - Allows configuration of a specific subtype of HTTP Client  via an interface
    - The Factory Class deals with returning the Concrete Subclass and manages the life time of the dependent objects

![Abstract Factory Pattern](.\Abstract_factory_UML.svg.png)

#### Builder Pattern

- Separates constructing the object with the object itself
- Uses a different object to handle constructing the requested object
- Allows for the encapsulation of initialization code and allows the creation of an object change without changing the object itself
- Examples: StringBuilder, ApplicationBuilder, EF Core ModelBuilder

#### Prototype Pattern

- Specifies a kind of object to create from an instance thats copied (cloning)
- does not require inheritance like factories
- Allows flexibility for creating objects dynamically
- Is an instance rather than a type
- is useful in cases where creating a new object is more expensive than creating a copy
- Example System.Net.Http.Headers
  - Allows for header sets to be easily created from an existing set

#### Singleton

- Only one instance of an object exists within the scope of the application
- Allows for global variables
- Can cause problems with clarity and concurrent access
- useful for DB Connection pools or regulating access to limited resources
- Can be created via DI framework

### Structural Patterns

- Define how Classes & Objects are assembled
- Focuses on how objects are brought together for use within an application
- Adapter, Bridge, Composite, Decorator, Facade

#### Adapter

- Converts one interface into another
- Allows classes expecting different interfaces work together
- Common use case: Data Mapper - creating View Models or mapping data from a Model onto a View Model

#### Bridge Pattern

- Is a way to compose object without adding additional inheritance

#### Composite Pattern

- Allows us to treat a set of objects the same way that a single object is treated
- MVC Views use this pattern
  - Any view can be treated as a single view but can also be composed of any number of sub views which in turn can contain their own subviews
  - i.e Views and sub views are treated the same way

#### Decorator Pattern

- Allows attaching additional functionality to an existing object without it affecting other objects of the same type
- changes the functionality of an object without creating a subclass from it
- I/O Stream, FileStream, MemoryStream all use the same interface but add functionality through decorators

### Behavioural Patterns

- Patterns which focus on how classes and objects communicate with each other within an application

#### Interpreter Pattern

- based around building context specific language and being able to break expressions down into smaller sub-expressions
  - C# Linq is an example of this

#### Template Method

- Defines part of an operation at one level but then allows subclasses to define some sections or part of the operation
- Example is C# IComparable interface
  - allows defining how an operation should be done like calling .Sort() on custom objects
    - we can define the way in which objects should be sorted

#### Chain of Responsibility

- Defines a pattern wherein if an action needs to be dealt with, allow any number of objects in order to handle the request until all handling has completed.

  - This is how exception handling is designed into .NET --> Exceptions continue to bubble up until it is handled by a try-catch block
  - .NET middleware also employs this pattern wherein each middleware decides what if any action must be taken and whether or not to pass the request to the next layer in the chain

#### Mediator Pattern

- A mediator is an object that encapsulates how a given set of objects interacts with one another
- Allows for objects to have no "awareness" of the other objects they are interacting with. They only need to know about the mediator object which reduces **class coupling**
- **Memento**: Is an object that allows another object to go back to a previous state. (i.e It is a means of storing an objects state)
  - An example is **Serialization** --> The state of the object is stored in a string which can be compared for changes. It allows allows undo functionality since we have a complete reference to the previous state before interaction has taken place

#### Observer Pattern

- One to Many relationship that allows objects to subscribe to something and be notified upon changes
- all events and event handling in C# utilize this pattern
- The object being listened to does not need to know anything about its listeners

#### State Pattern

- Allows an object to change its behaviour based on its current state
- reduces the objects state from the object itself
- Reduces the need to change an object as additional logic is added over time

### Concurrency Patterns

- Patterns can also be categorized based on their scope
- Does the pattern apply to Classes or Objects?
- Class-scoped patterns focus on design and relationships btwn types
- Object-scoped patterns deal with the relationship and structure among instantiated objects

- **S**ingle Responsibility: a class should have 1 single responsibility
- **O**pen/Closed: code is open for extension but closed for changes
- **L**iskov Substitution: A principle which states that objects are replaceable with their subtypes
- **I**nterface segregation: Interfaces should serve a single purpose
- **D**ependency Inversion: Code depends on an interface rather than on a class

- **Interface**: Is a a description of the services that a class provides --> What is available when using a class
  - They are useful thinking about what a class should be doing & how it will interact with the application around it
  - Classes are abstract definitions that represent something. An instance of a class is the real concrete object that can be interacted with (think platos forms). Ex. A blueprint is the plans for something to be build i.e a house. My house is a real thing I can live in.
- **Class Vs. Type**
  - Class is the full description of an object than can be created
  - A Type is an interface that the class fulfils
  - Often used interchangeably, there are important distinctions
    - A single class can be different types at the same time
  - Example
    - Smartphones
      - Has the type of Phone
      - Also has the type of Music player
      - Also has the type of entertainment device
    - The class is smartphone which composes all these types into a single class
  - **Abstract**: A type of class with some functionality defined but not all of it. But is not a complete class without another class that inherits from it and implements it
  - **Concrete**: Is a class that can be instantiated and used
