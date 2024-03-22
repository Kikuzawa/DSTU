import sys
from PyQt5.QtWidgets import QMainWindow, QComboBox, QVBoxLayout, QPushButton, QTextEdit, QLineEdit, QApplication, \
    QWidget, QMessageBox
from PyQt5 import QtGui
from PyQt5.QtGui import QFont

from helpFunctions.functions import *
from helpFunctions.functions_saving import *
from helpFunctions.create_scv_file import create_csv_file

#todo исправить все баги и доработать комментарии

'''
    Работа Kikuzawa, частично использовались работы C3EQUALZz 
    
    Ссылка: https://github.com/C3EQUALZz/DSTU_VKB/tree/master/python_language/programming_languages_python
'''

class MyWindow(QMainWindow):
    def __init__(self):
        super().__init__()
        self.module_combo = QComboBox(self)
        self.function_combo = QComboBox(self)
        self.execute_button = QPushButton("Выполнить", self)
        self.condition_text = QTextEdit(self)
        self.input_edit = QLineEdit(self)
        self.output_text = QTextEdit(self)
        self.save_button = QPushButton("Сохранить", self)
        self.test = QPushButton("Перегенерация CSV", self)
        self.exit_button = QPushButton("Выход", self)
        self.initUI()

    # noinspection PyUnresolvedReferences
    def initUI(self):
        self.setGeometry(100, 100, 1400, 800)
        self.setWindowTitle("Лабораторные - Языки Программирования")

        # Создаем виджет
        central_widget = QWidget(self)
        self.setCentralWidget(central_widget)

        # Создаем макет
        layout = QVBoxLayout()

        # Выбор модуля
        self.module_combo.addItem('Лабораторная 1', ['Задача 1', 'Задача 2', 'Задача 3', 'Задача 4'])
        self.module_combo.addItem('Лабораторная 2', ['Задача 1', 'Задача 2', 'Задача 3', 'Задача 4'])
        self.module_combo.addItem('Лабораторная 3', ['Задача 1', 'Задача 2', 'Задача 3', 'Задача 4'])
        self.module_combo.addItem('Лабораторная 4', ['Задача 1', 'Задача 2', 'Задача 3', 'Задача 4'])
        self.module_combo.addItem('Лабораторная 5', ['Задача 1', 'Задача 2', 'Задача 3', 'Задача 4'])
        self.module_combo.addItem('Лабораторная 6', ['Задача 1'])
        self.module_combo.addItem('Лабораторная 7', ['Задача 1', 'Задача 2', 'Задача 3', 'Задача 4'])
        self.module_combo.addItem('Лабораторная 8', ['Задача 1', 'Задача 2', 'Задача 3'])
        self.module_combo.addItem('Лабораторная 9', ['Задача 1', 'Задача 2', 'Задача 3', 'Задача 4'])
        self.module_combo.addItem('Лабораторная 10',
                                  ['Задача 1', 'Задача 2', 'Задача 3', 'Задача 4', 'Задача 5', 'Задача 6', 'Задача 7',
                                   'Задача 8'])
        self.module_combo.addItem('Лабораторная 11', ['Задача 1', 'Задача 2', 'Задача 3', 'Задача 4', 'Задача 5'])
        self.module_combo.addItem('Лабораторная 12', ['Задача 1', 'Задача 2', 'Задача 3', 'Extra'])
        self.module_combo.addItem('Лабораторная 13',
                                  ['Задача 1', 'Задача 2', 'Задача 3', 'Задача 4', 'Задача 5', 'Задача 6', 'Задача 7',
                                   'Задача 8', 'Задача 9', 'Задача 10', 'Задача 11', 'Задача 12', 'Задача 13']),
        self.module_combo.addItem('Лабораторная 14',
                                  ['Задача 1', 'Задача 2', 'Задача 3', 'Задача 4', 'Задача 5', 'Задача 6'])
        # noinspection PyUnresolvedReferences
        self.module_combo.currentIndexChanged.connect(self.indexChanged)
        layout.addWidget(self.module_combo)

        # Выбор функции
        self.indexChanged(self.function_combo.currentIndex())
        layout.addWidget(self.function_combo)

        # Кнопка выполнения функции
        # noinspection PyUnresolvedReferences
        self.execute_button.clicked.connect(self.execute_function)
        layout.addWidget(self.execute_button)

        # Окно для вывода условия задачи
        self.condition_text.setReadOnly(True)
        layout.addWidget(self.condition_text)

        # Окно для ввода данных
        layout.addWidget(self.input_edit)

        # Окно для вывода данных
        self.output_text.setReadOnly(True)
        layout.addWidget(self.output_text)

        self.setWindowIcon(QtGui.QIcon("icons8-окно-приложения-96.png"))

        # Установка макета в центральный виджет
        central_widget.setLayout(layout)

        # noinspection PyUnresolvedReferences
        self.save_button.clicked.connect(self.save_function)
        layout.addWidget(self.save_button)

        # noinspection PyUnresolvedReferences
        self.test.clicked.connect(self.testing)
        layout.addWidget(self.test)

        # noinspection PyUnresolvedReferences
        self.exit_button.clicked.connect(self.show_exit_confirmation)
        layout.addWidget(self.exit_button)

        self.setFont(QFont("Arial", 14, QFont.Bold))

    @staticmethod
    def testing():
        create_csv_file()

    def indexChanged(self, index):
        self.function_combo.clear()
        data = self.module_combo.itemData(index)
        if data is not None:
            self.function_combo.addItems(data)

    def execute_function(self):
        selected_module = self.module_combo.currentText()
        selected_function = self.function_combo.currentText()
        input_data = self.input_edit.text()
        condition = get_condition(selected_module, selected_function)
        self.condition_text.setPlainText(condition)
        result = selection_def(selected_module, selected_function, input_data)
        if selected_function == 'Задача 1' and selected_module == "Лабораторная 14":
            self.output_text.setHtml(self.pretty_print_table(lab14_1(input_data)))
        elif selected_function == 'Задача 2' and selected_module == "Лабораторная 14":
            self.output_text.setHtml(self.pretty_print_table(lab14_2(input_data)))
        else:
            self.output_text.setPlainText(result)

    @staticmethod
    def pretty_print_table(pretty_table: PrettyTable):
        """
        Отображает PrettyTable в QTextBrowser.

        Args:
            pretty_table (PrettyTable): Объект PrettyTable с данными.

        Returns:
            html разметку для таблицы
        """
        # Создаем HTML-разметку вручную
        html = "<table border='1'>"
        html += "<tr>"
        for field in pretty_table.field_names:
            html += f"<th>{field}</th>"
        html += "</tr>"

        for row in pretty_table.rows:
            html += "<tr>"
            for value in row:
                html += f"<td>{value}</td>"
            html += "</tr>"

        html += "</table>"
        return html
    def save_function(self):
        selected_module = self.module_combo.currentText()
        selected_function = self.function_combo.currentText()
        input_data = self.input_edit.text()
        result = selection_save(selected_module, selected_function, input_data)
        self.output_text.setPlainText(result)

    def show_exit_confirmation(self):
        # Создаем диалоговое окно с вопросом о выходе
        reply = QMessageBox.question(self, 'Подтверждение выхода',
                                     'Вы уверены, что хотите выйти?',
                                     QMessageBox.Yes | QMessageBox.No, QMessageBox.No)

        # Обработка ответа пользователя
        if reply == QMessageBox.Yes:
            # Закрываем приложение
            QApplication.instance().quit()


if __name__ == '__main__':
    app = QApplication(sys.argv)
    window = MyWindow()
    window.show()
    sys.exit(app.exec_())
