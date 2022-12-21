import scipy
import numpy
import math
import matplotlib.pyplot as plt
from numpy.polynomial.polynomial import Polynomial


CalcRange = 9
x = numpy.array([ 1,    2,    3,     4,     5,     6,     7,     8 ])
y = numpy.array([ 1.14, 3.72, 9.41, 15.46, 25.65, 35.24, 49.83, 63.09 ])

#CalcRange = 4
#x = numpy.array([ 1,    1.2,  1.4,  1.6,  1.8,  2,    2.2,  2.4,  2.6,  2.8,  3,     3.2,   3.4,   3.6,   3.8,   4 ])
#y = numpy.array([ 1.14,  .99, 1.08, 1.56, 2.46, 3.72, 5.15, 6.55, 7.76, 8.69, 9.41, 10.06, 10.86, 11.97, 13.52, 15.46 ])

def round(number:float, decimals:int=1):
    if decimals == 0:
        return math.ceil(number)

    factor = 10 ** decimals
    return math.ceil(number * factor) / factor

tck = scipy.interpolate.splrep(x, y)
wolfram = 'https://www.wolframalpha.com/input?i=fit+';
xi = []
yi = []
xiReal = []
yiReal = []
yLag = []
for i in numpy.arange(1, CalcRange, .1):
    yiReal.append(math.pow(i, 2) + math.sin(3 * i))
    xi.append(i)
    yi.append(scipy.interpolate.splev(i, tck))
    wolfram += "%7B{}%2C{}%7D%2C".format(round(i),round(scipy.interpolate.splev(i, tck), 2))
    print(round(i), scipy.interpolate.splev(i, tck))

plt.figure('Existed')
plt.plot(x,y)
plt.plot(xi,yiReal) 
plt.figure('Calculated & Real')
plt.plot(xi,yi) 
plt.plot(xi,yiReal)
plt.show()

print(wolfram[0:len(wolfram) - 3])
#https://www.wolframalpha.com/input?i=interpolating+polynomial%7B%281%2C1.14%29%2C%282%2C3.72%29%2C%283%2C+9.41%29%2C%284%2C+14.46%29%2C%285%2C+25.65%29%2C%286%2C35.24%29%2C%287%2C49.83%29%2C%288%2C63.09%29%7D
#https://www.wolframalpha.com/input?i=fit+%7B1%2C1.14%7D%2C%7B2%2C3.72%7D%2C%7B3%2C9.41%7D%2C%7B4%2C15.46%7D%2C%7B5%2C25.65%7D%2C%7B6%2C35.24%7D%2C%7B7%2C49.83%7D%2C%7B8%2C63.09%7D