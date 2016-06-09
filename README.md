# Sprout
Team D4D - Design Doc v0.3
Arsany Azmy | Connor McGwire
Michael Ritchie | Spencer Milner

---

## CHANGE LOG
### Version 0.1 – April 26, 2016
-First version of the document. Template based on link noted in “Links” section
-Removed “Mods” and replaced a few sections are based on the template in Game Design Workshop by Tracy Fullerton

### Version 0.2 - May 4, 2016
-Document Restructured
-Some Art added
-Object section removed as information was redundant
-Sections clarified
-Added level design section
-Link to Trello Board added

### Version 0.3 - May 19, 2016
-Description amended
-’What is unique’ amended
-’Why make this game’ amended
-Deleted ‘sticky seed’ entries

### Version 0.4 - May 26, 2016
-Tutorial updated for clarity and playability
-Jump changed to feel more fluid and fixes getting stuck bug
-Levels updated for difficulty or design
-Added a silver seed/planting spot/tree for the regions and changed it so that the golden seed is for the main hub region and the silver stuff is for each region
-Added “progress marker” rock visual in the main hub region to better indicate player goals
-Slight changes to the wind ability for easier use
-Added sound in several places including background music
-”Win Screen”
-Added a mechanic that allows you to grab the seed
-Added seed reset zones for when the player messes up or puts it in impossible to reach areas. Mostly for player convenience and error handling

---

## GAME OVERVIEW
In a Sentence
“Explore a mysterious world; turn a wasteland into paradise.”
Gameplay synopsis
Traverse the world solving environmental puzzles with your abilities to progress through the regions and save the world from rotting.

---

## GAME DETAILS
### Description 
Moves around in a classic 2D platformer style. Levels encompass a set of related puzzles in a scrolling world, with hard transition points between full levels. 

Each level is composed of up to four sub levels with a central hub.  Sub levels are completed by planting and watering the silver seed.  One golden seed can be found in each sub level.  This golden seed can be physically rolled to the central hub and planted there.  Once the golden seed from each minilevel has been planted in the central hub, the player will be able to reach the next level.

Puzzles are environmental based where the player manipulates the environment with a small set of abilities.

The dead wasteland transitions to a beautiful live wilderness as the player progresses.

### Genre
Single Player Puzzle/Adventure

### Setting
-Post apocalyptic setting
-Wastelands/Abandoned Cities/Mountains

### Player Character
Wooden Sprite Creature with ability to bring new life to the wasteland.  The Sprite can summon the powers of earth, water, and wind.

### Main Objective
Explore the world and it’s mysteries. Solve puzzles along the way to unlock new areas and abilities.

Primary puzzles involve finding  and planting Golden and Silver seeds.  Secondary puzzles involve growing plants from heavy or floating seeds which spawn trees and vines respectively, and moving platforms with the Earth ability.   

### Length of Game
Around 2-5 minutes per puzzle.

### Comparison 
-Narrative flow similar to Journey
-Puzzle design similar to Monument Valley
-Level layout similar to Metroid

### What is unique? 
* The game combines 2D level exploration from Metroidvania type games and focuses the gameplay on the puzzle aspect. 
* The player is given a set of elemental abilities that can be used to solve puzzles in a variety of ways.
* The game emphasizes exploration rather than survival, so the player does not have to worry about falling off of cliffs or running into enemies.
* The world changes and becomes more beautiful as you play it.

### Why create this game?
* Exploring is naturally enjoyable to many people.
* The game is a fun and relaxing escape from the stresses of life
* It’s satisfying to watch the environment change as you interact with it
* Multiple puzzles with a variety of solutions will hopefully induce flow for the player.
* It encourages the player to care for the environment 

---

## AUDIENCE, PLATFORM, AND MARKETING
### Target Audience
* Fans of:
  * Exploration
  * Puzzles
  * Non-competitive/non-violent
* People who appreciate games as art
* People of any experience level with video games

### Top Performers in Similar Genres
* Metroid
* Ori and the Blind Forest
* Megaman
* Journey
* Monument Valley
* Yoshi's Story

###Feature comparison
* Navigation as a problem solving challenge
* Focus on quiet/subtle narration
* Minimal GUI elements

---

## FEATURE SET
### Player Movement
* Traditional 2D platformer style
* Snappy horizontal movement
* Jumping based on current horizontal speed
* No Air control
* Climbing

