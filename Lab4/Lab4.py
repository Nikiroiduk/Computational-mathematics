import scipy.integrate as spi
import autograd.numpy as anp
import numpy as np
import matplotlib.pyplot as plt
import scipy.interpolate as spinter
from scipy.interpolate import make_interp_spline

integrand = lambda x : np.exp(x) + anp.sin(x * 15)
#integrand = lambda x : np.exp(x) + anp.sin(x)

a = .5
b = .8

plt.figure('All')
step = .3 / 2

xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys, label='step = {}'.format(step))

result = spi.simpson(ys, xs)
print('Result is', result, 'step = {}'.format(step))

step = .3 / 4

xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys, label='step = {}'.format(step))

result = spi.simpson(ys, xs)
print('Result is', result, 'step = {}'.format(step))

step = .3 / 8

xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys, label='step = {}'.format(step))

result = spi.simpson(ys, xs)
print('Result is', result, 'step = {}'.format(step))

step = .3 / 16

xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys, label='step = {}'.format(step))

result = spi.simpson(ys, xs)
print('Result is', result, 'step = {}'.format(step))

step = .3 / 32

xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys, label='step = {}'.format(step))

result = spi.simpson(ys, xs)
print('Result is', result, 'step = {}'.format(step))

step = .3 / 64

xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys, label='step = {}'.format(step))

result = spi.simpson(ys, xs)
print('Result is', result, 'step = {}'.format(step))

step = .3 / 128

xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys, label='step = {}'.format(step))

result = spi.simpson(ys, xs)
print('Result is', result, 'step = {}'.format(step))

plt.legend()

plt.figure('Accuracy by divisions')

x = [2, 4, 8, 16, 32, 64, 128]
y = [1, 3, 4, 5, 6, 8, 9]

X_Y_Spline = spinter.PchipInterpolator(x, y)
X_ = np.arange(2, 128, .1)
Y_ = X_Y_Spline(X_)
plt.plot(X_, Y_)
plt.xlabel('divisions')
plt.ylabel('accuracy (digits after .)')

plt.figure('n = 8')
step = .3 / 8
xs = np.arange(a, b, step)
ys = integrand(xs)
x = xs
y = ys
X_Y_Spline = make_interp_spline(x, y, 2)
X_ = np.arange(.5, .8, step / 1000)
Y_ = X_Y_Spline(X_)
plt.plot(X_, Y_)
plt.fill_between(X_, Y_, alpha=.4)

step = .0001
xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys)

step = .3 / 8
xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys, 'o', color='black')

plt.figure('n = 4')
step = .3 / 4
xs = np.arange(a, b, step)
ys = integrand(xs)
x = xs
y = ys
X_Y_Spline = make_interp_spline(x, y, 2)
X_ = np.arange(.5, .8, step / 1000)
Y_ = X_Y_Spline(X_)
plt.plot(X_, Y_)
plt.fill_between(X_, Y_, alpha=.4)

step = .0001
xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys)

step = .3 / 4
xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys, 'o', color='black')



plt.figure('n = 2')
step = .3 / 2
xs = np.arange(a, b, step)
ys = integrand(xs)
x = xs
y = ys
X_Y_Spline = make_interp_spline(x, y, 2)
X_ = np.arange(.5, .8, step / 1000)
Y_ = X_Y_Spline(X_)
plt.plot(X_, Y_)
plt.fill_between(X_, Y_, alpha=.4)

step = .0001
xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys)

step = .3 / 2
xs = np.arange(a, b, step)
ys = integrand(xs)
plt.plot(xs, ys, 'o', color='black')
plt.show()

#https://www.wolframalpha.com/input?i=integrate+simpson+e%5Ex+%2B+sin%28x+*+15%29%2C+x%3D0.5..0.8