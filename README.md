# Fabacademy Interface
 
## Geiger Counter with Processing
This is a very basic plotter of the clicks from the Geiger counter summed over 20 seconds. In order to use it, you just need to download Processing and run the script (after adapting the port)

## Geiger Counter with Python and Matplotlib
This is also a simple plotter of the clicks. To use this script, you first need to download python (tested with 3.11) and the corresponding packages. You also need to adapt the port.

## Geiger Counter game with Unity
This is only the script for reading from the serial connection. It was tested with the FPS Microgame from the unity tutorials (tested with unity 2019). To test it you need to:

- Edit > Project Settings > Player > Api Compatibility Level > .NET 4.x

- Add the SerialConnection script to a GameObject inside the Scene (for example the player)

- Add an enemy prefab and empty GameObjects for spawning locations to this script