### Player Abilities
Air Power
* Creates a rectangular wind tunnel originating on player and extending out some distance
* Lasts until the player clicks again
* Applies constant force to objects inside

Earth Power
* Triggers “Earth Switches” which are located in specific parts of the map
* When enabled the Switches cause linked Earth Platforms to toggle to between two positions

Water Power
* Creates a radial collider that quickly grows out from the player’s position
* Collider is on the “Water” Physical Layer and triggers scripts that look for it
* Main purpose is to cause planted seeds to grow

### Common Seed Interactions
* Push/PUll seeds
* Blow seeds with wind
* Can be planted at “Planting Spots” if Plant Type matches the planting spot’s type
* Removed from play when planted

### Seed Types
* Big Seeds
  * Heavy and produce a large impact on collision
  * Pushed but not lifted by wind. 
  * Cannot be carried
  * Roll
  * Can be pushed by player on flat surfaces but not uphill

Floating seeds
* Light and easily carried by wind
* Fall slowly and have high horizontal drag

### Common Plant Interactions
* Grown from “Planting Spots” with seeds after colliding with water
* Do not interact with physics by default

### Plant Types
Trees
* Grow up from Planting Spot
* Climbable
* Grow from large seeds
* need water power to grow

Vines
* Grow down from Planting Spot
* Climbable
* Grown from normal floaty seeds

Golden Plants
* Pushed to the main hub from the regions for planting.
* Grown from a golden version of some seed type

Silver Plants
* Revive the region your currently in
* Grown from a silver version of some seed type

Planting Spots
* Have a specific “PlantType” that they can receive
* Unique Texture to communicate type

Revival
* As player progresses, life returns to the Game World

---

## THE GAME WORLD
### Overview
2D side scrolling world composed of ruined environments both natural and artificial.

### Key locations
Dead forest, ruined town/city, Maybe ancient ruins?, Mountains

### Travel 
Walking, jumping, abilities

### Scale
Series of mid-sized game-spaces (more than just one full screen space but small enough that traversal is quick)

---

## LEVEL DESIGN
### Overview
A level contains a series of 1 or more puzzles in which the player navigates and manipulates objects in the environment in order to get a “Golden Seed” to grow.

### Objective
Grow all of the Silver Seeds in the level then proceed to exit while taking the golden seed with you. Which is then used to bring about the full growth of the level.

### Puzzle Element
Obstacles will be in place in the player’s path to reach the silver/ golden seeds. Player must use their abilities in combination with secondary seed and plant types to achieve the objective.

### Obstacles
Obstacles include, but are not limited to:
* Non-linear pathways
* Pathways beyond the reach of normal movement mechanics, requiring use of abilities and secondary plants
* Needed seeds out of reach

---

## CAMERA
### Overview
Locked to hero to scroll as player moves. When moving, camera offsets from player position in the direction player is moving.

### Camera System
A mesh-less quad given the name CameraBounds (Prefab) is placed and sized in the scene. The Camera follows the player with some given offset, but is clamped to the inside of this Quad.

---

## GAME CHARACTERS
### Overview
Wooden sprite man with ability to control elements. The game does not currently contain other traditional characters.

---

## USER INTERFACE
### Overview
* Minimal
* As little non-gameworld elements as possible
* Simple control scheme.

### Player Control
* Dedicated button to use Earth Ability
* Dedicated button for Wind Ability, aimed with Mouse
* Dedicated button for Water Ability
* Dedicated button to grab seeds and pull them
* WASD to Move/Climb
* Spacebar to Jump

### In Game Command Prompts
Upon first time player needs to use a button, a simple floating graphic of the button appears in the Game World. If it requires interaction with another Game Object, the prompt will appear near that object.

---

## MUSIC & SOUND EFFECTS
### Overview
Sound design will be airy and clean like wind chimes but with mostly string instruments.

### Details
We would like to do our own Sound Recording of guitar, bass and cello playing. However, if that doesn’t work out we will use publicly available classical works from the internet.

Sound effects will be musical in nature so they blend in with the background tracks, where reasonable.

---

## ART
### Art Style
Painted look with some abstract geometric elements. Thematically inspired by Northern European folklore.

### Particle Effects
* Player abilities
  * Wind Ability: Swoopy white particles that travel along the path
  * Water Ability: Splash effect originating from player

