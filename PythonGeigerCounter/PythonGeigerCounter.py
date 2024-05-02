from collections import deque
import time
from time import sleep
import serial
import matplotlib.pyplot as plt
import numpy as np
import array

#define serial port
ser = serial.Serial('/dev/cu.usbserial-A104OWBD', 9600)  # replace with your port


counterData = deque()   #stores the y data (nb of clicks per "timeWindow" seconds)
timeData = deque()      #stores the x data (time)

timeWindow = 20  # in seconds
clicksQueue = deque()   #stores the clicks timestamps


#setup plot
plt.ion()
fig = plt.figure()
ax = fig.add_subplot(111)
line1, = ax.plot(counterData, timeData, 'b-')

startingTime = time.time()



while True:
    #read serial port
    if ser.in_waiting > 0:
        # read one byte
        byte = ser.read(1)
        # decode byte to string
        inChar = byte.decode('utf-8')
        # check if the character is '0' or '1'
        if inChar == '0' or inChar == '1':
            print(inChar)
            clicksQueue.append(time.time())


    #add data at the end of the array
    present = time.time()
    while clicksQueue and clicksQueue[0] < present - timeWindow:
        clicksQueue.popleft()


    timeData.append(time.time() - startingTime)
    counterData.append(len(clicksQueue))


    if time.time() - startingTime > 30:
        timeData.popleft()
        counterData.popleft()

    #update plot
    line1.set_ydata(counterData)
    line1.set_xdata(timeData)
    ax.relim()
    ax.set_ylim(bottom=0, top=(max(counterData)+1))
    ax.autoscale_view()

    fig.canvas.draw()
    fig.canvas.flush_events()

    #plot doesn't show if pause omitted
    plt.pause(0.2)

    if not plt.fignum_exists(fig.number):
        break
