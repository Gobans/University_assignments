import pandas as pd
dataset = pd.read_csv("genetic_code.tsv",delimiter ='\t')
k,v = dataset[["UUU","F"]]
dict = {"UUU": "F"}
for i,j in zip(dataset[k],dataset[v]):
    dict[i] = j
with open("NC_sample.txt") as f:
    lines = f.readlines()
    string = ''.join([line.rstrip() for line in lines[1:]])

index = 0
linespace = 0
while(True):
    str = string[index:index+3]
    print(dict[str],end='')
    index += 3
    linespace += 1
    if linespace == 3:
        linespace =0
        print("\n",end='')
    if index == len(string):
        break