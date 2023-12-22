Created & imported into unity by FuntechGames

Modular Sci Fi Kit

Lighting:

It is important to set your lighting correctly to achieve good results as all textures a PBR textures. Follow the steps below to have the same setup as in my renders or demos. Please note, all objects must be marked as static to be baked correctly. Animated objects like the hangar doors can’t be marked as static and the use of  Light Probes is necessary to achieve good results. 

The best Color Space for realistic rendering is Linear. This can be selected using the ‘Color Space’ property from (Edit>Project Settings>Player).
Global Illumination must be turned on. You can do this by going to (Window > Lighting > Settings), Open Scene tab inside Lighting window and enable Realtime Global Illumination.
Use Post-Processing image effects. I’ve used the FREE Post Processing Stack from Unity Asset Store. Bloom is needed to create the glows around the lights.

Tip: Turn off Auto “Generate Light maps(Window > Lighting > Settings)”  while building your scene. This will save on processing.

Materials:

Materials contain 2048 x 2048 maps, including Albedo, Metallic, Normal and Emission. Please contact me if you require larger maps. The normals are baked from high poly meshes.f

Hangar Door:

The hangar door is setup to open and close with any game object with the tag “Player”. It must Have a rigidbody and a collider.

Elevator: The buttons on the elevator keypads are sprites wich can be turnrd off and on to simulate clicking. There are offline sprites supplied as well.

Lights:

Flashing - Good for warning systems, the light turns off and on at regular intervals by setting the flashing speeds in the inspector.

Flickering - Good for broken / faulty lights, light turns off and on at random intervals.

Snap Settings:

This is a modular level design kit so set all axes to 1 in the snap settings. Drag a prefab into the scene  click on “Snap All axes” and you are good to go.

A demo scene is provided. 

You do not have the right to sell or distribute the models, contents or package separate of your final Unity game or Unity application.

Contact me if @ funtechgames@gmail.com you have questions. 
