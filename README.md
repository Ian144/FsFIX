[![License: GPL v3](https://img.shields.io/badge/License-GPL%20v3-blue.svg)](http://www.gnu.org/licenses/gpl-3.0)

# The Financial Information eXchange (FIX) Protocol in F# #

FIX code generation is the first stage of project to build a fully fledged FIX engine using F#. FsFIX generates F# types to represent FIX messages, and also generates functions to read and write these types to and from byte arrays. Session management remains to be done. Currently FsFIX can be used to connect to applications using other FIX 4.4 engines and feed them with random but valid FIX messages, in order to test the parsing machinery of both FIX frameworks. Errors were found in QuickFIXN (an open-source C# FIX engine) and FsFIX (found and fixed) in this manner, as was an issue with the FIX 4.4 spec.

Documentation for FsFIX is [here](https://github.com/Ian144/Ian144.github.io).