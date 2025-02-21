Context
You are aboard a spaceship traveling through space when it gets struck by a meteor shower. It is your daily routine to clean some meteors.

How to Play Our Game
You will need to grab the bullet on the desk beside you (which will provide ammunition and do our daily cleaning routine) and shoot as many meteors (that are flying around) as possible

To grab the bullet: Press the grip button on the left controller. (Each bullet grabbed will provide 1,000 actual shooting bullets, which will be displayed on the UI.).
To fire the bullet: Press the trigger button of the right controller. (Make sure to press all the way in, otherwise it will not be detected).
To teleport: Press the grip button on the right controller.

When a meteor is hit by a bullet: If you shoot a meteor, it will break into pieces, and the total meteor shot count score will be displayed on the UI.

Game Logic / Mechanisms
1. Teleportation Mechanism
For teleporting, it is implemented through the "Teleport Area" in the hierarchy. The Box Collider objects of the floor are specified here, and users are only able to teleport to those specific locations, and not to invalid locations (e.g. outside the spaceship)

2. Shooting Mechanism
The main shooting logic is implemented through GunController.cs (manually coded), which is attached to the XR Origin (XR Rig). An empty game object called "fire_point" is also attached to the Sci Fi Pistol under the Right Controller, which serves as the point of instantiation of the bullet when the user fires the gun (presses the trigger button).

3. Grab Mechanism
The grab system is implemented through the Grab.cs script, allowing users to pick up and drop objects using a grab action. When the grab button is pressed, a SphereCast detects nearby objects within a defined grab radius, prioritizing the closest one. If an object is grabbed, it becomes a child of the controller, and its Rigidbody is set to kinematic to disable physics interactions. Haptic feedback is triggered upon grabbing, and an optional grab sound can be played. When the grab button is released, the object is detached, and its Rigidbody is re-enabled. If the grabbed object is a bullet, it is destroyed and restocked in the gun's inventory. Additionally, the object's velocity is adjusted based on the controller's movement for a more natural throwing effect.

Downloaded packages or objects used
1. Sci-Fi Styled Modular Pack https://assetstore.unity.com/packages/3d/environments/sci-fi/sci-fi-styled-modular-pack-82913
- Used Prefabs inside to build spaceship and the details
- Used Space Waste Prefab as the target in the game. This prefab does NOT come with the Breakable.cs script (which detects collisions and simulates the breaking animation), a Box Collider, or a Rigidbody component. All of these were manually coded and added by the team.

2. Lets Make a VR Game https://drive.google.com/file/d/1B5qxgxok_B-kHy8oZSXuYUtrMea-BA1t/view
- Used Prefabs inside for the oculus hand, the pistol, and the space waste

3. Weapons Pack - Bullets https://assetstore.unity.com/packages/3d/props/weapons/weapons-pack-bullets-302702
- Used a bullet prefab for the shooting (SM_Bullet_06.prefab). The prefab does NOT come with the script (Bullet.cs), Capsule Collider, and the attached Rigidbody component. All three were added manually by the team.
- A different bullet prefab (SM_Bullet_05.prefab) is used for ammunition filling (grabbing bullets). The grabbing mechanism was manually coded in the Grab.cs script, which was attached to the controller component.

Audio:
shoot: https://freesound.org/people/jalastram/sounds/362461/
grab: https://freesound.org/people/Christopherderp/sounds/333041/
rock: https://freesound.org/people/newlocknew/sounds/631485/s
