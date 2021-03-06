<img src="https://github.com/Something-relevant/paper-dungeons/blob/master/Images/LogoType2.png" alt="alt text" align="center" width="70%" height="70%">

<img src="https://github.com/Something-relevant/paper-dungeons/blob/master/Images/Asset%2043LineBreak01.png" alt="alt text" align="center" width="50%" height="50%">

### A competitive mobile multiplayer mixed reality game

<a rel="video" href="https://youtu.be/21Mcv413tt8">Watch prototype footage here</a></br>

All testing and recordings were made on a 2019 Samsung A30</br>

The user places down paper and the game generates a procedural dungeon for the players to fight each other in.</br>
This game uses the Vuforia within the Unity Engine and was conducted as a proof of concept for a university </br>
research project about procedural level generation


-[x] Procedural Dungeons

-[x] AR image recognition

-[x] Image Plane Communication

-[x] Unique Poster Builder

-[] Single Player Mechanics Implemented

-[] Tile Creator and Exporter


## How To Play
**Download Build from the Android Build branch**

*you need the poster printed or on another screen to play</br>*

1. Change branch to Android_Build</br>
2. Download Apk and install it on your android phone</br>
  2a. To install, transfer into .../files/downloads and click on the apk file</br>
  2b. follow install instructions and click install</br>
3. Click on the app and enjoy</br>


## How To Make Your Unique Poster

*feel free to use the pre-made hi-res posters in the posters branch*

<img src="https://github.com/Something-relevant/paper-dungeons/blob/master/Images/PosterLowRes.png" alt="How It Works01" align="center" width="50%" height="50%">

1. Change Branch to Posters
2. Save Posters folder
3. Open Processing and change language to Python
4. File > Open Project > .../Posters/Poster_Builder
5. Click play and a poster should save in Poster_Builder folder
6. You now have your unique Paper Dungeons Poster

Posters save in a very high resolution and may crash Processing.py </br>
change the variable resolution to a higher number to lower the resolution


## How Does It Work

<img src="https://github.com/Something-relevant/paper-dungeons/blob/master/Images/HowItWorks01.png" alt="How It Works01" align="center" width="110%" height="110%">

<img src="https://github.com/Something-relevant/paper-dungeons/blob/master/Images/HowItWorks02.png" alt="How It Works01" align="center" width="100%" height="100%">


* The Procedural Dungeon

This procedural generation is made along a 50x40 2D grid with defined boundarys. Within the defined boundaries a pathway is created from an random selection of four 4 different arrays (Left-Right Opening, Left-Right-Top Opening, Left-Right-Bottom Opening, Left-Right-Top-Bottom Opening) which can contain an infinite amount of variations. 

Each room spawned communicates with the previous room to form a random path from the top to the bottom while ensuring there is a doorway between each room. After this pathway is created, the empty slots in the grid an filled up with random rooms.

These room variations are made from 10x10 grid with an object spawner occupying 1 square. The Object Spawer contains an array of 1x1 sized objects(tiles, enemies, hazards, consumeables, etc). The odds of what is spawned is defined by the amount of times an object appears in the array.



## Built With

* Unity 2019.3.3f1
* Vuforia AR Engine
* C#

## Refrences

<a rel="video" href="https://www.youtube.com/channel/UC9Z1XWw1kmnvOOFsj6Bzy2g/featured"> Blackthornprod - Youtube</a></br>
<a rel="video" href="https://www.youtube.com/channel/UC0UD2KSZESc5PCPzTBZC_dw"> SunnyValleyStudio - Youtube</a></br>
<a rel="video" href="https://www.gamasutra.com/view/news/340190/How_to_effectively_use_procedural_generation_in_games.php"> Darius Kazemi - How_to_effectively_use_procedural_generation_in_games - Gamasutra</a></br>

## License

<a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/"><img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-sa/4.0/88x31.png" /></a><br />This work is licensed under a <a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/">Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License</a>.

<img src="https://github.com/Something-relevant/paper-dungeons/blob/master/Images/Asset%2043LineBreak01.png" alt="alt text" align="center" width="50%" height="50%">

<img src="https://github.com/Something-relevant/paper-dungeons/blob/master/Images/Asset%203%404x.png" alt="Zenn" align="center" width="10%" height="10%">
