# Requirements for the Users Service

The Users service is responsible for user business objects.

@import "..\diagrams\Architecture.md"

## The GET users end-point

Input parameters,

- User ID: A positive integer
- Include invoices: Whether the user returned in the response must include the user's invoices, if any.

Response,

- User ID
- Name
- Address
- The user's invoices, as defined by the Invoices service.
