# Finance Challenge

## Summary

The theme of this challenge is around a multi-tenanted financial product and contains code snippets for CRUD operations around VAT codes.

The solution contains the following projects:

- **Finance.Database** - A Database project that is used to manage the DB schema and can be used to build a dacpac package for DB deployments.
- **Finance.Service** - A WCF Service Application that contains the CRUD (only read and update operations implemented) endpoints for managing VAT Codes.
- **Finance.ConsoleApp** - A Console Application that calls the CRUD operations exposed by the WCF Service.
- **Finance.Data** - Encapsulates the data layer implemented with Entity Framework 6.
- **Other** - Shared projects

## Challenge

1. Review and explain the code.
2. Identify issues regarding the project structure and propose your own view of how to structure the code.
3. Identify anti-patterns, explain them and propose a fix
4. Identify code blocks that are likely to cause performance issues, explain them and propose fix
5. Add unit tests for the update operation
6. Propose approach to prevent data leaks on the service layer and\or data layer
7. Propose approach to modernize the WCF service to a modern tech
