# Fabacademy Interface
 
In order to use the Geiger Counter, you first need to install the [FTDI driver](https://ftdichip.com/drivers/vcp-drivers/)
 
## Geiger Counter with Processing
This is a very basic plotter of the clicks from the Geiger counter summed over 20 seconds. In order to use it, you just need to download Processing and run the script (after adapting the port)

## Geiger Counter with Python and Matplotlib
This is also a simple plotter of the clicks. To use this script, you first need to download python (tested with 3.11) and the corresponding packages. You also need to adapt the port.

- First install the latest Python
- pip install matplotlib
- pip install pyserial
- python PythonGeigerCounter.py
- Change the port name. For windows, if the port name is "COM14", write "\\\\\\\\.\\\\COM14".

## Geiger Counter game with Unity
This is only the script for reading from the serial connection. It was tested with the FPS Microgame from the unity tutorials (tested with unity 2019). This microgame is only available until Unity 2021. To test it you need to:

- Edit > Project Settings > Player > Api Compatibility Level > .NET 4.x

- Add the SerialConnection script to a GameObject inside the Scene (for example the player)

- Add an enemy prefab and empty GameObjects for spawning locations to this script