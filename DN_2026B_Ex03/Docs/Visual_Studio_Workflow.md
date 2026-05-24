# Visual Studio Workflow

This is the Visual Studio workflow for Exercise 3.

## Approved Environment

- Use `Visual Studio for Windows`.
- Keep the project in classic .NET Framework style.
- Build and run from the `.sln` file.

## Required Solution Structure

The solution must contain:

```text
Ex03.GarageLogic
Ex03.ConsoleUI
```

`Ex03.GarageLogic`:

- output type: `Class Library`
- produces `Ex03.GarageLogic.dll`
- contains model and business logic
- must not use console input/output

`Ex03.ConsoleUI`:

- output type: console executable
- produces `Ex03.ConsoleUI.exe`
- contains the console UI
- references `Ex03.GarageLogic`

## Creating Or Fixing The Projects

If the projects are missing from the solution:

1. Right-click the solution.
2. Choose `Add`.
3. Choose `Existing Project...`.
4. Add `Ex03.GarageLogic\Ex03.GarageLogic.csproj`.
5. Add `Ex03.ConsoleUI\Ex03.ConsoleUI.csproj`.

If the UI project does not reference the logic project:

1. Right-click `Ex03.ConsoleUI`.
2. Choose `Add`.
3. Choose `Project Reference...`.
4. Check `Ex03.GarageLogic`.
5. Confirm.

## Startup Project

Set the startup project to:

```text
Ex03.ConsoleUI
```

Do not run `Ex03.GarageLogic` directly. It is a class library.

## Adding Existing Files

When adding source files manually on disk, Visual Studio may not show them immediately in old-style `.csproj` projects.

Use one of these options:

- right-click the project and choose `Reload Project`
- unload and reload the project
- add the file through Visual Studio
- verify that the `.csproj` contains the required `Compile Include` entries

## VehiclesDB.txt

`VehiclesDB.txt` should be inside `Ex03.ConsoleUI`.

In Visual Studio, set:

```text
Build Action: Content
Copy to Output Directory: Copy if newer
```

This makes the file available next to the executable after build.

## Reference Material Rule

The following folders are not part of the Visual Studio solution:

```text
DN_2026B_Ex03\Docs
DN_2026B_Ex03\<course presentations folder>
```

Do not add them to the solution. Do not link them into the project. They are local guidance only.

## Pre-Work Check

Before implementing code, confirm:

- both projects appear in Solution Explorer
- `Ex03.GarageLogic` builds as a class library
- `Ex03.ConsoleUI` references `Ex03.GarageLogic`
- `Ex03.ConsoleUI` is the startup project
- no reference docs are visible as solution/project items
