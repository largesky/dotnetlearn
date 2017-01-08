#pragma once

#include "Native.h"

typedef struct _Ch3Dog
{
	int iValue;
	wchar_t wsValue[4];
}Ch3Dog;

extern "C" NATIVE_API BOOL Ch3ModifyDog(Ch3Dog *dog);

extern "C" NATIVE_API BOOL Ch3ModifyDog1(int iValue, double * dValue, Ch3Dog * pDogValue);

extern "C" NATIVE_API BOOL Ch3ModifyDog2(int iValue, double * dValue, Ch3Dog dogValue);