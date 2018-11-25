#pragma once

#include <iostream>
#include <cassert>

class CFile
{
public:
	CFile();
	CFile(const char* name, const char* mode);

	virtual ~CFile();

	void open(const char* name, const char* mode); // �������� �����
	void close(); // �������� �����

	void read(void* buff, size_t size_of_elem, size_t count); // ������ �� �����

	/*

	������� ��������� count ��������� ������ size_of_elem � ���������� ������ , ��������� � buff

	*/

	void write(const void* buff, size_t size_of_elem, size_t count); // ������ � ����

	/*

	������� ���������� � ���� ���������� �� buff
	size_of_elem - ������ ������� ��������
	count - ���������� ���������

	*/

	int seek(long offset, int origin);

	/*

	������� ���������� ��������� �� offset ���� �� origin
	origin - ��������� �������
	���������� 0 � ������ ��������� ����������
	��������� �������� - � ����� ������ ������

	*/

	int GetPosition();

	int get_lenght(); // �������� �����

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

