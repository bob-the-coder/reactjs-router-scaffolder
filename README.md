# reactjs-router-scaffolder
A small and as of yet impractical tool to create the backbone of a react app which uses react-router

## basic idea
Most applications rely on (or at least start off as) a tree structure. 
This tool is meant to help build initial components out of a simple tree structure of what I called *Hubs* and *Components* 

### component
PORC (plain old react component). Starts out by rendering its own name and the route you need to take to get to it.

### hub
PORC as well, but with the role of a sub-router. Contains links to all of its child *hubs* and *components*

# installation
As of yet, no installer is provided, and probably will not be, given that the tool is very very tiny and could simply be shipped as an executable.

# configuration v.1
Right now, the only way to configure the structure of your app is by manually changing the source code. Not very handy, but in future releases, I will providing support for JSON, XML and other structured languages

# usage
Right now, simply compile the code and run the resulting executable file (most likely in *%project_root%/bin/Debug*)
