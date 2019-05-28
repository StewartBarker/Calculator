# Calculator

**Technical specifications:**
- The target platform is UWP
- If UWP is not possible due to the lack of a suitable development environment, target Android or iOS
- Use Xamarin.Forms and .NET Standard

**Quality metrics:**
- All non-platform specific code should exist in the .NET Standard project
- Extra credit will be given for good code quality and good code organization
- Significant credit will be given for proper application of the MVVM pattern
- Extra credit will be given for writing good unit tests
- NUnit is preferred as the unit testing framework, but is not strictly required
- NSubstitute is preferred as the isolation framework (if needed), but is not strictly required
- Extra credit will be given for a well-presented UI
Bonuses (optional)
- Extra credit will be given for well-implemented expression parsing

# Approach

- Added Barker.Calculator.Core project (.net standard class library) for parser
- Added Barker.Calculator.Core.Tests nunit test project
- Added tests to assert parser gave correct result from expression
- Added parser logic (initally hand coded but switched to using regular expression as was more robust)
- Initially Added UWP project to experiment with designing form (as not used UWP before this)
- Used MVVM approach by tying the form to the view model, and the view model utilised the Calculator model (in seperate project)
- Switched to using Xamain.Forms and moved all view xaml to generic Forms project

In related to the specification the calculator:
- Has target platform of UWP
- Uses Xamarin.Forms for the calculator XAML and .NET Standard for other class libraries
- I've attempted to use the MVVM pattern, so no custom code exists in code behind files
- The keyboard input is not supported

# Further work

If I had more time to work on this I would have liked to have completed the following..
- Extended coverage of unit tests (e.g. for viewmodel etc.)
- Added IOS and Android versions
- Added more functions to the calculator
- Made the app fully responsive (e.g. at the moment the controls are responsive but the font size is not)
- Looked at creating a control template for each button
