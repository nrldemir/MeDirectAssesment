# MeDirectAssesment - Lights Out Game with Web API

How to Run?

Step 1 : Change connection string according to your sql credentials. (The "appsettings.json" file which is placed at the  "LightsOutGame.Services.Api" project) 

Step 2 : Run the "LightsOutGame.Services.Api" project. (you will see the "https://localhost:5001/swagger/index.html")

       information :
        * The Database will be created (if db not available) auto 
        and seeding the game settings to the Lights Out Game Database. (db migration)
        
Step 3 : Run the "LightsOutGame.Client.App" in new instance. (Right click over the project -> Debug-> Start New Instance)
Enter your name,surname and select board size from the combo list and then press to the "Play Game" button

       information :
        * Client App gets the game settings over Web Api and filled to the combobox.
        * When you press to the "Play Game" button, new player saved to the database. (over the Web Api)
        * If the player completed the game successfully, "IsWinned" field changes from false to true. (over the Web Api)

Thanks for you interest...

Have fun..  :)

