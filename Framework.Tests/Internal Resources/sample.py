# Константы используемы для вычислений
myColumnName = "MyColumns" # Название столбца с результатами вычислений
NaN = "NaN" # Ошибка

## Функция для изменения значений 

# Изменение структуры таблицы
def Change(table):
    AddColumn(table, myColumnName)

# Вычисляем значения
## no - номер строки
def ToCalculate(no, row):
    # Проверяем на наличие значений необходимые нам ячейки
    if ((row.IsNull(0) == False) and (row.IsNull(1) == False)):
        row[myColumnName] = row[0] + row[1]
    else:
        row[myColumnName] = NaN

##
# Дополнительный функции

# Добавляем столбец
def AddColumn(table, name):
    table.Columns.Add(name);