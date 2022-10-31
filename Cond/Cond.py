import numpy as np
import math

def createGilberMatrix(n):
    matrix=[[0 for i in range(n)] for j in range(n)]
    for i in range(n):
        for j in range(n):
            matrix[i][j] = math.pow((i+j+1),-1)
    return matrix


print(np.linalg.cond(createGilberMatrix(5)))
#a = [[ 1,  2,  3,  1, -3 ], 
#     [ 4,  3,  4, -2,  7 ], 
#     [ 3,  5,  1,  3,  2 ], 
#     [ 1,  4, -3,  3,  6 ], 
#     [ 3,  5,  1, -4,  2 ]]
#print(np.linalg.cond(a))