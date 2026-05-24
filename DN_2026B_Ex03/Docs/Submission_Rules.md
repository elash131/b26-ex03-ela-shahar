# Submission Rules

This document captures the submission rules relevant to Exercise 3.

## Core Submission Expectations

- Submit a Visual Studio solution that opens cleanly in Visual Studio for Windows.
- The solution must contain `Ex03.GarageLogic` and `Ex03.ConsoleUI`.
- `Ex03.GarageLogic` must be a class library.
- `Ex03.ConsoleUI` must reference `Ex03.GarageLogic`.
- Follow the course coding standards.
- Keep the code simple and aligned with the course slides.

## Required Exercise 3 Files

The final submission folder should include:

```text
Ex03 Ela 318481066 Shahar 207108846.sln
Ex03.GarageLogic\
Ex03.ConsoleUI\
Ex03_ClassDiagram.docx
```

The exact final names should be checked against the lecturer submission instructions before packaging.

## Files That Should Not Be Part Of The Solution

The local reference folders must not be added to the solution or projects:

```text
DN_2026B_Ex03\Docs
DN_2026B_Ex03\<course presentations folder>
```

They are not source files, not content files, and not submission artifacts unless the lecturer explicitly requests them.

## Generated Folders To Remove Before Submission

Delete these folders before creating the final zip:

```text
bin
obj
.git
.vs
packages
```

Do not delete source files, the `.sln`, the `.csproj` files, `VehiclesDB.txt`, or `Ex03_ClassDiagram.docx`.

## VehiclesDB.txt

`VehiclesDB.txt` should be included in `Ex03.ConsoleUI`.

It should be configured as:

```text
Build Action: Content
Copy to Output Directory: Copy if newer
```

The file should not remain only in the original exercise-material folder.

## Class Diagram

Complete and include:

```text
Ex03_ClassDiagram.docx
```

It should describe the main classes/enums and show the inheritance/composition relationships used by the solution.

## Final Pre-Submission Checklist

- Solution opens in Visual Studio for Windows.
- Solution builds.
- `Ex03.ConsoleUI` is the startup project.
- `Ex03.GarageLogic` builds as `.dll`.
- `Ex03.ConsoleUI` builds as `.exe`.
- `Ex03.ConsoleUI` references `Ex03.GarageLogic`.
- `VehiclesDB.txt` is copied to output.
- `Ex03_ClassDiagram.docx` is included and updated.
- No `bin`, `obj`, `.git`, `.vs`, or `packages`.
- No `Docs` or course presentations folders inside the submitted solution.
- No advanced code outside the course material.
