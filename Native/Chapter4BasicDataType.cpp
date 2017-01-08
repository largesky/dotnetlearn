#include "Chapter4BasicDataType.h"

BOOL Ch4_ModifyBasicDataType(int iValue, double *dValue, DWORD *dwValue)
{
	*dValue=1234.1234;
	*dwValue=1234;

	return iValue==123;
}