import os

def search(folder,node):
    next_node = folder + "/" + node
    filenames = os.listdir(next_node)
    for filename in filenames:
        full_filename = os.path.join(filename)
        dec = next_node + "/" + full_filename
        if os.path.isdir(dec):
            search(next_node,full_filename)
        else:
            print(full_filename)

search("C:\Download","")

