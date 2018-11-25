#pragma once
#include "CFile.h"
class CMyDataFile :
	public CFile
{
public:
	CMyDataFile();
	CMyDataFile(const char* name, const char* mode);
	~CMyDataFile();

	void read(char* buff, size_t count);

	void write(char* buff, size_t count);

	const char * const name() { return p_struct->file_header; }

	const char * const data_m() { return p_struct->data; }

private:

	struct MyData
	{
		char* file_header;
		char* data;
	} *p_struct;


};

