# ThreeWay
A demonstration of how to serve HTML, JSON and XML from a single ASP.NET MVC endpoint.

It is not uncommon to see multiple endpoints in a project that exist solely to serve different formats of the same data.

This project shows one to serve three different result formats based on header values from the caller. Specifically, if the client requests *application/json* or *application/xml* content, then JSON or XML is returned by the server.

__NB__ This code, in particular the XML approach, is not recommended for any but the simplest of use cases.
