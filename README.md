# Timetracker

[![Build status](https://joebehrens.visualstudio.com/TimeTracker/_apis/build/status/TimeTracker-.NET%20Desktop-CI?branchName=master)](https://joebehrens.visualstudio.com/TimeTracker/_apis/build/status/TimeTracker-.NET%20Desktop-CI?branchName=master)  
[![Release status](https://joebehrens.vsrm.visualstudio.com/_apis/public/Release/badge/8391de67-5670-4945-b668-625d956959ac/1/1)](https://joebehrens.vsrm.visualstudio.com/_apis/public/Release/badge/8391de67-5670-4945-b668-625d956959ac/1/1)

This tool's goal is to provide a tool that is always on the screen to help with keeping track of time spent on specific tasks. There is a start/pause button and manualy incrementation of time and a submit button for when the task is completed. This is then tracked and viewable in a report. The tool will stay open on top of all other windows unless it is manually minimized or closed.

## Installation

Go to Releases and download the executable.

Or...  
open TimeTracker.sln in Visual Studio and run a build using the Release profile. The executable will show up in ..\TimeTracker\bin\Release\TimeTracker.exe

At this point the executable is standalone, you can copy/paste it to any location you'd like.

When you first launch a Sqlite database will be created in your user's AppData/Roaming folder with a TimeTracker folder with the name of TimeTracker.db. This will hold your time entries.

## Usage

When you launch the executable the app will open in the lower right hand corner of your screen. Use the > button to start the clock, it changes to a pause button that allows you to pause the timer without submitting. Press Submit when you've completed and want to track the task. The up down arrows are for hours and minutes for manual adjustment. The plus symbol will open another Time Tracker window.

![Time Tracker Screen Grab](https://generaljb.blob.core.windows.net/images/TimeTracker.png)
