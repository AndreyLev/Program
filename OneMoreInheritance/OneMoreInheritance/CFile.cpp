#include "pch.h"
#include "CFile.h"


CFile::CFile() : _name(0) {}

CFile::CFile(const char* name, const char* mode)
{
	_name = _cpy_name(name);
	_is_open = _open(_name, mode);
}

CFile::~CFile()
{
	close();
	if (_name) delete _name;
}

void CFile::open(const char* name, const char* mode)
{
	_name = _cpy_name(name);
	_is_open = _open(_name, mode);
}

void CFile::close()
{
	if (p_file)
	{
		fclose(p_file);
		p_file = 0;
	}
}

bool CFile::_open(const char* name, const char* mode)
{
	p_file = fopen(name, mode);
	return p_file;
}

void CFile::write(const void* buff, size_t size_of_elem, size_t count)
{
	fwrite(buff, size_of_elem, count, p_file);
	fflush(p_file);
}

int CFile::seek(long offset, int origin)
{
	return fseek(p_file, offset, origin);
}

int CFile::GetPosition()
{
	int len = ftell(p_file);
	return len;
}

void CFile::read(void* buff, size_t size_of_elem, size_t count)
{
	fread(buff, size_of_elem, count, p_file);

}

char* CFile::_cpy_name(const char* src)
{
	char *name = (char*)malloc((strlen(src) + 1) * sizeof(char));
	assert(name);

	strcpy(name, src);

	return name;
}

int CFile::get_lenght()
{
	seek(0, SEEK_END); // Перемещаем указатель в конец файла

	int len = ftell(p_file); // Возвращаем текущее положение внутреннего указателя(в нашем случае указатель будет в конце файла)

	/*

	Функция ftell возращает значение указателя текущего положеня потока

	*/

	rewind(p_file);

	/*

	Функция rewind устанавливает внутренний указатель положения файла в начальное положение (начало файла)
	К тому же, обнуляет индикатор ошибок (fseek как аналог , но без обнуления индикатора ошибок)

	*/

	return len;
}
