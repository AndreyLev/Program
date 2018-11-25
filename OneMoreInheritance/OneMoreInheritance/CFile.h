#pragma once

#include <iostream>
#include <cassert>

class CFile
{
public:
	CFile();
	CFile(const char* name, const char* mode);

	virtual ~CFile();

	void open(const char* name, const char* mode); // Открытие файла
	void close(); // Закрытие файла

	void read(void* buff, size_t size_of_elem, size_t count); // Чтение из файла

	/*

	Функция считывает count элементов длиной size_of_elem в символьный массив , указанный в buff

	*/

	void write(const void* buff, size_t size_of_elem, size_t count); // Запись в файл

	/*

	Функция записывает в файл информацию из buff
	size_of_elem - размер каждого элемента
	count - количество элементов

	*/

	int seek(long offset, int origin);

	/*

	Функция перемещает указатель на offset байт от origin
	origin - начальная позиция
	Возвращает 0 в случае успешного выполнения
	Ненулевое значение - в любом другом случае

	*/

	int GetPosition();

	int get_lenght(); // Получаем длину

	bool is_open() const { return _is_open; }
	const char * const name() { return _name; }
	FILE * _p_file() { return p_file; }

private:
	char *_name;

protected:

	char* _cpy_name(const char* src);
	bool _open(const char* name, const char* mode);
	bool _is_open;
	FILE *p_file;


};

