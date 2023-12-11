# Abstract
&emsp;&emsp;The project is a 3D game with first-person Pac-Man gameplay. The player will take on the role of a traveller who mistakenly enters a fairytale world by touching a teacup. You need to collect all the sugar cubes in the scene and drop them into the teacups while escaping from the monsters. There are two main levels(cups)
<div align=center><img width="700" height="400" src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/Abstract.png?raw=true"/></div>

# 1. Game Design Ideas
## 1.1 Source of Inspiration
&emsp;&emsp;In terms of **gameplay**, this game is inspired by the 2D game **"Pac-Man"**. The main gameplay is to collect all the sugar beans to complete the game, and we have upgraded and optimised it. We have upgraded and optimised the game, and the transformation between 2D and 3D games can often make a big difference in the gaming experience. For example, a Pac-Man game can be transformed into a more intense and exciting game.  
<div align=center><img width="400" height="300" src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/bean.png?raw=true"/></div>

&emsp;&emsp;In terms of **background setting**, the story is set up to be reminiscent of **the Wizard of Oz**, a quirky fairy tale, and so derives its own imaginative creation of the story world under the major theme of fairy tales.
<div align=center><img width="400" height="300" src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/OZ.jpg?raw=true"/></div>

## 1.2 Background Setting
- **Player Settings** :smiley:    
&emsp;&emsp; **Eric** , the main character of the game played by the player, finds a dining table full of tea sets. But two of the teacups were flooded with a different sight, completely different from reality. It's as if it's drawing him/her forward and closer all the time. He was just about to touch them lightly with his fingers when he was sucked in all at once. At that moment, a voice told him to collect all the sugar cubes scattered in the scene in order to get out of this world.
- **Level 1** :video_game:   
&emsp;&emsp;The first level is set in a forest maze inhabited by bell cats. The three bell cats spread lots of sugar cubes on the paths and then patrol along the high walls of the maze to prevent any foreign intruders from stealing their sugar cubes, and once they are found, they will be caught by the bell cats and never be able to get out of this forest maze. The bell cats will follow your scent to find you, while the huge bells on their bodies will sound to signal their arrival. Collect the scattered sugar cubes and escape before they catch you!
<div align=center><img width="400" height="400" src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/level1.png?raw=true"/></div>

- **Level 2** :video_game:   
&emsp;&emsp;Passing through the forest labyrinth inhabited by the bell cat, you will see the castle in front of you. The second level is set in a castle guarded by Chess Knights. The Chess Knights appear to be standing guard, but when an intruder arrives, the five knights enchanted by the lord of the castle will activate. When the knights are out of the player's reach, they will glide quickly and step behind the intruder to catch him. Players will have to spot the enchanted knights through keen insight and evade their pursuit by placing the sugar cubes in the cups.
<div align=center><img width="400" height="400" src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/level2.png?raw=true"/></div>

- **Monster Image Design**  
&emsp;&emsp; :pouting_cat:  **Bell cats** ,They are more cartoonish but have sharp fangs and claws, and live in a maze of forests covered in sugar cubes; they are usually mild-mannered and have a very quick pace, but become vicious once they find that someone has entered their territory and tried to touch the sugar cubes.  
&emsp;&emsp; :guardsman: **Chess guards** , based on chess, black and white, dressed in armour, with chess pieces as their bodies and swords in their hands, guarding the Square Sugar Castle, spending their days in a standing position, but in fact moving sensitively, moving quickly out of sight of intruders.
<div align=center><img width="800" height="300" src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/bellcat.png?raw=true"/></div>
<div align=center><img width="1200" height="270" src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/knight.png?raw=true"/></div>
<p align="center">(The above pictures are Bell cats and Chess guards in that order)</p>

- **Main game props** :coffee:  
&emsp;&emsp; **Square Sugar** , a prop that Eric needs to collect. When all are collected and put into the teacups, the sugar cubes will activate a mysterious power to send Eric back to the original world, back to the table where the teacups were placed.  
&emsp;&emsp; **View Candy**  is a prop that needs to be collected just like the Candy Cube. The difference is that the View Candy has the effect of monitoring the real-time location at a glance, and one capsule lasts for 20s.
<div align=center><img width="800" height="380" src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/sugar1.png?raw=true"/></div>
<div align=center><img width="800" height="380" src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/sugar2.png?raw=true"/></div>
<p align="center">(The above pictures are Square Sugar and View Candy in that order)</p>

## 1.3 Main Gameplay
&emsp;&emsp;The main character of the game is controlled using the four basic control keys ASDW, with the mouse to achieve the character's running and change direction.
### 1.3.1 Level 1
- **Level Difficulty** :star:  :star:  :star: 
- **Level Mechanisms**  
The player has three enemies in this level, the three bell cats.  
 :innocent: Normal Mode: the enemies, whose speed is constant and lower than the player's speed, patrol the maze. When the player is very close to the enemy (the distance between them is less than or equal to 5 metres), the enemy will speed up to the same speed as the player and keep it there for two seconds, automatically approaching the player's direction and attempting to capture the player, at which time the player needs to escape from the enemy by changing direction and moving away (the distance between them is greater than 5 metres).  
 :smiling_imp: Crazy Mode: When the number of sugar cubes in the field is less than 20%, the bell cat will speed up but still slightly slower than the player, and start searching the field for the player.
