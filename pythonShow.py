import matplotlib.pyplot as plt
import sys
import numpy as np

import signal
signal.signal(signal.SIGINT, signal.SIG_DFL)

img = []
with open("out", "r") as f:
    line = f.readline()
    while line:
        l = []
        print(line)
        for i in line:
            if i != "\n" and i != " ":
                l.append(5-int(i))
        line = f.readline()
        img.append(l)
c = plt.imshow(img, cmap=plt.cm.gray)
plt.show()
