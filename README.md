# Astro Party II

### Brief Summary:
This is a recreation of the game Astro Party. I am not using it for commercial purpose, so please don't sue me.

### Development Log: (MM-DD-YYYY: "LOG")
* #### Yuxiang Huang:
    *  (08-26-2022): Today I began the project by making a simple rectangular map and controls for the player ship, including rotatation and shooting.
    *  (08-27-2022): Today I started by adding the ammo restraint for the ships. Each ship has at most three ammos and reload one every two seconds. In addition, I added the animation for how many ammo each ship has. After that, I changed the camera to orthographic and resize everything. Then I added laser beam to the game, including the first sound effect of the game. Next, I worked on the UI by having three chained screens. Lastly, I struggled with a bot and finally got it to work in the end of the day. Throughout the day, I also fixed a variety of issues I discovered while testing the game."
    *  (08-28-2022): "Today I made the minimum viable product for the ship screen. The player is able to choose at most four ships, making them player or bot. Then, I fixed their spawning positions and make bot attack the closest ship.
    *  (08-29-2022): Today I started by creating an end screen, which includes a rematch button and a back to ship screen button. Then, as I was going to write the code for displaying the winning message, I realized that it would be better to implement the team system first. Thus, I spent the rest of the morning working on the team system and resolving various issues that come with it. Later in the day, I spent an hour giving players the option to choose their prefered controls. Lastly, I fixed an issue by making the team button only appearing when player is on and optimize the text for the team numbers.
    *  (08-30-2022): Today I spent almost all my time working on the score board and finally got it to work.
    *  (08-31-2022): Today I started with displaying the winning message for the team mode. Then I added the solo mode where each player win points by killing other ships instead of being the last one alive. Also, I added features like team ships move together in the score board and better pictures. In addition, I fix issues in the score board and rematch button.
    *  (09-01-2022): Today I started by making an option for friendly fire in team mode. Then, I started the pilot hunting mode by making a controllable pilot. In addition, I perfect the scoreboard, AI moving, and capped the velocity of ships and pilots in the game.
    *  (09-02-2022): Today I spent a lot of time and finish almost everything except the maps and powerups. I perfected the score system after adding the pilot and did the UI for the pilot vs ship mode. Then I wrote a universal script for the bot and the ship that includes everything they share, so when I add the powerup system I don't need to write the code twice for each powerup. I also spent a lot of time perfecting the AI and the score board. I realize I shouldn't update the AI agent destination every frame and maintained the function for the score board after scaling. Lastly, I play tested the game and fixed issues that I find.
    *  (09-03-2022): Today I started by making an option for fixed spawn position. Then, I worked on the map system and set the foundation for adding more maps easily. There are two maps as for now and I can turn them on and off. Lastly, I added the laser indicator, which can be attracted by other ships and allow them to shoot laser beam once.
    *  (09-04-2022): Today I started by adding more sound effects to the game. Then, I worked on UI for the info screen and the power up screen. For power ups, I am able to spawn one in the middle of the map every round and make ships drop it when they have it but didn't use it yet. Lastly, I added the starting power up option for each ship. 
    *  (09-05-2022): Today I started by adding the double tap dash control for the player ships. Then I added a Sound Effect Manager that handles all the sound effects and added the sound effect for the ship, pilot and the preparation stage. Lastly, I spent a lot of time working on the asteroid system that contains four kinds of asteroids. I encapsulating the power up indicator in the asteroid and finish the spawning mechanics.
    *  (09-06-2022): Today I started by perfecting the asteroid system. One feature I added is that the larger asteroid will break up into smaller ones after destroyed. I also added an option for the player to choose the number of asteroids and the movement of the asteroid. Then, I remake the ships in order to change the collider and add the jouster and side cannon for tomorrow. Lastly, I am half way done with scatter shot.
