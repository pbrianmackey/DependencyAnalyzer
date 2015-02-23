# DepencyAnalyzer
Dependency Query tool for .NET.  This tool helps you determine if a project references another project somewhere down the line.  It is like a queryable database of references. This is useful for large projects where dependency diagrams can get complex on paper (gigantic UML diagrams per-se). 

##Getting Started

1. Make sure you install the dependencies listed below.
2. Clone this repository to your computer.  Let's call the place you cloned it "C:\CloneRoot"
3. Addn an app.config.  Update the app.config with your solutions:

  ```xml
 
  <?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.1" />
    </startup>
   <appSettings>
    <add key="root" value="D:\Projects\"/><!--Optional.  Leave blank if you want to specify full paths or paths do not have a common root -->
    <add key="solutions" value="Path\to\Project\Project.sln,Path2\Project2.sln,And\So\On\blah.sln"/>
  </appSettings>
</configuration>
  ```

4. Open the command line and change directory to "C:\CloneRoot"
5. execute "rake generate" (no quotes).  This creates the required Sample.pro (prolog file.) in "C:\CloneRoot"
6. execute "rake 'reference[projectName,projectName2]'" or "rake 'reference[projectName,system]'" (where system is a dll)

##Dependencies
1. https://github.com/ruby/rake

Rake is used to run commands at the command line.  This makes setup a lot easier.

2. http://www.swi-prolog.org/

A Prolog interpreter.  (Mac uers I recommend installing this program with homebrew: http://brew.sh/)

##Notes
Make root empty in the app.config if you don't have all your solutions in the same place.  Specify full paths for each *.sln file:

```
<add key="root" value=""/>
<add key="solutions" value="C:\Path\to\Project\Project.sln,C:\Path2\Project2.sln,C:\And\So\On\blah.sln"/>
```