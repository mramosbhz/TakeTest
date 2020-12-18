# TakeTest
This is a solution for technical leveling by Take.net company.

Developed in [dotnet](https://github.com/dotnet/sdk/) `v3.1.103`.



## Implementation

After reading the problem (San Andreas Post Office) and realizing this is a task to calculate the minimum route between points (San Andreas cities), I decided to use Oriented Graph with Dijkstra algorithm to find the shortest path between two points.

![Grafo da solução](https://i.imgur.com/YM3IVEd.png)

I divided the solution into 3 parts:

1. **Library**: is the system library, where we find the classes for the task's solution.
2. **Application**: is the interface with the user, where is made the path's file import and the route's file export..
3. **Tests**: responsible for all solution's library tests.



## Installation

**Console:**

Clone the repository and restore:

```shell
$ git clone ...
$ dotnet restore
```

Publish the application:

```shell
$ cd TakeTest.Application
$ dotnet publish -c Release
```



## Using

I made available, at `TakeTest.Application` project `Resources` folder, two files to test the whole application: `paths.txt` with paths between cities and `shipments.txt` with shipments.

The published application can be found at `bin\Release\netcoreapp3.1\`.

Running the application:

### Windows

`> TakeTest.Application.exe paths.txt shipments.txt output.txt`

### Linux

`$ ./TakeTest.Application paths.txt shipments.txt output.txt`

### Expected output

* In case some shipment's file line contains any city not informed in the path's file, the expected output for this line will be `ERROR: UNKNOWN [CITY_NAME]`, where`[CITY_NAME]`  is the incorrectly informed city.
* In case some unexpected error occurred in some route calculation, the expected output will be `ERROR: INVALID REQUEST`.
* In case the shipment is for an incalculable route, the expected output will be a constant called `UNREACHABLE` that, in the source code, has the `-1` value.



## Tests

Running the application tests:

```shell
$ cd TakeTest.Tests
$ dotnet test
```



## References

* [Wikipedia: Dijkstra's Algorithm](https://en.wikipedia.org/wiki/Dijkstra's_algorithm)

* [Youtube: Graph Data Structure - Dijkstra's Shortest Path Algorithm](https://www.youtube.com/watch?v=pVfj6mxhdMw)