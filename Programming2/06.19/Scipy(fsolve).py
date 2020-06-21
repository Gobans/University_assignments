from scipy.optimize import fsolve
import math

def equations(x):
    return (x**2 - math.exp(math.cos(x)))
print(fsolve(equations,1))
