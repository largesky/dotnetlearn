#include "Chapter6Array.h"

BOOL Ch6ModifyArrayInt(int values[4])
{
	if (values == 0)
	{
		return FALSE;
	}

	for (int i = 0; i < 4; i++)
	{
		values[i] = 1234;
	}

	return TRUE;
}

BOOL Ch6ModifyArrayChar(char values[4])
{
	if (values == 0)
	{
		return FALSE;
	}

	for (int i = 0; i < 4; i++)
	{
		values[i] = 'A';
	}

	return TRUE;
}

BOOL Ch6ModifyArrayCh6Dog(Ch6Dog values[4])
{
	if (values == 0)
	{
		return FALSE;
	}

	for (int i = 0; i < 4; i++)
	{
		values[i].iValue = 1234;
		wcscpy_s(values[i].wsValue, 4, L"ÎÒÎÒÎÒ");
	}

	return TRUE;
}
