
def generate_string():
    string = "S"
    choice = input("На что заменить S? 1 - cAcA | 2 - dAdA: ")
    if choice == "1":
        string = string.replace("S", "cAcA", 1)
        print("===> ", string)
    elif choice == "2":
        string = string.replace("S","dAdA", 1)
        print("===> ", string)
    else:
        print("Неправильный ввод")

    while "A" in string:
        choice = input("Выберите на что заменить A? 1 - cA | 2 - dA | 3- E: ")
        if choice == '1':
            string = string.replace("A", "cA")
        elif choice == '2':
            string = string.replace("A", "dA")
        elif choice == '3':
            string = string.replace("A", "")
        else:
            print("Неправильный ввод")
        print("===> ", string)
    return string

print(generate_string())