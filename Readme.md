# Windows Service Demo
A Windows service demo that deletes files continuously

## Project scope
The scope of this project is to delete files from a determined folder (Trash files) every lapse of time (Config file).
Also, the service can filter what type of files can be skipped on the deletion (Again, config file section). 
Of course, all happens in the background.

## What is a Windows Service? 
A Windows service is a computer program that operates in the background and does 
not have any user interface. It can be automatically started when the computer boots,
can be paused and restarted, and can run in a different security context from the logged-on user.
More details [here](https://learn.microsoft.com/en-us/dotnet/framework/windows-services/introduction-to-windows-service-applications)

## How to debug? 
It's hard, doesn't matter if you have experience. The simplest way is to print in the source code comments that can be read in the "Event Viewer", a native app of Windows.
Yes, you only can debug after publishing and installing the service. As I say, hard as hell. 
Details [here](https://learn.microsoft.com/en-us/dotnet/framework/windows-services/how-to-debug-windows-service-applications)

## Config file
The configuration file can be found in the next path
> C:\Users\Public\LoftwareFixer

Inside the file, you can find JSON format data. Only have 3 parameters to config:
1. AllowedFileType: What type of file can be filtered (These types of  files won't be deleted, default: example.pass)
2. DelayTime: The delay between deletion (Default 5 seconds (5000 milliseconds))
3. Path: The absolute path where the Service will delete trash-files 

Note: The service only read the config file when you start the service itself. If you change any 
parameter in the config file you should restart the service in the Services app of Windows.

## Deploy
Deploy the service with a .MSI installer, more details [here](https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service-with-installer?tabs=wix)

## Technology
1. .NET 6
2. C# 
3. JSON (Config file)

## License
The Laughing Out Loud License (LOL)

Version 1.0, July 2023

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

1. You must acknowledge that the Software is hilarious and make at least one person laugh when using it.
2. You must not claim that you wrote the original Software or that you are smarter than the original author(s).
3. You must not use the Software for evil purposes or to hurt anyone's feelings, unless they really deserve it.
4. You must not sue the original author(s) or anyone else for any damages arising from the use of the Software, even if it causes your computer to explode or your cat to run away.
5. You must share any funny modifications or improvements that you make to the Software with the original author(s) and the world.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
