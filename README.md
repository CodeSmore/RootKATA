# RootDrivingHistoryKATA

A KATA provided by Root Insurance that takes in driver and trip data, then displays the data for each driver in total miles traveled and average speed

## Running Tests

To easily run the tests from the command prompt, simply

"cd RootDrivingHistoryKata"
then input
"dotnet test"

## Solving the Problem

NOTE: Apologies if this is too expressive. I know how dry these can be and wanted to make it easier to swallow. Feel free to express any dissatisfaction in the form a phone call, email, or a handwritten letter...

----------------
Day 1

Right off the bat, I had a pretty good idea of how I wanted to handle the problem. 

I knew I'd likely create a Driver class and store each Driver's data into a collection in the main method. This would allow me easy access to the data and keep it simple when I added trips for the specified driver.

As I chose to adhere to Test Driven Development(TDD) principles from the start, rather than rushing in and writting the classes I thought I'd use, I started off testing the input. I decided to include .txt files in the project and to pull the input from those. 

There's nothing more frustrating than having methods and classes that can't be tested because of input issues, so getting the input and extracting it to a single string first meant I could shelf that issue and get into the nitty-gritty of the KATA.

----------------

After the input was settled, I wrote Test002 to get output from the input and print it in the correct format. My intention was simply to pass the test using a constant string and use the next test to force change using differing input data. 

After writting Test003 and pondering over how best to translate the sting of input data to names, distances, and times; I began to realize that this was too big of a step to take. 

I could see my code becoming a messy web of if-statements and loops with many local variables I knew would become obsolete before long. I furrowed my brows and my eye twitched after having to rewrite previous code a second time. 

After realizing I'd forced myself to figure out the bulk of the program in one test, I took a step back. Rereading the KATA instruction file, I found I could take a smaller step by testing an outlier case: when a driver is registered, but no trip data is provided, the mileage is zero by default.

Huzzah! The relief of breaking a problem into smaller pieces washed over me, and I quickly rewrote Test002 and the test data to reflect this new direction.

This was also the point where I created the Driver class. I decided to override it's ToString() method so I could use it to format the output for each driver from outside the main class.

I continued to ignore the trip data with my next test, and instead focused on being able to output the data for two drivers, both without any trip input. Pretty simple.

After some much needed refactoring (loop within a loop within a loop...gross), It was time to tackle the inclusion of Trip data...

----------------

To keep it simple, Test004 once again was just a single driver, with a single trip. 

I'd already extracted the input string into a list of strings. Since the format for the trip inputs was static (name, start time as 00:00, end time as 00:00, distance) and trips only took place within the 24 hours of a day, I used substring to take the parts I needed, converted time to hours, parsed the data where necessary, and added the converted trip data to it's specified driver. An oversimplification for sure, but the details of how it works are best kept in the code.

With that, I pushed the responsibility of refactoring all of that to future me. 

----------------

Day 2

With a fresh mind, I began by refactoring all of that Trip logic. Aside from creating some new helper methods, I also decided to create a Trip class. 

Admittedly, the decision to create the class had less to do with OOP and more to do with organization and limiting redundancy (oh, wait...). Creating one method that returned all the trip data made my code much easier to read and more relaxing to work on. 

----------------

Next came Test005, with two Drivers, each with a Trip. It didn't work, simply from some archaic code of mine that looped by 2s instead of by 1. I also wrote the test intending for it to test that the output was in the correct order and the rounding worked as intended.

Test006 used an input with multiple Drivers, each with multiple Trips. I was already in flow and fixed the issue before commiting the failed test to git...oops. It worked in this case, but I recognize that if I'd been wrong in my assumption, it would have been more difficult to revert back to a previous commit.

----------------

Confident that the main problem was solved, I coded Test007 and Test008 for the outliers; single Trip data when the average speed fell below five MPH or exceeded one hundred MPH.

Aaaand ready for review!  

More details on each commit can befound on my Github at "https://github.com/CodeSmore/RootKATA"

## Author

Peter Kirk
