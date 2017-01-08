#include "Native.h"

typedef struct _Ch6Dog
{
	int iValue;
	wchar_t wsValue[4];
}Ch6Dog;

extern "C" NATIVE_API BOOL Ch6ModifyArrayInt(int values[4]);

extern "C" NATIVE_API BOOL Ch6ModifyArrayChar(char values[4]);

extern "C" NATIVE_API BOOL Ch6ModifyArrayCh6Dog(Ch6Dog values[4]);
