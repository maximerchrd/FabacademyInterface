using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO; // Requires .NET 4 in Project Settings
using System.Text;
using System.Globalization;

public class SerialConnection : MonoBehaviour
{
    [SerializeField]
    private GameObject ennemyPrefab;
    [SerializeField]
    private GameObject[] spawnPoints;
    private int spawnIndex = 0;
    private SerialPort _serial;
    private string inputString = "";
    

    // Start is called before the first frame update
    void Start()
    {
        //Serial initialization
        string the_com = "";

        /*foreach (string mysps in SerialPort.GetPortNames())
        {
            print(mysps);
            if (mysps != "COM1") { the_com = mysps; break; }
        }*/

        the_com = "/dev/cu.usbserial-A104OWBD";
        //sp = new SerialPort("\\\\.\\" + the_com, 9600);
        _serial = new SerialPort(the_com, 9600);
        if (!_serial.IsOpen)
        {
            print("Opening " + the_com + ", baud 9600");
            _serial.ReadTimeout = 500;
            _serial.Handshake = Handshake.None;
            _serial.Open();
            if (_serial.IsOpen) { print("Open"); }
        }
    }

    // For simplicity we are reading data in our Update loop of our script.
    //However, if you have a lot of data to read, it would be recommended to create a separate
    //thread and reading the data from that instead of the main UI thread.
    void Update()
    {
        // Make sure we have a serial port and that the connection is open
        if (_serial != null && _serial.IsOpen)
        {
            // Check to see if there are any bytes available to read
            int bytesToRead = _serial.BytesToRead;
            if (bytesToRead > 0)
            {
                Debug.Log($"Bytes to read: {bytesToRead}");

                // Create our buffer to store the data
                byte[] buff = new byte[bytesToRead];

                // Read the available data into our buffer
                int read = _serial.Read(buff, 0, bytesToRead);

                // Check if we were able to read anything
                if (read > 0)
                {
                    var str = System.Text.Encoding.Default.GetString(buff);
                    inputString += str;
                    Debug.Log(inputString);
                    if (inputString.Contains("010"))
                    {
                        inputString = "";
                        Instantiate(ennemyPrefab, spawnPoints[spawnIndex].transform.position, Quaternion.identity);
                        spawnIndex = (spawnIndex + 1) % 4;
                    }
                }
                else
                {
                    Debug.Log("Didn't read anything.");
                }
            }
        }
    }
}