- **Level Tips**  
① Throughout the game, the player can see the mini-map in the lower left corner, i.e. the status page, where the player can see the approximate terrain around him and the number of cubes remaining on the field.  
② When the number of cubes in the field is below 50%, the mini-map will guide the player to the location of the nearest cubes, so that the player can collect them faster.  
③ When all the candies have been collected, the mini-map will guide the player towards the starting point so that he/she can quickly return to the original point to complete the level.  
④ When the bell cat notices that the player is close to him and starts to chase him, the background music of the game will change to remind the player that he needs to run away as soon as possible.  
⑤ The bell cat will emit cat calls and bell sounds, and the player can judge the distance by its proximity.
<div align=center><img width="300" height="400" src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/level1_map.png?raw=true"/></div>
<p align="center">(The image above is an overhead view of Level 1)</p>

### 1.3.2 Level 2
- **Level Difficulty** :star:  :star:  :star:  :star:  
- **Level Mechanisms**  
The player has three enemies in this level, the three bell cats.  
 :eyes: The player has five enemies in this level, namely five enchanted chess guards. They are mixed in with the normal guards and need to be identified by the player.The enemies will only move when the player's line of sight moves away from them. Once the player's line of sight is removed, the enemies move towards them at a higher speed than the player and attempt to capture them.  
- **Level Tips**  
① Throughout the game, the player can see the mini-map in the lower left corner, i.e. the status page, where the player can see the approximate terrain around him and the number of cubes remaining on the field.   
② When the number of cubes in the field is below 50%, the mini-map will guide the player to the location of the nearest cubes, so that the player can collect them faster.  
③ When all the cubes have been collected, the mini-map will guide the player towards the starting point so that he/she can quickly return to the original point to complete the level.  
④ When the guards move, there will be a small sliding sound against the ground, so players can listen carefully to determine whether they are moving closer.  
⑤ Players can identify the casted guards by moving their eyes away from them and observing their position or by positioning the view cube.
<div align=center><img width="300" height="400" src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/level2_map.png?raw=true"/></div>
<p align="center">(The image above is an overhead view of Level 2)</p>

# 2. Game features and innovations
- **first-person game**  
&emsp;&emsp;First of all, we believe that a major highlight of this game is the first person, the player to explore and chase the first perspective, can have a better playing experience, can be more immersive, will bring themselves into the game scene, to experience that careful collection of sugar cane tension and fun; at the same time, this also reaches the completion of the process of our production team in the completion of a design, the fairy tale is not only quiet and beautiful, but it is also Fairy tales are not only quiet and beautiful, but also exciting and adventurous, just like Dorothy in the Wizard of Oz, the main character of the story we designed has grown up through the adventures and experiences, and the first-person person brings her into the game to give her the tension, which is exactly in line with this design.
- **The original grotesque fairy tale style story background and its rich connotation**   
&emsp;&emsp;As mentioned in the previous point, fairy tales are more than just quiet and beautiful, and they are more than just an ordinary story to read. As game designers, we want to convey our own ideas to players through our games. Curiosity kills the cat, if you don't get close to the teacups, you won't be sucked in and forced to collect sugar cubes; the golden nest is better than your own doghouse, if you want to leave, you have to "get out of the tiger's mouth" to collect the sugar cubes and pay for it. ...... Seemingly simple game design is actually rich in profound connotation, we hope that their original background story to bring players not only the fun of playing the game, but also a rich spiritual content.
- **Original stand-alone model design and production**    
&emsp;&emsp;All the models in the game were designed and produced by the students in the group, from conception to finalisation, from design to modelling, all were done by the group members themselves. The original material not only has its own complete copyright, but also can better shape the game itself. The design and production of each of our models have been constantly refined, and the overall style is cartoonish, very uniform style, into the game screen in harmony and order, can bring players a better visual experience of the game.
- **Rich soundtrack sound effects**    
&emsp;&emsp;Throughout the game, we are equipped with appropriate background music in different scenarios and stages of the game, and we have designed necessary sound effects for each model present, such as the bell cat's purring, bell sound, and the sliding sound of the chess guards, and each sound effect is carefully selected by the team members and made with their own hands, which greatly accentuates the atmosphere of the game, and together with the picture, it gives the players a double feast of visual and auditory sensation.
# 3. Technical realisation
## 3.1 Modelling
&emsp;&emsp;The characters, props and scenes in the game were meticulously modelled according to our own sketched concept artwork.And We use Blender for bone binding and simple animations.\
<div align=center><img src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/modelling.png?raw=true"/></div>

## 3.2 Codding
&emsp;&emsp;The main core code can be divided into three modules: player control, enemy AI, and mini-map display.
- **Player Control**    
&emsp;&emsp;In addition to the basic movement of the player such as forward and backward, in this module we also add the detection of collision of sugar cubes, so as to achieve the collection of sugar cubes, the real-time display of the number of remaining sugar cubes on the field UI
- **Enemy AI**    
&emsp;&emsp;The AI of the enemies in the period is mainly achieved by cycling through several states; they are standby, patrol, and chase. When they are more than a certain range away from the player, they will randomly head to a checkpoint near the player to patrol, and once they are in range of the chase, they will go into chase mode, moving quickly in the direction of the player, and when the player gets rid of the enemy, they will continue to return to the patrol state
- **Mini-map Display**    
&emsp;&emsp;The map is implemented primarily with a camera looking vertically down at the ground, while the maze walls, the player's and the enemy's heads are placed with differently coloured positional points. The focus of the camera is adjusted so that it can only see these locations, and the camera frame is captured and placed on the UI plane.
# 4. Results Showcase
&emsp;&emsp;Below are screenshots from the live play session：
- Level 1:
<div align=center><img src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/Game_level1.png?raw=true"/></div>

- Level 2:
<div align=center><img src="https://github.com/AlisonMeii/CUP_UnityGame/blob/main/image/Game_level2.png?raw=true"/></div>
