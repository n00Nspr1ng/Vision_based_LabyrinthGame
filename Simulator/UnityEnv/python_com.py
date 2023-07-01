import socket
from time import time

host, port = "127.0.0.1", 25001
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((host, port))
cnt = 0
countScale = 100
startPos = [0, 0, 0] #Vector3   x = 0, y = 0, z = 0
#test = 0
avgtime = 0
while True:
    start = time()
    #time.sleep(0.1) #sleep 0.5 sec
    if cnt % (40*countScale) < (10*countScale):
        startPos[0] -=0.1 #decrease x by one
    elif cnt % (40*countScale) < (20*countScale):
        # notice that - is increase in z
        startPos[2] -=0.1 #increase z by one 
    elif cnt % (40*countScale) < (30*countScale):
        startPos[0] +=0.1 #increase x by one
    else:
        startPos[2] +=0.1 #decrease z by one    
            
    # startPos[0] -=0.1 #increase x by one
    # startPos[2] +=0.1 #increase x by one
    cntString = 'c' + str(cnt)
    posString = ','.join(map(str, startPos)) #Converting Vector3 to a string, example "0,0,0"
    #print(posString+cntString)
    print(cntString)
    posString = posString + cntString
    sock.sendall(posString.encode("UTF-8")) #Converting string to Byte, and sending it to C#
    # cntString = 'c' + str(cnt)
    #print(cntString)
    #sock.sendall(cntString.encode("UTF-8"))
    receivedData = sock.recv(1024).decode("UTF-8") #receiveing data in Byte fron C#, and converting it to String
    print("received c" + receivedData)

    cnt = cnt + 1
    # refresh the position
    startPos = [0, 0, 0]
    end = time()
    #print('time elapsed:', end - start, ' for iteration')

    #print('test : ', test)
    avgtime = avgtime*(cnt-1) + (end - start)
    avgtime = avgtime / (cnt)
    print('average time per iteration : ', avgtime)