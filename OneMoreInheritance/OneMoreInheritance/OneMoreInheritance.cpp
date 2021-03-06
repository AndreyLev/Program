#include "pch.h"
#include <iostream>
#include "CFile.h"
#include "CMyDataFile.h"
#include "SomeFuncs.h"

using namespace std;


int main()
{

	CFile file;
	CMyDataFile OneMoreFile;
	int c;

	//------------------------------------------------------------

	while (true)
	{
		Menu();
		cin >> c;
		system("cls");


		switch (c)
		{
		case 1:
		{
			if (OneMoreFile.is_open()) cout << "File is already open" << endl;
			else
			{
				// Режим a+ используется для чтения и добавления данных
				// Все операции выполняются в конец файла, защищая данные от случайного изменения
				// Можно изменить позицию внутреннего указателя , но только для чтения
				OneMoreFile.open("text.txt", "a+");
				cout << "FILE IS OPEN" << endl;
			}
		}
		break;
		case 2:
		{
			if (OneMoreFile.is_open())
			{
				OneMoreFile.close();
				cout << "FILE IS CLOSED" << endl;
			}
			else cout << "FILE IS CLOSED" << endl;


		}
		break;
		case 3:
		{
			if (OneMoreFile.is_open())
			{
				char testString[] = "TEST STRING";
				// Количество байтов, на которое будет производиться сдвиг
				long offset;
				// Начальная позиция, от которой будет производиться сдвиг
				int origin;
				cout << "ENTER THE START POSITION : ";
				cin >> origin;
				cout << "ENTER THE AMOUNT OF SHIFT : ";
				cin >> offset;
				// Функция seek возвращает 0 при успешном выполнении
				// и любое другое число в обратном случае
				if (OneMoreFile.seek(offset, origin) == 0)
				{
					cout << "successful move" << endl;
				}
				else cout << "bad move" << endl;


			}
			else cout << "FILE IS CLOSED" << endl;
		}
		break;
		case 4:
		{

			if (OneMoreFile.is_open())
			{

				int len = OneMoreFile.get_lenght();
				char *str = (char*)malloc(len * sizeof(char));
				OneMoreFile.read(str, len);

			}
			else cout << "CANNOT READ THE FILE, IT IS CLOSED" << endl;

		}
		break;
		case 5:
		{
			if (OneMoreFile.is_open())
			{
				const int MAX_SIZE = 256;
				char MyString[MAX_SIZE];


				// cin.get() чтобы cin.getline дальше не пропускался
				cin.get();
				cin.getline(MyString, MAX_SIZE);

				cout << MyString << endl;

				// Для корректного отображения

				OneMoreFile.get_lenght();
				int llen = strlen(MyString);
				OneMoreFile.write(MyString, llen);
				fflush(OneMoreFile._p_file()); // Обновляем поток, записываем в файл незаписанные данные
				cout << "FILE IS SAVED" << endl;

			}
			else cout << "FILE IS CLOSED" << endl;
		}
		break;
		case 6:
		{
			if (OneMoreFile.is_open())
			{
				int position = OneMoreFile.GetPosition();;
				cout << position << endl;
			}
			else cout << "FILE IS CLOSED" << endl;
		}
		break;
		case 7:
		{
			if (OneMoreFile.is_open())
				cout << "Lenght of the file is : " << OneMoreFile.get_lenght() << endl;
			else cout << "FILE IS CLOSED" << endl;
		}
		break;
		default:
		{
			cout << "There is not such point in Menu" << endl;
		}
		break;
		}
		cout << endl;
	}
	return 0;
}


