# ThreeWay
A demonstration of how to serve HTML, JSON and XML from a single ASP.NET MVC endpoint.

It is not uncommon to see multiple endpoints in a project that exist solely to serve different formats of the same data.

This project shows one way to serve three different result formats based on header values from the caller. Specifically, if the client requests *application/json* or *application/xml* content, then JSON or XML is returned by the server.

__NB__ This code, in particular the XML approach, is not recommended for any but the simplest of use cases. XML is rigid/fragile and verbose. When a client needs it, there are often other requirements that suggest WCF or another solution.

__NB__ Circular dependencies can be a problem. For example, if you have a Person object that includes a collection of other related Person objects, and if one or more of those objects has a reference to the first Person object, then problems can arise from this na&iuml;ve approach.

*Caveat lector*
