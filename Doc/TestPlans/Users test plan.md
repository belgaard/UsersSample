# Users Service Test Plan

In this test plan, we are not concerned about the technical details of dealing with databases and other microservices.
We are only concerned about the data values which are passed as input and across boundaries.
From the point of view of this test plan, we care about data on users, addresses and invoices, but not about how such data is handled in our external dependencies.
This is illustrated in the drawing below,

@import "..\diagrams\simplified architecture.md"

## Scenarios

Scenarios serve to group tests into buckets, each with a meaningful and unique names. In a test report, you will see these names as headlines above each group of tests.

| Scenario                    | Scenario Id       |
|-----------------------------|-------------------|
| Simple validation of values | Validation        |
| Retrieve user information   | CoreFunctionality |

## The GET users end-point

The set of *dimensions* influence the outcome of our tests.
Dimensions,

- UserId: Valid, ~NotValid
- includeInvoices: true, false
- InvoiceDto: 0, 1
- UserRow: Exists, ~DoesNotExist
- AddressRow: Exists, ~DoesNotExist

In order to reduce the number of combinations, we will handle invalid values in the below table. The two dimensions, includeInvoices and InvoiceDto, are not mentioned because they do not have any invalid values - any will do.

| UserId    | UserRow       | AddressRow    | Test case                                             |
|-----------|---------------|---------------|-------------------------------------------------------|
| ~NotValid | Exists        | Exists        | GetUserMustReturnRequestedUserWhenThereIsNoAddressRow |
| Valid     | ~DoesNotExist | Exists        |                                                       |
| Valid     | Exists        | ~DoesNotExist |                                                       |

Since we now have only valid values left for the dimensions UserId, UserRow and AddressRow, we will in the following table not mention those - they are implicitly valid in all cases.

| includeInvoices | InvoiceDto | Test case                      |
|-----------------|------------|--------------------------------|
| true            | 0          | GetUserMustReturnRequestedUser |
| true            | 1          |                                |
| false           | 0          |                                |
| false           | 1          |                                |
