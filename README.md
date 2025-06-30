# Order Management API (.NET 8)

This project is a .NET 8 REST API that simulates an order management system with the following features:

- Discount engine based on customer segments (using the Strategy Pattern)
- Order status tracking with controlled state transitions
- Order analytics including average order value and fulfillment time
- Unit-tested business logic
- In-memory database with Entity Framework Core

###  Approach

- Clean architecture using design patterns (Strategy, Service Layer)
- Dependency injection and modular service organization
- Entity Framework used for data persistence simulation
- Unit tests with xUnit

###  Assumptions

- Order status transitions are limited to a predefined business flow
- Customer data is included in the order request payload
- No authentication or persistent storage (InMemory only)
