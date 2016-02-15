# Tower-Defence
This is a tower defence game using C# language.
 This game is based on the Unity3d 4.6 version.
 Download the game and run it in the Unity3d.

 Currently, there are five types of towers in the game.
 1. basic tower: can attack one enemy
 2. shotgun tower: can attack at least on enemy in the attack range, the maximum number is four enemies
 3. slow tower: the enemies in the range will move slower than the others
 4. missile tower: the tower can shot a missile and cause an explosion, the enemies in the explosion area will be attacked
 5. laser tower: the tower will cause high damage
 
 There are mines(for resources), generators(for energy) and reasearch labs(for research points).
 There is also a technology tree in the game, the more unlocked node in the tree, the more technology you will have.

  On Feb 8th.
 Have implemented the small mine, large mine to get diamonds.
 Have implemented the small geneator, large geneator to get power.
 Small mine: slow resource acquisition
 Large mine: fast resource acquisition
 
 Small generator: generates a little bit of power
 Large generator: generates a lot of power


 On Feb 9th.
 Have implemented the targeting facility to increase the damage of nearby towers
 Have implemented the reasearch lab to get research points to unlock the tech tree
 Have implemented the supercapacitor to increase the rate of the fire of nearby towers
 Have implemented the alien recovery to get diamonds when killing enemies in the range
 
 On Feb 10th.
 Have implemented the extra damage tech
 Have implemented the stasis field does damage tech
 Have implemented the increase power produce from the generators
 
 On Feb 14th.
 Have implemented the Research acceleration
 Have implemented the lasts posion to the shoting
 Have implemented the extra slow effect on all enemies
 Have added 30 types of enemies in the game
 Have implemented the description of the tech node(if put mouse on the tech node, it will show the description of the node)
 Have implemented the relation of the tower selection panel to the tech node(the tower is locked unless you click that tech node)
 
 Need to be done:
 add power provider techology(the tower will only able to attck when the other tower providing power to it)
 change the attack effect of the laser tower
 implement the armor
 implement the number related to the wave
 implement the number related to the life
 
Undo parts: 
// Targeting facility: increases the damage of nearby towers
// Research labs: generates research point over time
// Supercapcitor: increases the rate of fire of nearby towers
 Antenna: supplies power to nearby towers
// Alien recovery: generate resources from aliens killed nearby
 
// Extra damage
 Overcharge: towers can be set to consume more power, deal more damage
// Stasis field does damage
 Increased antenna range
 Increased antenna power delivery
// Increased power production from generators 
// Research acceleration:can spend resources to get research points
// Napalm: add DOT to shots
 Increased armor piercing
 
 Extra slow effect when enemies reach base
// Extra slow effect on all enemies
 Recover life when no enemies reached there in a while
 
 
