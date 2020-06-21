import numpy as np
from scipy import stats, polyval
from pylab import plot, title, show, legend


data_temp = np.loadtxt("temp.dat", delimiter= "::", dtype=np.float)
data_cmort = np.loadtxt("cmort.dat", delimiter= "::", dtype=np.float)

mean_cmort = data_temp[::].mean()
var_cmort = data_temp[:].var()
print('mean:',mean_cmort,'variance:',var_cmort)
# 1) Find the mean and variance of Y
#
x = data_temp
y= data_cmort

slope, intercept, r, p, std = stats.linregress(x,y)
ry = polyval([slope, intercept], x)

print(slope, intercept, r, p, std)
print(ry)
plot(x,y, 'k.')
plot(x,ry, 'r.-')
title('regression')

legend(['original', 'regression'])

show()
# # find the linear regression