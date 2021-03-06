#include "pch.h"
#include <iostream>
#include <fstream>
using namespace std;


class Stack
{
public:
	Stack(); // Конструктор
	~Stack(); // Деструктор
	Stack(const Stack & obj); // конструктор копирования
	void Push(int a); // Добавление элемента в стек
	int Pop();  // удаляем элемент из стека
	void Print(); // Печать стека
	bool isEmpty(); // Проверка на полноту
	

private:
	struct Node
	{
		int data; // Какие-либо данные
		Node *next; // Указатель на следующий элемент
	};

	Node *top; // Указатель на вершину
};

Stack::Stack() :top(NULL)
{
}

Stack::Stack(const Stack & obj)
{
}

void Stack::Push(int data)
{
	Node *newelm = new Node; // Создаем новый элемент структуры
	newelm->data = data; // Пишем данные для элемента
	newelm->next = top;
	top = newelm;
}


int Stack::Pop()
{
	if (isEmpty()) // Если пусто возвращаем нолик
	{
		return 0;
	}
	int temp = top->data;
	Node *newelm = top;
	top = top->next;
	delete newelm;
	return temp;
}

bool Stack::isEmpty()
{
	return top ? false : true;
}

void Stack::Print()
{
	while (top)
	{
		cout << Pop() << ' ';
	}
}

Stack::~Stack()
{
	while (top)
	{
		Node *newelm = top;
		top = top->next;
		delete newelm;
	}
}

void PrintNewTrains(Stack & FirstTrain, Stack & SecondTrain, Stack & FullTrain, int mtemp, int fname, int sname)
{
	while (!FullTrain.isEmpty()) // Если поезд не пустой
	{
		mtemp = FullTrain.Pop(); // Берем вагон из исходного поезда и помещаем в нужный нам поезд
		if (mtemp == fname)
			FirstTrain.Push(mtemp);
		else if (mtemp == sname) SecondTrain.Push(mtemp);
	}
	FirstTrain.Print();
	cout << endl;
	SecondTrain.Print();
	cout << endl;
}

void Menu()
{
	cout << "Welcome to my program" << endl <<
		"1. Input from keyboard" << endl << "2. Input from file" << endl;
}

int main()
{
	Stack FullTrain, FirstTrain, SecondTrain;
	int fname, sname; // Наименования вагонов
	int i = 1,c, mtemp, av; // av - количество вагонов
	ifstream fin("file.txt");
	
		Menu();
		cout << "YOUR CHANGE : ";
		cin >> c;
		switch (c)
		{
		case 1:
		{
			cout << "ENTER THE CODE OF THE FIRST VAGON" << endl;
			cin >> fname;
			cout << "ENTER THE CODE OF THE SECOND VAGON" << endl;
			cin >> sname;
			cout << "ENTER THE COUNT OF VAGONS : " << endl;
			cin >> av;
			while (av > 0)
			{
				cout << i << " VAGON : ";
				cin >> mtemp;
				FullTrain.Push(mtemp);
				av--;
				i++;
			}
			cout << endl;
			PrintNewTrains(FirstTrain, SecondTrain, FullTrain, mtemp, fname, sname);
			break;
		}
		case 2:
		{
			//system("cls");
			if (!fin.is_open()) cout << "ERROR, FILE IS NOT OPEN" << endl;
			else
			{
				fin >> fname >> sname;
				while (!fin.eof()) // Читаем пока не конец файла
				{
					fin >> mtemp;
					FullTrain.Push(mtemp);
				}
				cout << endl;
				fin.close();
				PrintNewTrains(FirstTrain, SecondTrain, FullTrain, mtemp, fname, sname);
			}
			break;
		}
		default: {
			cout << "Такого пункта в меню не существует!" << endl;
			break;
		}
	}
}

