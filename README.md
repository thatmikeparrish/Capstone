# Cost Estimator

Backend capstone for Nashville Software School (NSS). This is a Cost Estimation web app I created for myself to work on future projects.

## Getting Started

The following instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install the software and how to install them

* Visual Studio
* Microsoft SQL Server Managment Studio

### Installing & Running

A step by step series of examples that tell you how to get a development env running

* Fork a copy of the Repo
* Download or Clone the Repo to your local machine
* Open the project in Visual Studio, look for SQL Server Object Explorer and navigate to your local database. Right click on the name and click on properties. Look for "Connection String" and copy the value to the right of it.
* Paste that value over "Default Connection" in appsettings.json
* Navigate to Tools then NuGet Package Manager, run "add-migration Database", then run "update-database".
* Look at the top bar and find the green arrow "play button", and make sure BangazonAPI is selected and click the arrow.

* Enjoy!

## Built With

* C#
* .Net

## Authors

* **Mike Parrish** - [thatmikeparrish](https://github.com/thatmikeparrish)

## Acknowledgments

* Special thanks to **Andy Collins** - [askingalot](https://github.com/askingalot) for putting up with like a billion questions!

## Notes

* Here is the ERD for my project.
![Cost Estimator ERD](https://github.com/thatmikeparrish/Capstone/blob/master/erd.png)
