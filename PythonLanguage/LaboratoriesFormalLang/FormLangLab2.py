import itertools as iter
import string
from itertools import chain


massT = str(input("Множество терминалов: ")).split()
massN = str(input("Множество нетерминалов: ")).split()
S = str(input("Введите стартовый символ: "))
n = int(input("Количество правил: "))
print("Введите правила по типу: Aa = Rpppp\n"
      "Если из левой части есть несколько переходов, пропишите их через пробел слева\n"
      "В качестве пустой цепочки выступает точка (.)\n")


def check_KS():
    """
        Предлагает пользователю ввести последовательность строк, представляющих контекстно-свободную грамматику.
        Анализирует каждую введенную строку и сохраняет разобранное представление в списке списков под названием `rooles`.
        Проверяет, присутствуют ли все символы в первой строке каждого ввода в заранее определенном списке под названием `massN`.
        Если какие-либо символы отсутствуют, увеличивает счетчик под названием `count`.
        Если `count` равно нулю, устанавливает строку результата равной "Введена КС-грамматика" и устанавливает флаг в 1.
        В противном случае устанавливает строку результата равной "Введенная грамматика не является КС-грамматикой" и устанавливает флаг в 0.
        Возвращает кортеж, содержащий строку результата, флаг и список `rooles`.
        """
    count = 0
    rooles = []
    for i in range(n):
        roole_n = str(input()).split()
        a = roole_n[0]
        b = []
        raw_count = 0
        for j in roole_n:
            if j == '=':
                raw_count = 1
            elif raw_count > 0 and j != '=':
                b.append(j)
        rooles.append([a, b])
        list_a = list(a)
        if not all(x in massN for x in list_a):
            count += 1
    if count == 0:
        rez, c = 'Введена КС-грамматика', 1
    else:
        rez, c = "Введенная грамматика не является КС-грамматикой", 0
    return rez, c, rooles


def check_exist(lst, massN, S):
    """
    Проверяет, существует ли данная строка S в списке строк massN.

    Параметры:
        lst (list): Список кортежей, каждый из которых представляет язык. Каждый кортеж содержит два списка:
                    первый список представляет нетерминальные символы, второй список - терминальные символы.
        massN (list): Список строк, представляющих все возможные терминальные символы.
        S (str): Строка, представляющая язык для проверки существования.

    Возвращает:
        str: Строка, указывающая на существование или несуществование языка. Возвращает 'Язык не существует',
             если язык не существует, и 'Язык существует', если язык существует.
    """
    N0 = []
    for i in range(len(lst)):
        for j in chain(lst[i][1], lst[i][0]):
            [N0.append(x) for x in list(j) if x in massN and x not in N0]
    if S not in N0:
        return 'Язык не существует'
    else:
        return "Язык существует"


def del_useless_sym(massT, massN, lst):
    """
        Эта функция принимает три параметра: massT, massN и lst.
        Она удаляет ненужные символы из переданных списков и возвращает обновленные списки.
        Затем определяется вложенная функция cycle_el(), которая принимает список mass и итерируется по lst,
        чтобы найти элементы, имеющие подмножества massT и mass.
        Функция инициализирует массив mass значением '.' и вызывает cycle_el() для обновления массива mass.
        Затем вызывается cycle_el() еще раз для обновления Ni.
        Процесс продолжается до тех пор, пока N1 и Ni не будут равны.
        Затем функция создает новый список N, фильтруя элементы из massN, которые находятся в Ni.
        Если длина списка N не равна 0, функция создает новый список r и итерируется по lst, чтобы найти элементы,
        имеющие подмножества Ni, massT или '.'.
    """

    print('a) бесполезных символов')

    def cycle_el(mass):
        mass_el_mass = massT + mass
        for i in range(len(lst)):
            for x in lst[i][1]:
                if set(list(x)).issubset(mass_el_mass):
                    if lst[i][0] not in mass:
                        mass.append(lst[i][0])
        return mass

    mass = ['.']
    N1 = cycle_el(mass)
    Ni = cycle_el(N1.copy())
    while N1 != Ni:
        N1 = Ni
        Ni = cycle_el(N1.copy())
    N = [element for element in massN if element not in Ni]  # Бесполезные символы
    if len(N) != 0:
        r = []  # Будущие новые правила
        for i in range(len(lst)):
            r0 = []
            for j in lst[i][1]:
                v = []
                [v.append(x) for x in list(j) if x in Ni or x in massT or x == '.']
                if ''.join(v) == j:
                    r0.append(j)
            if len(r0) != 0:
                r.append([lst[i][0], r0])
    else:
        r = lst
    Ni.remove('.')
    return Ni, r


