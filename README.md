# Timetracker

[![Build status](https://joebehrens.visualstudio.com/TimeTracker/_apis/build/status/TimeTracker-.NET%20Desktop-CI?branchName=master)](https://joebehrens.visualstudio.com/TimeTracker/_apis/build/status/TimeTracker-.NET%20Desktop-CI?branchName=master)  
[![Release status](https://joebehrens.vsrm.visualstudio.com/_apis/public/Release/badge/8391de67-5670-4945-b668-625d956959ac/1/1)](https://github.com/joseph-behrens/Timetracker/releases/latest)

The goal of this project is to provide a tool that is always on the screen to help with keeping track of time spent on specific tasks. I was finding it difficult to keep track of using other web tools that would either time out or I would forget about because they were in a tab burried in a sea of other tabs or the browser was not in focus. This application will open in front of all other windows in the lower right hand corner of your screen and stay in front of all windows unless you manually minimize or close it. All entries are saved to a Sqlite database and viewable in a report.

## Installation

Download from [HockeyApp](https://rink.hockeyapp.net/apps/420c9e40f978464296bd627651707e88) or from GitHub in the [Latest Release](https://github.com/joseph-behrens/Timetracker/releases/latest) and extract the zip package. Run setup.exe to install.

Or...  
open TimeTracker.sln in Visual Studio and run a build using the Release profile. The executable will show up in ..\TimeTracker\bin\Release\TimeTracker.exe

When you first launch a Sqlite database will be created in your user's AppData/Roaming folder with a TimeTracker folder with the name of TimeTracker.db. This will hold your time entries.

## Usage

When you launch the executable the app will open in the lower right hand corner of your screen. Use the > button to start the clock, it changes to a pause button that allows you to pause the timer without submitting. Press Submit when you've completed and want to track the task. The up down arrows are for hours and minutes for manual adjustment. You can also free type into the time box. The plus symbol will open another Time Tracker window.

![Time Tracker Screen Grab](https://generaljb.blob.core.windows.net/images/TimeTracker.png)
