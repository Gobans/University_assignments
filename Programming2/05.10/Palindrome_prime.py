def is_prime():
    n = 2
    prime = 1
    k=2
    k_num = 0
    while(True):
        prime_flag = True
        if n % 2 is 0:
            prime_flag = False
        if prime_flag:
            l = round(n ** 0.5) + 1
            for i in range(3,l,2):
                if n%i == 0:
                    prime_flag = False
                    break
            if prime_flag:
                if prime == 100:
                    print('100th', n)
                prime+=1
        if 2**k -1 == n:
            if prime_flag:
                k+=1
                k_num +=1
            else:
                k+=1
        if k_num==7:
            print('k7 is',n)
            break
        n+=1

is_prime()
