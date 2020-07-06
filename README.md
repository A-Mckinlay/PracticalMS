# PracticalMS
A work in progress implementation of the architecture laid out in the book Practical Microservices(https://pragprog.com/titles/egmicro/)

![Architecture Diagram](https://github.com/A-Mckinlay/PracticalMS/blob/master/ArchitectureDiagram.png?raw=true)

So far I've only setup the relational storage that will be used for the different Views.
This involved using EF Core and its migrations feature.

Next step is to setup [neventstore](http://neventstore.org/) to act as the message store for the application.
