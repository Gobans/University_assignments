import numpy as np

data_soi = np.loadtxt("soi.dat", delimiter= "::", dtype=np.float)
data_recruit = np.loadtxt("recruit.dat", delimiter= "::", dtype=np.float)
# 1) read 2 files

mean_soi = data_soi[::].mean()
var_soi = data_soi[:].var()
mean_recruit = data_recruit[::].mean()
var_recruit = data_recruit[::].var()
# 2) compute mean and variance of each data

x_train = np.array(data_soi)
y_train = b = np.array(data_recruit)
correlation =np.corrcoef(x_train,y_train)

print(x_train)
print(y_train)
# 3) compute the correlation between 2 data
#
# W = 0.0
# b = 0.0
#
# n_data = len(x_train)
#
# epochs = 5000
# learning_rate = 0.01
#
# for i in range(epochs):
#     hypothesis = x_train * W + b
#     cost = np.sum((hypothesis - y_train) ** 2) / n_data
#     gradient_w = np.sum((W * x_train - y_train + b) * 2 * x_train) / n_data
#     gradient_b = np.sum((W * x_train - y_train + b) * 2) / n_data
#
#     W -= learning_rate * gradient_w
#     b -= learning_rate * gradient_b
#
#     if i % 100 == 0:
#         print('Epoch ({:10d}/{:10d}) cost: {:10f}, W: {:10f}, b:{:10f}'.format(i, epochs, cost, W, b))
#
# print('W: {:10f}'.format(W))
# print('b: {:10f}'.format(b))
# print('result : ')
# print(x_train * W + b)

# 4) Let X be the soi data and Y the recruit.data. Using numpy or any other tool,
# find the linear regression