#pragma once

#include "Native.h"

typedef struct _Ch10Dog
{
	int iValue;
	wchar_t wsValue[20];
}Ch10Dog;

typedef void(__cdecl Ch10DogArrivedHandler)(INT64 count, const wchar_t *time, Ch10Dog *value);

EXTERN_C
{
	NATIVE_API BOOL StartDetect(Ch10DogArrivedHandler *value);

	NATIVE_API BOOL StopDetect();
}