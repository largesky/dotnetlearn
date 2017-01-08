#include "Chapter12CLRMarshal.h"

BOOL Ch12ModifyCh12Bitable(Ch12Bitable *value)
{
	if (value == NULL)
	{
		return FALSE;
	}

	value->iValue = 1234;
	value->dValue = 1234.1234;

	return TRUE;
}

BOOL Ch12ModifyCh12NonBitable(Ch12NonBitable *value)
{
	if (value == 0)
	{
		return FALSE;
	}

	for (int i = 0; i < 4; i++)
	{
		value->iaValue[i] = 1234;
	}

	return TRUE;
}