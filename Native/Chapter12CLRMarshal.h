#pragma once

#include "Native.h"

typedef struct _Ch12Bitable
{
	int iValue;
	double dValue;
}Ch12Bitable;

typedef struct _Ch12NonBitable
{
	int iaValue[4];
}Ch12NonBitable;

EXTERN_C
{
	NATIVE_API BOOL Ch12ModifyCh12Bitable(Ch12Bitable *value);

	NATIVE_API BOOL Ch12ModifyCh12NonBitable(Ch12NonBitable *value);
}