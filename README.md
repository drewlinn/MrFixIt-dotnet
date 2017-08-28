# Mr.FixIt

#### Mr.FixIt, A Web Application for a Crowd-Sourced Repair Company called Mr.FixIt. 08/11/2017

#### By Andrew Dalton

## Description

This Web Application is designed to allow users to list jobs they need completed, and volunteer for jobs that need completing. They can register for a user account, list a job, register as a worker, sign up for a job, and mark a job as complete.

## Planning

1. Configuration/dependencies

	For our Development Environment and Backend Functionality:
	* Microsoft.NETCore.App
	* Microsoft.AspNetCore.Diagnostics Version 1.0.0,
	* Microsoft.AspNetCore.Server.IISIntegration Version 1.0.0,
	* Microsoft.AspNetCore.Server.Kestrel Version 1.0.1,
	* Microsoft.Extensions.Logging.Console Version 1.0.0,
	* Microsoft.AspNetCore.Mvc Version 1.0.0,
	* Microsoft.EntityFrameworkCore Version 1.0.0,
	* Microsoft.EntityFrameworkCore.SqlServer Version 1.0.0,
	* Microsoft.Extensions.Configuration.FileExtensions Version 1.0.0,
	* Microsoft.Extensions.Configuration.Json Version 1.0.0

  2. Specifications

  | Behavior | Input | Output |
  | :--------| :---- | :------|
  | User can register for a basic account | "expandrew@gmail, "password", "password" | "You are successfully registered" |
  | Basic User can log into their account | "expandrew@gmail", "password" | "Welcome, expandrew@gmail" |
  | Basic User can post jobs | "Fix the thing", "That thing sure could use fixing" | "Job Created" |
  | Basic users have the option to sign up for a Worker Account | "Andrew", "Dalton" | "You are successfully registered" |
  | Workers can claim a job, and see it in their worker dashboard | "Cut the jib" "claimed by Andrew Dalton" | "This job has been claimed by Andrew Dalton" |
  | AJAX | | |
  | Workers can mark which jobs they're actively working on | click "In Progress" | "Andrew Dalton is working on this job" |
  | Workers can mark jobs as complete | check "Complete" | "This job was completed by Andrew Dalton" |



3. Integration

  * HomeController.cs - for routing and file integration
  * AccountController.cs - for managing user objects and accounts
  * JobsController.cs - for managing job objects
  * WorkersController.cs - for managing Worker objects
  * ApplicationUser.cs - Object Model for our registered user
  * Job.cs - Model for Job object
  * Worker.cs - Object model for our Worker User
  * MrFixItContext.cs - for Database Configuration
  * LoginViewModel.cs - ViewModel for Logging In 
  * RegisterViewModel.cs - ViewModel for Registering
  * Account/Index.cshtml - Master view for managing user accounts
  * Account/Login.cshtml - View for logging in
  * Account/Register.cshtml - View for registering as a new user
  * Home/Index.cshtml - View for our home page
  * Home/About.cshtml - View with a little information about the organization
  * Jobs/Claim.cshtml - View for claiming a job
  * Jobs/Create.cshtml - View for adding a new Job
  * Jobs/Index.csthml - View for listing all available Jobs
  * Workers/Create.cshtml - View for registering as a worker
  * Workers/Index.cshtml - View for listing Workers
  
## Setup/Installation Requirements

* Open your console or powershell command line.
* In your command line, navigate to the desktop or your desired folder destination.
* Copy the project's github address (https://github.com/drewlinn/MrFixIt-dotnet.git)
* Write in your console the command "git clone" and paste the project address afterward and press enter.
* Open the project using Visual Studio.
* Right click on the project in the Solution Explorer Pane and click "Build".
* Use your console to navigate to the "MrFixIt/src/MrFixIt".
* In the Command Line, type the command "dotnet ef database update".
* Once this process is complete, in Visual Studio, click on the button in the tool bar with the green PLAY SYMBOL that says "IIS EXPRESS" next to it.
* Your default web browser should open and navigate to the designated localhost automatically.
* The application should be displayed in your browser with full functionality.


## Known Bugs

No bugs currently known.

## Support and contact details

If you notice any bugs in my program or any other issues with my code, please email me at expandrew@gmail.com

## Technologies Used

HTML
CSS
Bootstrap
C#
Visual Studio 2015

### License

This software is licensed under the MIT license.

Copyright (c) 2016 **_{Andrew Dalton, Epicodus}_**