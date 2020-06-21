from tkinter import *
window=Tk()

def process():
	ctemp = e1.get()
	ctemp = ctemp[::-1]
	e2.delete(0,END)
	e2.insert(0, ctemp)

	

l1 = Label(window, text="input")
l2 = Label(window, text="output")
l1.grid(row=0, column=0)
l2.grid(row=1, column=0)

e1=Entry(window)
e2=Entry(window)
e1.grid(row=0, column=1)
e2.grid(row=1, column=1)


b1= Button(window, text="O->R", command=process)
b2 = Button(window, text="R->O")
b1.grid(row=2, column=0)
b2.grid(row=2, column=1)

window.mainloop()
