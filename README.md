# GreedySnek
Classic 3D Snake redefined in 3D. Multiplayer experience built on Mirror. 

**This is just a prototype and not production ready.**
<hr/>

# Instructions

### What to expect when starting the Unity Project:

Three main folders mainly named: **_Home, _Singleplayer, _Multiplayer** 

![image](https://user-images.githubusercontent.com/22803230/218022434-38984cb3-26d4-437e-ad3d-9b4edee81bdb.png)


- [x] **_Home** contains all the files and scripts for the Main Menu.
- [x] **_Singleplayer** contains all the files and scripts for the singleplayer version of the game.
- [x] **_Multiplayer** contains all the files and scripts for the multiplayer version of the game.
- [x] **Plugin** contains the custon Unity Alert Plugin built on Java.
- [x] **Settings** contains the Unity URP settings.

**Please Note: Multiplayer experience is built on Mirror**, although Photon Fusion works best, it was sensible to use Mirror on such a small scale. **Both Singleplayer and Multiplayer versions are independent of each other**. Meaning there might be a few shared Assets between them, but they run completely standalone independent of the other.

**Please Note: Mirror might not work out of the box**. So please navigate to **_Multiplayer > Assets** and **delete the "Mirror" folder**. **Re-import Mirror** using Unity Package Mangager.

<hr/>

#### Task A will be executed when you click on the first option on the Homescreen.
![image](https://user-images.githubusercontent.com/22803230/218023014-d2c71e83-1098-4449-9af6-a8a2a918dad5.png)

#### Task B will be executed when you click on the second option on the Homescreen.
![image](https://user-images.githubusercontent.com/22803230/218023701-d35d2b55-2cc0-4ed7-99ae-5b599e158d3f.png)

#### Task C will be executed either when you click on the third option on the Homescreen, or the multiplayer game ends showing a alert at the end. 
![image](https://user-images.githubusercontent.com/22803230/218023748-f227b422-2a06-481c-b693-d19728c1029e.png)

Please use two devices for this experiment, since Java's "**currentActivity**" for **com.unity3d.player** is **not accessible in an editor**.

<hr/>


### Use the Network HUD Manager to make a Server-Client connection. Here's how to do it:
```
1. Start the Game on a device.
2. Go to Settings > Connections > Wi-Fi > Click on the connected network and check the IP Address.
3. Make a note of this IP Address.
4. Start the game on an another device.
5. Now press on the second button on the Homescreen to start the Multiplayer Game. 
6. The Session will start once both the player joins.
7. Client needs to enter the Server's IP Address in the Client Textbox given in the Network HUD Manager.
8. Server clicks on the "Host (Server + Client)".
9. Client clicks on "(Client)".
10. The Game starts once both the player joins.
```

### Thank you for trying out the Game.
