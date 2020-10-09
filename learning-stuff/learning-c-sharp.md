# stuff

_Legend_
- WIDG: What I Didn't Get - Basically stuff I read but didn't understand completely/well. 

## C Sharp
### The basic basics
- Print -> `Console.WriteLine("");`
- Need `;`s and PascalNamingConvention;
 
### Type System [Docs Link to page](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/)
Alright this page was...cool. Like thoda confusing but it introduced me to stuff and clarified some stuff as well.

- Everything in c# is a `system.object`, like everything
- System.object is then used to make 2 kinds of types: Reference types and Value types (reference types get passed by reference walli story)
- Now each `value type` can be made in 2 way: struct and enum. 
	- A struct is like a mini-class.
	- An enum is like a numeric list that when used looks good/is readable to the guy trying to understand what's going on.
	- value types can't be extended to make more types and are called "sealed".
- Coming to reference types:
	- The cool understanding bit: all reference types need the `new` keyword. In certain cases, C# infers stuff for us and hence we don't need to repeatedly write "new" e.g. in arrays.
	- Reference types can be made in 2-3 ways: classes, interfaces and delegates  
- _WIDG_: 
	- Boxing thingie mentioned
	- Interfaces
	- Delegates



- `List<T>` = A collection, here a list, of the type `T`.

### Understand .NET kinda stuff
- Entity framework is like Mongoose or Prisma but built by Microsoft for SQL...I think.
- NuGet is the package manager for .NET stuff
- CLR (Common Language Runtime) -> so .NET support languages get compiled into a intermediate language thingie called CLI (I think), and then CLR can compile that at runtime to the native/assembly code (basically stuff that can run on native machine).

- _namspaces_
Basically 2 thingies
- They act as containers for classes, which sounds like a module from python or js.
- They also help out in defining scope for classes/methods when we're writing kaafi code. So I guess, they're like classes for classes lol. no offence.

_WIDG_: The global namespace is the "root" namespace: global::System will always refer to the .NET System namespace.  

## asp.net core stuff
### Razor pages basic tutorial
- 

_WIDG_ - So do Models, aka POCO classes, have or do not have dependency on the Entity Framework? https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-3.1


## Vim
> Main reason for vim stuff is that text files are just easier/more convenient to do in the terminal itself (no application needs to be opened)

- :w -> saves stuff (i think)
- :q -> quits vim
- hjkl -> arrows keys for moving around in Vim...except the arrow keys lol
- web -> w is next word, e is end of word, b is start of current word. 



## git stuff
> (if at all I learn some git stuff)

## TODOs: Figure the following stuff out
- Razor syntax (https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-3.1#razor-syntax)
- Dependency Injection (https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1)
- Data Attributions (https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-3.1)
- Classes
- Interfaces
- Enums // might be mini-classes
- Delegates
- Attributes
- Async Code
- LINQ
- Arrow function thingie


## Doubts
- "By default, the most frequently used types in the class library are available in any C# program. Others become available only when you explicitly add a project reference to the assembly in which they are defined."
 -> Is a project reference different from a "using <XYZ>" statement?

## If stuff works out, here's probably how I learnt it:
- Microsoft Docs
- Brackeys
- Vim Cheat Sheet - https://www.fprintf.net/vimCheatSheet.html
