# Assistant Guardrails

These are the working rules I should treat as binding when helping on this Exercise 3 project.

## Highest Priority Rules

1. Always answer the user in English.
2. Keep `Docs` and the course presentations folder outside the solution and outside all project files.
3. Do not add references to `Docs`, the course presentations folder, or course material from the submitted code.
4. Follow the Exercise 3 PDF and provided starter files.
5. Follow the course coding standards exactly.
6. Use only material that appears in the course slides/documents unless the user explicitly approves otherwise.
7. Do not invent file names, project names, class names, or submission structure when the exercise already defines them.
8. Do not leave generated folders in the final hand-in.

## Course Material Boundary

The implementation should use only concepts from:

```text
01 - The .NET Framework.color.pdf
02 - CSharp (basics).color.pdf
03 - CSharp_Classes.color.pdf
04 - CSharp (Reference Types).color.pdf
05 - CSharp (Arrays, Collections).color.pdf
CodingStandards_NoSC (2).pdf
DN_2026B_Ex03.pdf
```

Avoid advanced or newer C# features that may not be part of the course material, including unnecessary LINQ-heavy solutions, modern syntax shortcuts, reflection, async/await, external libraries, dependency injection frameworks, records, pattern matching-heavy code, or other concepts not covered by the slides.

Prefer simple, explicit, course-style C#.

## Coding Guardrails

- Use the lecturer naming conventions exactly.
- Use braces for statement bodies.
- Use tabs for indentation.
- Keep one return statement per method when implementing course-style solutions.
- Avoid duplicated code.
- Keep method and type names meaningful and consistent with the standards.
- Respect parameter prefixes: `i_`, `o_`, `io_`.
- Respect member prefixes: `m_`, `k_`, `s_`, `r_`, `sr_`.
- Respect enum prefix `e`.
- Use `v_` only for local `const bool` values used instead of raw `true` / `false` method arguments.
- Regular local boolean variables use normal lower camelCase.

## Architecture Guardrails

- `Ex03.GarageLogic` is the reusable logic library.
- `Ex03.ConsoleUI` is the console executable.
- The UI project may reference the logic project.
- The logic project must not reference the UI project.
- Logic classes must not read from or write to the console.
- Keep the object model clear and close to the assignment wording.
- Prefer composition for "has a" relationships, such as `Vehicle` having `Engine` and `Engine` having `EnergySource`.
- Prefer inheritance only where it expresses a real "is a" relationship required by the model.

## Current Model Guardrails

The current agreed starting model is:

```text
Vehicle
|-- FuelCar
|-- ElectricCar
|-- FuelMotorcycle
|-- ElectricMotorcycle
`-- FuelTruck

Vehicle has Engine

Engine
|-- FueledEngine
`-- ElectricEngine

Engine has EnergySource

EnergySource
|-- FuelEnergySource
`-- ElectricEnergySource
```

Do not add extra middle classes such as `Car`, `Motorcycle`, or `Truck` unless the user explicitly decides to add them later.

Keep the engine abstraction aligned with lecturer feedback: `Vehicle` should not directly hold specific fueled/electric energy members.

## Solution Structure Guardrails

- Keep the solution compatible with Visual Studio for Windows.
- Keep the solution with two projects: `Ex03.GarageLogic` and `Ex03.ConsoleUI`.
- `Ex03.GarageLogic` must have `OutputType` set to `Library`.
- `Ex03.ConsoleUI` must be the startup project when running the program.
- Keep `VehiclesDB.txt` in the console project as content copied to output.

## Submission Guardrails

- Treat naming formats as exact, not approximate.
- Remove `bin`, `obj`, `.git`, `.vs`, and `packages` before final packaging unless the lecturer says otherwise.
- Include the completed `Ex03_ClassDiagram.docx`.
- Keep the zip structure clean and predictable.
- Do not include local reference docs or course slides in the final submission unless explicitly required.

## Review Guardrails

Before saying a submission is ready, verify:

- naming
- folder cleanliness
- Visual Studio compatibility
- project references
- coding style compliance
- final zip readiness
- no accidental references to `Docs` or the course presentations folder

If any of those fail, the work is not submission-ready yet.
