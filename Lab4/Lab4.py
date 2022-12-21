import scipy.integrate as spi
import autograd.numpy as anp
import numpy as np
import matplotlib.pyplot as plt

integrand = lambda x : np.exp(x) + anp.sin(x * 15)
#integrand = lambda x : np.exp(x) + anp.sin(x)

a = .5
b = .8

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

plt.legend()
plt.show()

#https://www.wolframalpha.com/input?i=integrate+e%5Ex+%2B+sin%28x+*+15%29%2C+x%3D0.5..0.8