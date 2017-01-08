#include "Chapter8Union.h"

BOOL Ch8ModifyCh8Sample(Ch8Sample *value, Ch8DataType ch8DataType)
{
	if (value == 0)
	{
		return FALSE;
	}

	int size = sizeof(Ch8Sample);
	if (ch8DataType == INT_TYPE)
	{
		value->iValue = 1234;
	}
	else if (ch8DataType == DOUBLE_TYPE)
	{
		value->dValue = 1234.1234;
	}
	else
	{
		return FALSE;
	}
	return TRUE;
}

BOOL Ch8ModifyCh8Complex(Ch8Complex *value, Ch8DataType ch8DataType)
{
	if (value == 0)
	{
		return FALSE;
	}

	if (ch8DataType == INT_TYPE)
	{
		value->IValue = 1234;
	}
	else if (ch8DataType == CH8SAMPLE_TYPE)
	{
		value->ch8SampleValue.dValue = 1234.1234;
	}
	else
	{
		return FALSE;
	}

	return TRUE;
}

BOOL Ch8ModifyCh8StructWithUnion(Ch8StructWithUnion *value)
{
	if (value == 0)
	{
		return FALSE;
	}

	if (value->ch8DataType == INT_TYPE)
	{
		value->InneralUnion.iValue = 1234;
	}
	else if (value->ch8DataType == CH8SAMPLE_TYPE)
	{
		value->InneralUnion.ch8SampleValue.dValue = 1234.1234;
	}
	else
	{
		return FALSE;
	}

	return TRUE;
}

BOOL Ch8ModifyCh8StructWithUnionByValue(Ch8StructWithUnion value)
{
	return Ch8ModifyCh8StructWithUnion(&value);
}

BOOL __stdcall Ch8ModifyCh8StructWithUnionByValueStd(Ch8StructWithUnion value)
{
	return Ch8ModifyCh8StructWithUnion(&value);
}