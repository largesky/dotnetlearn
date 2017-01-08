#pragma once

#include "Native.h"

typedef struct _Ch9Dog
{
	int iValue;
	wchar_t wsValue[4];
}Ch9Dog;

EXTERN_C
{
	NATIVE_API BOOL Ch9AllocInt(int **value);

	NATIVE_API BOOL Ch9AllocCh9Dog(Ch9Dog **value);

	NATIVE_API wchar_t *Ch9AllocString();

	NATIVE_API BOOL Ch9CoTaskMemAllocCh9Dog(Ch9Dog **value);

	NATIVE_API wchar_t *Ch9CoTaskMemAllocString();

	NATIVE_API void Ch9FreeMemory(void *value);
}