import csv

from mimesis import Person

def lab7_1():
    try:
        person = Person()
        d = {"age": person.age(),
             "name": person.name(),
             "academic_degree": person.academic_degree(),
             "height": person.height(),
             "gender": person.gender()}
        return f"{len(d)}" \
               f"\nПример: {d}"
    except Exception as e:
        return str(e)

def lab7_2(flag):
    try:
        with open("resourses\students.csv", encoding="UTF-8") as csv_file:
            reader = csv.reader(csv_file, delimiter=";")
            reader.__next__()
            if flag == 0:
                title = str({x[0]: x[1:] for x in sorted(reader, key=lambda row: row[3].split())})
                return title
            return {x[0]: x[1:] for x in sorted(reader, key=lambda row: row[3].split())}
    except Exception as e:
        return str(e)
def lab7_3(group_to_update, flag):
    try:
        data = lab7_2(1)
        for key, value in data.items():
            if value[2] == group_to_update:
                value[1] = str(int(value[1]) + int(1))
        if flag == 0:
            return str(data)
        return data
    except Exception as e:
        return str(e)

def lab7_4(text, flag):
    try:
        if flag == 1:
            with open("resourses\students_new.csv", mode="w", newline='', encoding="UTF-8") as csv_file:
                writer = csv.writer(csv_file, delimiter=";")
                writer.writerow(["№", "ФИО", "Возраст", "Группа"])
                data = lab7_3(text, 1)
                writer.writerows([[k, *data[k]] for k in data])
                return 'СОХРАНЕНО: ' + str(data)
        else:
            with open("resourses\students_new.csv", mode="w", newline='', encoding="UTF-8") as csv_file:
                writer = csv.writer(csv_file, delimiter=";")
                writer.writerow(["№", "ФИО", "Возраст", "Группа"])
                data = lab7_3(text, 1)
                writer.writerows([[k, *data[k]] for k in data])
                return data
    except Exception as e:
        return str(e)


