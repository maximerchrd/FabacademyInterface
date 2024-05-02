import processing.serial.*;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Iterator;


  Serial myPort;        // The serial port
  int xPos = 1;         // horizontal position of the graph
  int timeWindow = 20000;  //measurement window in milliseconds
  float inByte = 0;
  Queue<Integer> clicksQueue;

  void setup () {
    // set the window size:
    size(1100, 700);
    
    clicksQueue = new LinkedList<Integer>();

    // List all the available serial ports
    // if using Processing 2.1 or later, use Serial.printArray()
    println(Serial.list());
    
    //change the number in the list to correspond to your device
    println(Serial.list()[3]);

    // Open whatever port is the one you're using.
    myPort = new Serial(this, Serial.list()[3], 9600);

    // don't generate a serialEvent() unless you get a newline character:
    //myPort.bufferUntil('\n');

    // set initial background:
    background(0);
  }

  void draw () {
    //calculate the next value
    Integer present = millis();
    Integer counter = 0;
    Iterator<Integer> iterator = clicksQueue.iterator();
    while (iterator.hasNext()) {
      Integer item = iterator.next();
      if (item < present - timeWindow) {
        iterator.remove();
      } else {
        counter++;
      }
    }
    
    // draw the line:
    stroke(127, 34, 255);
    line(xPos/3, height, xPos/3, height - (counter * 10));
    // at the edge of the screen, go back to the beginning:
    if (xPos/3 >= width) {
      xPos = 0;
      background(0);
    } else {
      // increment the horizontal position:
      xPos++;
    }
  }

  void serialEvent (Serial myPort) {
    if (myPort.available() > 0) {
      // get the ASCII string:
      char inChar = myPort.readChar();
      if (inChar == '0' || inChar == '1') {
        println(inChar);
        clicksQueue.add(millis());
      }
    }
  }
