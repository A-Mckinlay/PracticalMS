# PracticalMS
A work in progress implementation of the architecture laid out in the book Practical Microservices(https://pragprog.com/titles/egmicro/)

![Architecture Diagram](https://github.com/A-Mckinlay/PracticalMS/blob/master/ArchitectureDiagram.png?raw=true)

Work Complete:
- Setup the relational storage that will be used for the different Views using EF Core and its migrations feature.
- Setup a message store with the Asos fork of [Simple Event Store](https://github.com/ASOS/SimpleEventStore), NEventStore seemed like a bit much overhead for a throwaway project. May re-visit later.

Todo:
- Put a button on the UI that causes messages to be created.
- Hook the ViewData up to the UI.
- Wrtie some Aggregators.
- Write some Components.
- Switch to using CosmosDB as the storage engine for the EventStore.