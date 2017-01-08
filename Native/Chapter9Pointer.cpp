#include "Chapter9Pointer.h"
#include <stdlib.h>
#include <ObjBase.h>

BOOL Ch9AllocInt(int **value)
{
	if (value == 0)
	{
		return FALSE;
	}

	*value = (int *)malloc(sizeof(int));
	if (*value != 0)
	{
		**value = 1234;
	}

	return *value != 0;
}

BOOL Ch9AllocCh9Dog(Ch9Dog **value)
{
	if (value == 0)
	{
		return FALSE;
	}

	*value = (Ch9Dog *)malloc(sizeof(Ch9Dog));
	if (*value != 0)
	{
		(*value)->iValue = 1234;
		wcscpy_s((*value)->wsValue, 4, L"我我我");
	}

	return *value != 0;
}

void Ch9FreeMemory(void *value)
{
	free(value);
}

wchar_t *Ch9AllocString()
{
	wchar_t *value = (wchar_t *)malloc(2 * 4);
	if (value != 0)
	{
		wcscpy_s(value, 4, L"我我我");
	}
	return value;
}

BOOL Ch9CoTaskMemAllocCh9Dog(Ch9Dog **value)
{
	if (value == 0)
	{
		return FALSE;
	}
	*value = (Ch9Dog *)CoTaskMemAlloc(sizeof(Ch9Dog));
	if (*value != 0)
	{
		(*value)->iValue = 1234;
		wcscpy_s((*value)->wsValue, 4, L"我我我");
	}

	return *value != 0;
}

wchar_t *Ch9CoTaskMemAllocString()
{
	wchar_t *value = (wchar_t *)CoTaskMemAlloc(2 * 4);
	if (value != 0)
	{
		wcscpy_s(value, 4, L"我我我");
	}
	return value;
}

