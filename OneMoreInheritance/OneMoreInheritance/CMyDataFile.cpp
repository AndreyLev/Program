#include "pch.h"
#include "CMyDataFile.h"

using namespace std;

CMyDataFile::CMyDataFile()
{
	p_struct = new MyData;
}

CMyDataFile::~CMyDataFile()
{
	close();
	if (p_struct) delete p_struct;
}

CMyDataFile::CMyDataFile(const char* name, const char* mode)
{
	p_struct = new MyData;
	p_struct->file_header = CFile::_cpy_name(name);
	_is_open = _open(p_struct->file_header, mode);

}

void CMyDataFile::read(char* buff, size_t count)
{

	p_struct->data = (char*)malloc((count) * sizeof(char)); // Выделяю память под содержание файла
	p_struct->data[count] = '\0';
	CFile::read(p_struct->data, sizeof(char), count); // Вызываю функцию из базового класса

	cout << p_struct->data << endl; // Вывожу на экран результат

}

void CMyDataFile::write(char *buff, size_t count)
{
	CFile::write(buff, sizeof(char), count);
}