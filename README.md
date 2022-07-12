This project is a tool to assist with dice rolling games. It will be able to digitally roll dice and calculate dice probabilities for the user. 
For example you could ask the program to tell you the percentage chance of rolling at least 3 5s or higher on 7 six-sided dice (d6). 

This is a console application which requires you enter commands typed in a particular way: 

exit (end program)
clear (clear console)
roll #d# (#=a number greater than 0, the former is amount of dice, the latter is the number of sides)" +
prob #d# #(+) #(+) (#=a number greater than 0 and + is option to signify at least this number, " +
      1st is amount of dice, 2nd is number of sides, 3rd quantity of target results, 3d is target result)" +
chart #d# (#=a number greater than 0,the former is amount of dice, the latter is the number of sides," +
      creates a chart of probabilities for every success condition (except 1+) at any possible amount)\n");
see ("rolls" or "probs" or "charts") (shows recorded log of all rolls, probabilities, or chart requests [not the full charts] from the current session)

You can type "help" in the application for this information as well.

Features a main loop to repeatedly enter commands, input validation utilizing regular expressions, invalid inputs being written to a text file, 3 unit tests to make sure the program is functioning as intended, and a chart command to visualize probability data.
