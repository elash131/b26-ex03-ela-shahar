# Coding Standards

This document turns the lecturer coding standards into direct working rules.

## Exercise 3 Scope Rule

These standards apply to all source code in:

```text
Ex03.GarageLogic
Ex03.ConsoleUI
```

The implementation must stay within the course material supplied in the assignment folder:

```text
DN_2026B_Ex03.pdf
CodingStandards_NoSC (2).pdf
01 - The .NET Framework.color.pdf
02 - CSharp (basics).color.pdf
03 - CSharp_Classes.color.pdf
04 - CSharp (Reference Types).color.pdf
05 - CSharp (Arrays, Collections).color.pdf
```

Prefer simple C# syntax and course-style object-oriented code. Do not use advanced language features, external libraries, or frameworks that are outside the current course material unless the user explicitly approves it.

## Project Separation Rule

`Ex03.GarageLogic` must not contain console input/output code.

`Ex03.ConsoleUI` may use the console and should call the public API exposed by `Ex03.GarageLogic`.

Reference material folders such as `Docs` and the course presentations folder must not be added to the solution or project files.

## Variables And Class Members

### Local variables

- Use meaningful names, even if they are long.
- Use `camelCase`.
- Indices with no special meaning may be named `i`, `j`, and similar when that is the natural choice.
- Avoid meaningless short names unless they are natural loop/index variables.

Examples:

- Good: `numOfItems`
- Bad: `NumOfItems`
- Bad: `numOfItems_`
- Bad: `NUMOFITEMS`

### Local const booleans

- This rule applies only to local `const bool` values, not to every local `bool` variable.
- Name local `const bool` values with the prefix `v_`.
- Use CamelCase after the prefix.
- Use them instead of raw `true` / `false` literals when passing boolean parameters to methods.
- They should always be declared as `true`; pass `!v_Name` when the negative value is needed.
- Regular local boolean variables still use normal lower camelCase, such as `shouldContinue` or `isMoveValid`.

Example:

```csharp
const bool v_IncludeSubFolders = true;
```

### Class and struct members

- Regular data members: `m_SomeName`
- Const members and local consts: `k_SomeName`
- Static members: `s_SomeName`
- Readonly members: `r_SomeName`
- Static readonly members: `sr_SomeName`

## Statements

- Always wrap `if`, `else`, `for`, `while`, and similar bodies with curly braces.
- Do not rely on single-line statement bodies without braces.

## Properties, Methods, And Indexers

### Naming

- Use meaningful names.
- Do not add underscores to method names.
- Use PascalCase for public and protected methods.
- Private methods should start with a lower-case first letter.

Examples:

- Good: `GetNumOfItems`
- Good private method: `getNumOfItems`
- Bad: `get_num_of_items`
- Bad: `Getnumofitems`
- Bad: `GETNUMOFITEMS`

### Method declaration

- Use spaces between parameter declarations, not tabs.
- Keep the method declaration on one line when reasonable.
- If there are many parameters, split the parameter list across several lines.

### Parameters

- Use meaningful parameter names.
- Prefix parameters by direction:
- `i_` = input only
- `o_` = output only
- `io_` = input and output

Examples:

- `string i_Name`
- `int i_Age`
- `ref string io_PhoneNumber`
- `out string o_Age`

## Classes And Structs

- Use meaningful names.
- Use PascalCase.

## Enums

- Use meaningful names.
- Use PascalCase.
- Prefix enum type names with `e`.
- For flagged enums, use a plural name ending with `s`.
- Do not use C++-style enum naming.
- Do not use unnecessary underscores.

Examples:

- Good: `eFuelType`
- Good flagged enum: `eFuelTypes`
- Bad: `Fuel_Type`

## Delegates And Events

### Delegates

- Use meaningful names.
- Delegate names follow class naming style.
- End regular delegate names with `Delegate`.
- If the delegate is an event handler, use the suffix `EventHandler`, not `Delegate`.

### Events

- Event names should be PascalCase.
- Event names should describe the event clearly.

Examples:

- `Closed`
- `Closing`
- `AfterEdit`
- `BeforeEdit`

### Event handler methods in subscribers

- Name them as `<senderName>_<EventName>`.

Example:

```csharp
buttonOK_Click(object sender, EventArgs e)
```

### Event raiser methods

- The internal method that raises an event should be named `OnXXX`.

Example:

```csharp
OnClick(EventArgs e)
```

## Style

### Conditions

- Prefer direct boolean assignment.

Good:

```csharp
isOldMan = age > 50;
```

Bad:

```csharp
if(age > 50)
{
	isOldMan = true;
}
else
{
	isOldMan = false;
}
```

### Duplicated code

- Do not duplicate shared code inside both `if` and `else`.
- Move the shared code outside the branch when possible.

### Layout

- Use tabs, not spaces, for indentation.
- Each nested block should be indented one tab deeper than its parent block.

### Spaces

- Do not use double blank lines.
- Do not leave redundant blank lines.
- Use spaces around operators.
- Use spaces after commas in parameter lists and argument lists.
- Do not put a space before method-call parentheses.
- Preserve one consistent control-statement spacing style within the file/repository.

Good:

- `x = t + 5;`
- `if(x == 5)`
- `Console.WriteLine("Hello {0} and {1}", name1, name2);`
- `DoSomeThing(5, 4);`

Bad:

- `x=t+5;`
- `if(x==5)`
- `Console.WriteLine("Hello {0} and {1}",name1,name2);`
- `DoSomeThing (5, 4);`

### Blank lines

- Add a blank line after the local variable declarations section.
- Add a blank line after a closing brace, unless another closing brace or `else` follows immediately.
- Add a blank line before the single return statement.

## Method Implementations

- Use only one `return` statement per method.
- Prefer methods that implement a flow by calling other methods instead of one long monolithic implementation.

## Safe Working Summary

When in doubt, prefer:

- meaningful names
- explicit braces
- clear method flow
- one return
- no duplication
- tabs for indentation
- exact naming conventions
