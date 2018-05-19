# GovLib [![Build Status](https://travis-ci.org/phil-harmoniq/GovLib.svg?branch=master)](https://travis-ci.org/phil-harmoniq/GovLib) [![NuGet](https://img.shields.io/nuget/v/GovLib.svg)](https://www.nuget.org/packages/GovLib)

GovLib is a .NET Standard library that provides intuitive access to various government-related APIs. Currently only the [ProPublica Congress API](https://www.propublica.org/datastore/api/propublica-congress-api) is available, but more modules are planned. Project under heavy development and may be subject to change.

[**Don't forget to request a ProPublica API key. It's free!**](https://www.propublica.org/datastore/api/propublica-congress-api)

## Installing

Install using the .NET CLI (explicit version is required in pre-releases):

```bash
dotnet add package govlib
```

## Usage guide

Add a `using` reference:

```c#
using GovLib.ProPublica;
```

Instantiate the congress module using an API key string:

```c#
var congress = new Congress(apiKey);

// A few of the API calls available in the Members module
var reps = congress.Members.GetAllRepresentatives();
var sens = congress.Members.GetSenatorsByState(State.Colorado);
var newMembers = congress.Members.GetNewMembers();
```

## Contributing

PRs are always welcome! The ProPublica tests require your ProPublica key to be stored in an environment variable named `PROPUBLICA_API_KEY`. This is not required when consuming/modifying the library, only for testing purposes.

It is recommended you use VS Code to work with the GovLib source code. The workspace includes build tasks, editor settings, extension recommendations, and launch configurations to aid development in VS Code, but any editor that supports C# will do.

Type `Ctrl + Shift + B` (or `Cmd + Shift + B` on Macs) to bring up the build tasks menu:

![Tasks Menu](https://imgur.com/A70An26.jpg)

## Supporting Links

- [Request an API key from ProPublica](https://www.propublica.org/datastore/api/propublica-congress-api)
- More details can be found in the [ProPublica API guide](https://projects.propublica.org/api-docs/congress-api)
- Icon made by [Freepik](http://www.freepik.com) from [www.flaticon.com](https://www.flaticon.com) is licensed by [CC 3.0 BY](http://creativecommons.org/licenses/by/3.0/)
