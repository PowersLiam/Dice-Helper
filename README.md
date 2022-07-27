This project is a tool to assist with dice rolling games. It will be able to digitally roll dice and calculate dice probabilities for the user. 
For example you could ask the program to tell you the percentage chance of rolling at least 3 5s or higher on 7 six-sided dice (d6). 

This is a console application which requires you enter commands typed in a particular way (although it is not case sensitive): 

exit (end program)
clear (clear console)
roll #d# (#=a number greater than 0, the former is amount of dice, the latter is the number of sides)" +
prob #d# #(+) #(+) (#=a number greater than 0 and + is option to signify at least this number, " +
      1st is amount of dice, 2nd is number of sides, 3rd quantity of target results, 3d is target result)" +
chart #d# (#=a number greater than 0,the former is amount of dice, the latter is the number of sides," +
      creates a chart of probabilities for every success condition (except 1+) at any possible amount)\n");
see ("rolls" or "probs" or "charts") (shows recorded log of all rolls, probabilities, or chart requests [not the full charts] from the current session)

You can type "help" in the application for this information as well.

The main class is Program.cs, it contains the main loop
There is also Dice.cs, this contains methods for performing functions and calculations as well as having lists of all results created from those methods called using this object which can be viewed in program

FEATURES
1. A main loop to repeatedly enter commands. Found in Program.cs.
2. Input validation utilizing regular expressions. Found in Program.cs.
3. Invalid inputs being written to a text file. Code found in Program.cs, InvalidInputLog.txt file found in Dice Helper/bin/Debug/net6.0.
4. 3 unit tests to make sure the program is functioning as intended. Found in DiceTest solution in the UnitTest1.cs.
5. A chart command to visualize probability data. Called in main loop in Progeam.cs, but calculated and printed to console in Dice.cs.
