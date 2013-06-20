# Robots

This solves a similar classic programming challenge to my Mars (Scala) repo. In this case the language is C# and there is no "scent-marking" by the robots so it's a bit simpler. The lack of Scala's case classes is sorely missed here and I've deliberately taken a more classically OO/imperative approach in order to appreciate the differences with functional programming. However overall I think it's a pleasant enough result and has a nice set of unit and functional tests.

## Notes

- The Program class is where it all kicks off, which reads config, processes the missions and writes the results. There are functional tests that run this end to end.
- The Battle class is the core of the program, which takes the config and actually runs the robots' missions.
- The Robot class contains the Left, Right, Move implementations as methods. It also parses the individual command character to determine what to do with it - invoking the relevant method. It would be easy to massively over-engineer this part of the process and apply 'design patterns' with abandon, but that would more than likely obscure the simple mechanics of what is happening. The current design would make it fairly easy to have different Robot classes that respond to different commands or the same commands differently.
- The Config class has some 'builder' aspects that make it a bit sweeter to assemble config, which is especially useful in the tests for making test config more readable.
- The NUnit tests are quite extensive but simple to read. A nice abstraction (that I can only take credit for finding and using) is used to check that console output is correct in the functional tests.


## Building and running

I built this with Xamarin Studio on Mac OS - my first foray into using that IDE and .NET outside of Windows. It has not been tested on Windows so may suffer from cross-platform issues - especially with file separators. I figure most Windows devs writing C# code don't worry about non-Windows separators as they're targetting Windows, so it's reasonable for me to target Mac OS here and consider Windows support as an additional feature to be added later if required.