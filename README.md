Решение состоит из следующих проектов Library, Console, Testing. 

Library проект библиотеки, которая содержит в себе классы 
- Reader(читает входной поток и формирует словарь)
- Creator (Генерирует выходной поток из словаря).
- Reader использует класс WordFinder, который получает символы и вычленяет слова.

Проект Console проект который получает два файла(по заданию). Зависит от Library. Он определяет наличие входного файла и возможность создать выходной.
Дальше он с помощью Reader получает словарь.
Потом с помощью Creator записывает словарь в файл.

Testing проект Xunit тестов. Проект зависит от Library. Он включает в себя 2 метода.
FileToDictionary сравнивет содержимое файла со словарем(инициализированном в тесте).
FileToText сравнивает сгенерируемый файл с исходным(правильным).
