import numpy as np
import matplotlib.pyplot as plt

def f(t):
    return np.sin(t)

def fs(t):
    return -np.cos(t) - 1

def Euler(n):
    a = -np.pi
    b = np.pi

    h = np.pi / ((n-1) / 2)

    fig, ax = plt.subplots(2, sharex='col', sharey='row')
    fig.canvas.manager.set_window_title('Euler')
    x = np.arange(a, b + h, h)
    y = fs(x)
    ax[0].plot(x, y, label='Real value')

    t = np.empty(n)
    v = np.empty(n)

    t[0] = a
    v[0] = 0

    for i in range(1, n):
        t[i] = a + i * h
        v[i] = v[i - 1] + h * f(t[i - 1])

    print(t)
    print(v)

    if (n >= 50):
        ax[0].plot(t, v, label='Euler')
    else:
        ax[0].plot(t, v, marker='o', label='Euler')
    ax[0].set(title=f'Euler    N = {n}')

    e = []
    for i in range(0, n):
        e.append(v[i] - y[i])
    print('L error',e)
    maxE = max(np.abs(e))
    print('L error max:', maxE)

    #global error, pbly don't work
    #
    #g = []
    #for i in range(1, n + 1):
    #    g.append(e[i - 1] / np.exp(1)**(h * i))
    #print('G error', g)
    #ax[2].plot(t, g, label='Global error', alpha=1)
    #ax[2].set(title = f'Global error')
    #ax[2].legend()

    ax[1].plot(t, e, label=f'Local error', alpha=1)
    ax[1].set(title = f'Local error (max = {maxE:e})')
    ax[0].legend()
    ax[1].legend()
    return maxE


def RungeKutta(n):
    v1 = np.empty(n)
    v2 = np.empty(n)
    v3 = np.empty(n)
    v4 = np.empty(n)

    t = np.empty(n)
    v = np.empty(n)

    a = -np.pi
    b = np.pi
    h = np.pi / ((n-1) / 2)

    fig, ax = plt.subplots(2, sharex='col', sharey='row')
    fig.canvas.manager.set_window_title('Runge-Kutta 4th')
    x = np.arange(a, b + h, h)
    y = fs(x)
    ax[0].plot(x, y, label='Real value')

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
    if (n >= 50):
        ax[0].plot(t,v, label='Runge-Kutta 4th')
    else:
        ax[0].plot(t,v, marker='o', label='Runge-Kutta 4th')

    e = []
    for i in range(0, n):
        e.append(v[i] - y[i])
    print('Lerror',e)
    maxE = max(np.abs(e))
    print('L error max:', maxE)

    #global error, pbly don't work
    #
    #g = []
    #g.append(0)
    #for i in range(1, n):
    #    g.append(h**4/24 * (e[i]))
    #print('G error', g)
    #ax[2].plot(t, g, label='Global error', alpha=1)
    #ax[2].set(title = f'Global error')
    #ax[2].legend()

    ax[1].plot(t, e, label='Local error', alpha=1)
    ax[1].set(title = f'Local error (max = {maxE:e})')
    ax[0].set(title=f'Runge-Kutta 4th    N = {n}')
    ax[0].legend()
    ax[1].legend()
    return maxE

#accuracy to no. of steps 
#!comment plt in methods before use
#
#x = np.arange(10, 510, 10)
#y = []
#for i in x:
#    y.append(RungeKutta(i))

#plt.yscale('log')
#plt.xlabel('No. of steps')
#plt.ylabel('Max error')
#plt.plot(x, y)
#plt.show()


#real graph
#
#plt.plot(np.arange(-np.pi, np.pi + np.pi / 1000, .0001), fs(np.arange(-np.pi, np.pi + np.pi / 1000, .0001)))
#plt.show()


Euler(10)
RungeKutta(10)
plt.show()
Euler(50)
RungeKutta(50)
plt.show()
Euler(500)
RungeKutta(500)
plt.show()

#https://www.wolframalpha.com/input?i=solve+%7Bv%27%3Dsin%28t%29%2C+v%28-%CF%80%29%3D0%7D+fourth+order+Runge+Kutta+method+t%3D-%CF%80..%CF%80
#https://www.wolframalpha.com/input?i=solve+%7Bv%27%3Dsin%28t%29%2C+v%28-%CF%80%29%3D0%7D+Euler+method+t%3D-%CF%80..%CF%80