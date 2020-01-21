# AteraAPI.V3

__This is not an official library producted by Atera, this is the result of 
an Atera customer wanting to work with they API they provided.__

The purpose of this library is simply to make the Atera API fully usable.
Overall the API is very consistent and easy to use, my hope is that this 
library makes it easy to access the API from any .NET project.

I've included numerous tests to ensure that the library does what it is 
supposed to do.  And the final test is using it to create a backup copy of
my own data from Atera.

### Usage

Usage is fairly simple, create an ApiContext.

```c#
var context = new AteraAPI.V3.ApiContext("your-api-key-here");
```

The API context exposes endpoints for all of the API functionality.

```c#
var agents          = context.Agents;
var alerts          = context.Alerts;
var contacts        = context.Contacts;
var contracts       = context.Contracts;
var customers       = context.Customers;
var customValues    = context.CustomValues;
var expenseRates    = context.ExpenseRates;
var knowledgeBase   = context.KnowledgeBase;
var invoices        = context.Invoices;
var productRates    = context.ProductRates;
var tickets         = context.Tickets;
```

All endpoints implement IEnumerable except for the CustomValue endpoint.  The
CustomValue endpoint only contains Find and FindFor methods.

```c#
var myCustValue = customValues.FindFor(CustomFieldTarget.Ticket, 1005, "MyCustomValue");
``` 

The API exposes interfaces only for the data models.  That means you have an
`IAgent` interface but no public `Agent` class.  This is intentional.  When you
load a value from the API, it will come with all of the values set and some
values will be read/write if allowed by the API.  By not exposing the classes
I am able to help ensure that the client doesn't inadvertently change a value
they shouldn't or send data to the API that it can't use.

This shouldn't be a problem.  In all the API endpoints that support creating 
new items, there are two useful methods available.  The first is the `NewItem`
method.  This method will return a new instance for you to populate with data
before sending it off the the `Create` method.  The second method is an
overload of the `Create` method that takes an action to initialize a new item
inline.

```c#
var customer = customers.NewItem();
customer.CustomerName = "My Test Customer";
var customerId = customers.Create(customer);
// customer.CustomerID == 0
// customerId != 0

customer = customers.Create((c) => { c.CustomerName = "My Test Customer"; });
// customer.CustomerID != 0
```

Updating and deleting items (where available) is done similarly.  First you 
need to acquire the original item.

```c#
var contact = contacts.Find(101);
contact.FirstName = "John";
contact.LastName = "Doe";
var result = contacts.Update(contact);
// result == true

result = contacts.Delete(contact);
// result == true
```

### License

This library is released under the MIT license.

Copyright 2020 Beau Barker

Permission is hereby granted, free of charge, to any person obtaining a copy of 
this software and associated documentation files (the "Software"), to deal in 
the Software without restriction, including without limitation the rights to 
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all 
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