def no_way_sym(lst):
    """
       Находит недостижимые символы в заданном списке правил.

       Параметры:
       - lst (list): Список правил, где каждое правило представляет собой кортеж, содержащий символ и список символов.

       Возвращает:
       - T (list): Список символов, которые достижимы из начального символа.
       - Ni (list): Список символов, которые недостижимы.
       - r (list): Список правил, где каждое правило представляет собой кортеж, содержащий символ и список символов.

       Функция принимает список правил, где каждое правило представляет собой кортеж, содержащий символ и список символов.
       Она находит символы, не достижимые из начального символа, выполняя алгоритм обнаружения циклов. Затем определяет
       достижимые символы и возвращает их вместе с недостижимыми символами и правилами, содержащими недостижимые символы.

       Пример:
        lst = [('S', [('A', 'B'), ('C', 'D')]), ('A', [('A', 'A'), ('B', 'B')]), ('B', [('C', 'C'), ('D', 'D')]), ('C', [('A', 'A'), ('B', 'B')]), ('D', [('C', 'C'), ('D', 'D')])]
        no_way_sym(lst)
       (['A', 'C'], ['B', 'D'], [('A', [('A', 'A'), ('B', 'B')]), ('C', [('A', 'A'), ('B', 'B')])])
    """

    print('б) недостижимых символов')

    def cycle_el(mass):
        for i in range(len(lst)):
            if lst[i][0] in mass:
                [mass.append(x) for j in lst[i][1] for x in list(j) if x in massN and x not in mass]
        return mass

    mass = [lst[0][0]]
    N1 = cycle_el(mass)
    Ni = cycle_el(N1.copy())
    while N1 != Ni:
        N1 = Ni
        Ni = cycle_el(N1.copy())
    N = [element for element in massN if element not in Ni]  # Бесполезные символы
    if len(N) != 0:
        r = []  # Будущие новые правила
        for i in range(len(lst)):
            if lst[i][0] in Ni:
                r.append(lst[i])
    else:
        r = lst
    T = []
    for i in range(len(r)):
        [T.append(x) for j in lst[i][1] for x in list(j) if x in massT and x not in T]
    return T, Ni, r

################################################################################
#                                                                              #
# Данная функция с удаление из грамматики эпсилон-правил работает некорректно  #
#TODO                                                                          #
################################################################################
def del_eps_rooles(massN, lst, S):
    """
    Функция для удаления эпсилон-правил из заданного грамматического разбора.

    Параметры:
    - massN: список, содержащий нетерминальные символы
    - lst: список, представляющий правила грамматики
    - S: начальный символ

    Возвращает:
    - massN: обновленный список нетерминальных символов
    - r: обновленные правила грамматики после удаления эпсилон-правил
    - S_new: обновленный начальный символ после удаления эпсилон-правил
    """

    print('в) е-правил')

    def cycle_el(mass):
        for i in range(len(lst)):
            for x in lst[i][1]:
                if set(list(x)).issubset(mass):
                    if lst[i][0] not in mass:
                        mass.append(lst[i][0])
        return mass

    mass = ['.']
    N1 = cycle_el(mass)
    Ni = cycle_el(N1.copy())
    while N1 != Ni:
        N1 = Ni
        Ni = cycle_el(N1.copy())
    if S in Ni:
        c = 0
        i = 0
        S_new = list(string.ascii_uppercase)
        while c == 0:
            if S_new[i] not in Ni:
                S_new = S_new[i]
                c = 1
            else:
                i += 1
        massN.append(S_new)
        # Формируем новые правила
        r = [[S_new, [S, '.']]]
        for i in range(len(lst)):
            r0 = []
            # Если левая часть есть в списке Ni (правила переходят в е)
            if lst[i][0] in Ni:
                # Пробегаемся по правым частям
                for j in range(len(lst[i][1])):
                    if (any(ele in lst[i][1][j] for ele in Ni)) and (lst[i][1][j] != '.'):
                        # Добавляем ориг. в итоговый список
                        r0.append(lst[i][1][j])
                        # Рассматриваем правило как список элементов
                        el = list(lst[i][1][j])
                        ind = [x for x in range(len(el)) if el[x] in Ni]  # Индексы элементов из Ni в el
                        # Формируем список комбинаций индексов, которые позже удалим
                        combin = []
                        for k in range(1, len(ind) + 1):
                            for comb in iter.combinations(ind, k):
                                combin.append(comb)
                        # Удаляем элементы поиндексно и добавляем результат в итоговый список
                        for m in range(len(combin)):
                            orig_prav = list(lst[i][1][j])
                            for x in reversed(combin[m]):
                                orig_prav.pop(x)
                            r0.append(''.join(orig_prav))
                    elif lst[i][1][j] != '.':
                        r0.append(lst[i][1][j])
                r.append([lst[i][0], r0])
            else:
                r.append(lst[i])
    else:
        r = lst
        S_new = S
    return massN, r, S_new


