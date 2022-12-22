import numpy as np
import matplotlib.pyplot as plt

def f(t):
    return np.sin(t)

def fs(t):
    return -np.cos(t) - 1

def Euler(n):
    a = -np.pi
    b = np.pi

    h = np.pi / (n / 2)

    x = np.arange(a, b, h)
    y = fs(x)
    plt.plot(x, y, label='Real value')

    t = np.empty(n)
    v = np.empty(n)

    t[0] = a
    v[0] = 0

    for i in range(1, n):
        t[i] = a + i * h
        v[i] = v[i - 1] + h * f(t[i - 1])

    print(t)
    print(v)

    if n == 100:
        plt.plot(t, v, label='Euler')
    else:
        plt.plot(t, v, marker='o', label='Euler')
    plt.legend()
    plt.show()

def RungeKnutt(n):
    v1 = np.empty(n)
    v2 = np.empty(n)
    v3 = np.empty(n)
    v4 = np.empty(n)

    t = np.empty(n)
    v = np.empty(n)

    a = -np.pi
    b = np.pi
    h = np.pi / (n / 2)

    x = np.arange(a, b, h)
    y = fs(x)
    plt.plot(x, y, label='Real value')

    t[0] = a
    v[0] = 0

    for i in range(1, n):
        t[i] = a + i * h
        v1[i] = h * f(t[i - 1])
        v2[i] = h * f(t[i - 1] + h / 2) 
        v3[i] = h * f(t[i - 1] + h / 2) 
        v4[i] = h * f(t[i - 1] + h) 
        v[i] = v[i - 1] + (v1[i] + 2 * v2[i] + 2 * v3[i] + v4[i]) / 6

    print(t)
    print(v)
    if (n == 100):
        plt.plot(t,v, label='Runge Knutt')
    else:
        plt.plot(t,v, marker='o', label='Runge Knutt')
    plt.legend()
    plt.show()

#Euler(100)
RungeKnutt(10)
RungeKnutt(20)
RungeKnutt(100)


#https://www.wolframalpha.com/input?i=solve+%7Bv%27%3Dsin%28t%29%2C+v%28-%CF%80%29%3D0%7D+fourth%E2%80%90order+Runge%E2%80%90Kutta+method+t%3D-%CF%80..%CF%80
#https://www.wolframalpha.com/input?i=solve+%7Bv%27%3Dsin%28t%29%2C+v%28-%CF%80%29%3D0%7D+Euler+method+t%3D-%CF%80..%CF%80