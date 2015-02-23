# DepencyAnalyzer
Dependency Query tool for .NET

##Getting Started

1. Make sure you install the dependencies listed below.
2. Clone this repository to your computer.  Let's call the place you cloned it "C:\CloneRoot"
3. Update the app.config file to point to all the solutions you want to generate references for:

  ```xml
  <appSettings>
    <add key="root" value="D:\Projects\"/><!--Optional.  Leave blank if you want to specify full paths or paths do not have a common root -->
    <add key="solutions" value="Path\to\Project\Project.sln,Path2\Project2.sln,And\So\On\blah.sln"/>
  </appSettings>
  ```

4. Open the command line and change directory to "C:\CloneRoot"
5. execute "rake generate" (no quotes).  This creates the required Sample.pro (prolog file.) in "C:\CloneRoot"
6. execute "rake 'reference[projectName,projectName2]'" or "rake 'reference[projectName,system]'" (where system is a dll)

##Dependencies
1. https://github.com/ruby/rake

Rake is used to run commands at the command line.  This makes setup a lot easier.

2. http://www.swi-prolog.org/

A Prolog interpreter.  (Mac uers I recommend installing this program with homebrew: http://brew.sh/)