def zip_rooles(massN, lst):
    """
        Функция для генерации списка правил без правил-epsilon.

        Параметры:
        massN (list): Список терминалов.
        lst (list): Список правил, где каждое правило представлено кортежем, где первый элемент - нетерминал, а второй элемент - список терминалов/нетерминалов.

        Возвращает:
        list: Список правил без правил-epsilon.
    """

    print('г) цепных правил')

    def cycle_el(mass):
        for i in range(len(lst)):
            if lst[i][0] in mass:
                [mass.append(j) for j in lst[i][1] if j in massN and j not in mass]
        return mass

    # Формируем общий список Ni для каждого нетерминала
    mass_Ni = []
    for i in range(len(lst)):
        mass = [lst[i][0]]
        N1 = cycle_el(mass)
        Ni = cycle_el(N1.copy())
        while N1 != Ni:
            N1 = Ni
            Ni = cycle_el(N1.copy())
        mass_Ni.append([lst[i][0], Ni.copy()])
    # Формируем новый список правил без цепных правил
    r = []
    for i in range(len(mass_Ni)):
        r0 = []
        for j in range(len(lst)):
            if lst[j][0] in mass_Ni[i][1]:
                r01 = [el for el in lst[j][1] if el not in massN]
                r0.extend(r01)
        r.append([mass_Ni[i][0], r0])
    return r


def left_factorize(grammar: dict[str, list[str]]) -> dict[str, list[str]]:
    """
    Эта функция выполняет левую факторизацию по данной грамматике
    Параметры:
        grammar: словарь, представляющий грамматику, где ключи - это нетерминальные символы,
        а значения - списки производственных правил.
    Возвращает:
        Left-factorized грамматику
    """
    print('д) левой факторизации правил')
    updated_grammar = {}

    for non_terminal in grammar:
        productions = grammar[non_terminal]
        common_prefixes = {}

        for production in productions:
            prefix = production[0]
            if prefix not in common_prefixes:
                common_prefixes[prefix] = []
            common_prefixes[prefix].append(production)

        new_productions = []

        for prefix in common_prefixes:
            if len(common_prefixes[prefix]) > 1:
                new_non_terminal = non_terminal + "'"
                updated_grammar[new_non_terminal] = [production[1:] for production in common_prefixes[prefix]]
                new_productions.append(prefix + new_non_terminal)
            else:
                new_productions.extend(common_prefixes[prefix])

        updated_grammar[non_terminal] = new_productions

    grammar.update(updated_grammar)
    return grammar


def remove_left_recursion(grammar):
    print('е) левой рекурсии')
    new_grammar = {}
    non_terminals = list(grammar.keys())

    for A in non_terminals:
        A_rules = grammar[A]
        alpha_rules = [rule for rule in A_rules if rule.startswith(A)]
        beta_rules = [rule for rule in A_rules if not rule.startswith(A)]

        if not alpha_rules:
            new_grammar[A] = A_rules
            continue

        A_prime = A + "'"
        new_rules_A = []
        new_rules_A_prime = []

        for beta_rule in beta_rules:
            new_rule = beta_rule + A_prime
            new_rules_A.append(new_rule)

        for alpha_rule in alpha_rules:
            new_rule = alpha_rule[len(A):] + A_prime
            new_rules_A_prime.append(new_rule)

        new_rules_A_prime.append('.')  # точка (.) представляет собой пустую цепочку

        new_grammar[A] = new_rules_A
        new_grammar[A_prime] = new_rules_A_prime

    return new_grammar


rez, c, rooles = check_KS()
print('1)', rez)
if c == 1:
    rez = check_exist(rooles, massN, S)
    print('2)', rez)

print('Исходная грамматика:')
print('G = (', massT, ',', massN, ', P,', S, ')')
print("\n".join(f"{i[0]} -> {' '.join(i[1])}" for i in rooles))

print('Эквивалентное преобразование грамматики посредству удаления:')

massN1, rooles1 = del_useless_sym(massT, massN, rooles)
print('G = (', massT, ',', massN1, ', P,', S, ')')
print("\n".join(f"{i[0]} -> {' '.join(i[1])}" for i in rooles1))

massT1, massN1, rooles1 = no_way_sym(rooles)
print('G = (', massT1, ',', massN1, ', P,', S, ')')
print("\n".join(f"{i[0]} -> {' '.join(i[1])}" for i in rooles1))

massN1, rooles1, S_new = del_eps_rooles(massN, rooles, S)
print('G = (', massT, ',', massN1, ', P,', S_new, ')')
print("\n".join(f"{i[0]} -> {' '.join(i[1])}" for i in rooles1))

rooles1 = zip_rooles(massN1, rooles1)
print('G = (', massT, ',', massN1, ', P,', S_new, ')')
print("\n".join(f"{i[0]} -> {' '.join(i[1])}" for i in rooles1))

rooles1 = left_factorize({item[0]: item[1] for item in rooles})
print(type(rooles1))
print("\n".join(f"{key} -> {value}" for key, value in rooles1.items()))

grammar = {item[0]: item[1] for item in rooles}
new_grammar = remove_left_recursion(grammar)
new_grammar = {key: value for key, value in new_grammar.items()}
print("\n".join(f"{key} -> {value}".rstrip("|") for key, value in new_grammar.items()))

