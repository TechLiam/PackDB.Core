# PackDB [![Built and tested](https://github.com/TechLiam/PackDB.Core/actions/workflows/BuildAndTestAction.yml/badge.svg)](https://github.com/TechLiam/PackDB.Core/actions/workflows/BuildAndTestAction.yml) [![Security Code scan](https://github.com/TechLiam/PackDB.Core/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/TechLiam/PackDB.Core/actions/workflows/codeql-analysis.yml)
PackDB was created to provide a .Net implementation of a data access layer that uses MessagePack as the data Serializer on the backend.

PackDB.Core provides the basics that allow a user of PackDB to interact with the underlying PackDB extension projects.

A key concept for PackDB is to be simple to expand to be used in different ways.

If you are going to use PackDB in your project, you should consider using an extension project rather than PackDB.Core as the core project doesn't provide a lot of functionality and is intended to be included as a dependency by extension projects.

## Offical extension project
- [PackDB.FileSystem](https://github.com/TechLiam/PackDB.FileSystem)

If you would like to see your extension project listed above, please raise an issue or create a pull request to add it in.

## Extending PackDB
If you need or would like to create an extention for PackDB please do so. To help you get started we have written a [tutorial](https://github.com/TechLiam/PackDB.Core/wiki) that explains each part that you will need to do.
