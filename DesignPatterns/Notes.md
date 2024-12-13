# Design Patterns
- Design Principals are are general __high level__ guidelines that support better design for flexibility & maintainability

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
        -  Smartphones
            - Has the type of Phone
            - Also has the type of Music player
            - Also has the type of entertainment device
        - The class is smartphone which composes all these types into a single class
    - **Abstract**: A type of class with some functionality defined but not all of it. But is not a complete class without another class that inherits from it and implements it
    - **Concrete**: Is a class that can be instantiated and used

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
    - If one exception does not implement a message than code cannot treat __all__ exceptions the same which causes problems
