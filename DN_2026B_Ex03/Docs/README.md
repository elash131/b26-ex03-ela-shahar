# Ex03 Project Notes

This folder contains local working notes for **Exercise 3 - Garage Management System**.

These notes are for planning and code-quality guidance only. They must stay outside the submitted Visual Studio solution and must not be referenced by the `.sln`, `.csproj`, or source code files.

## Assignment Summary

The project is a console application for managing a garage.

The solution must contain exactly these two projects:

```text
Ex03.GarageLogic
Ex03.ConsoleUI
```

`Ex03.GarageLogic` is a class library. It creates a `.dll` and contains the reusable object model and business logic.

`Ex03.ConsoleUI` is the console executable. It contains the user interaction code and uses `Ex03.GarageLogic` through a project reference.

## Current Architecture Direction

The initial object model is:

```text
Vehicle
|-- Car
|   |-- FuelCar
|   `-- ElectricCar
|-- Motorcycle
|   |-- FuelMotorcycle
|   `-- ElectricMotorcycle
`-- FuelTruck

Vehicle has Engine

Engine
|-- FueledEngine
`-- ElectricEngine

Engine has EnergySource
```

The vehicle classes represent the supported vehicle types required by the exercise.

Following lecturer feedback from prior submissions, `Vehicle` should reference an abstract `Engine` rather than holding specific fueled/electric energy members directly. `Engine` owns one `EnergySource`; `FueledEngine` and `ElectricEngine` provide the specific fuel/charge operations. `EnergySource` is a shared state object for current and maximum energy amount, not a separate inheritance tree.

`Car` and `Motorcycle` are abstract middle classes used to hold fields that are common to the fueled and electric versions of the same vehicle family. `FuelTruck` currently inherits directly from `Vehicle` because the exercise only requires one truck type.

`Vehicle.RemainingEnergyPercentage` delegates to its engine.

Future logic classes may include:

```text
Garage
GarageVehicleRecord
OwnerDetails
Wheel
ValueOutOfRangeException
```

Do not add these until they are needed by the implementation discussion.

## Responsibility Split

### Ex03.GarageLogic

This project contains only the model and logic.

It should not use:

```csharp
Console.WriteLine()
Console.ReadLine()
Console.Clear()
```

Expected responsibilities:

- create supported vehicle types
- hold vehicle data
- hold wheel data
- hold energy data
- validate allowed ranges
- manage garage records and vehicle statuses
- expose operations needed by the console UI

### Ex03.ConsoleUI

This project contains only console-specific interaction.

Expected responsibilities:

- print menus
- read user input
- validate input format before calling logic where appropriate
- call `Ex03.GarageLogic`
- display results and errors

## Required Exercise Files

The provided files are:

```text
DN_2026B_Ex03.pdf
VehicleCreator.cs
VehiclesDB.txt
Ex03_ClassDiagram.docx
```

`VehicleCreator.cs` belongs in `Ex03.GarageLogic`.

`VehiclesDB.txt` belongs in `Ex03.ConsoleUI` and should be configured as:

```text
Build Action: Content
Copy to Output Directory: Copy if newer
```

`Ex03_ClassDiagram.docx` must be completed and included in the final submission folder.

## Course Material Rule

All code must stay within the material taught in the course slides and exercise documents.

Use only concepts that appear in the provided course material:

```text
01 - The .NET Framework.color.pdf
02 - CSharp (basics).color.pdf
03 - CSharp_Classes.color.pdf
04 - CSharp (Reference Types).color.pdf
05 - CSharp (Arrays, Collections).color.pdf
CodingStandards_NoSC (2).pdf
DN_2026B_Ex03.pdf
```

Do not introduce advanced syntax, frameworks, libraries, language features, or design patterns that are outside the current course material unless the user explicitly approves it.

## Local Rule Documents

Use these files while working:

- [Coding_Standards.md](Coding_Standards.md)
- [Submission_Rules.md](Submission_Rules.md)
- [Visual_Studio_Workflow.md](Visual_Studio_Workflow.md)
- [Assistant_Guardrails.md](Assistant_Guardrails.md)
- [CodingStandards_NoSC (2).pdf](CodingStandards_NoSC%20%282%29.pdf)

The assignment PDF and coding standards PDF are the source of truth. The Markdown files are working summaries to keep implementation consistent.

## Important Non-Submission Rule

This `Docs` folder and the course presentations folder next to it are reference material only.

They must not be:

- added to the Visual Studio solution
- added to any project file
- copied to output
- referenced from code
- included in the final submission zip unless the lecturer explicitly requires them

## Working Rule

Implement the project gradually. Before writing each meaningful piece of code, check that it fits:

- the Exercise 3 assignment requirements
- the two-project architecture
- the course coding standards
- the course slides already provided
- the current architecture discussion with the user
