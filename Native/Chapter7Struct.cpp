#include "Chapter7Struct.h"

BOOL Ch7ModifyCh7Basic(Ch7Basic *value)
{
	if (value == 0)
	{
		return FALSE;
	}

	value->bValue = true;
	value->bWinValue = TRUE;
	value->dValue = 1234.1234;
	value->iValue = 1234;
	return TRUE;
}

BOOL Ch7ModifyCh7CharA(Ch7CharA *value)
{
	if (value == 0)
	{
		return FALSE;
	}

	value->acValue1 = 'A';
	value->acValue2 = 'A';

	return TRUE;
}

BOOL Ch7ModifyCh7CharAW(Ch7CharAW *value)
{
	if (value == 0)
	{
		return FALSE;
	}

	value->acValue = 'A';
	value->wcValue = L'我';

	return TRUE;
}

BOOL Ch7ModifyCh7StringA(Ch7StringA *value)
{
	if (value == 0)
	{
		return FALSE;
	}

	strcpy_s(value->asValue1, 4, "AAA");
	strcpy_s(value->asValue2, 4, "AAA");

	return TRUE;
}

BOOL Ch7ModifyCh7StringAW(Ch7StringAW *value)
{
	if (value == 0)
	{
		return FALSE;
	}

	strncpy_s(value->asValue, 4, "AAA", 4);
	wcsncpy_s(value->wsValue, 4, L"我我我",4);

	return TRUE;
}
BOOL Ch7ModifyCh7StringPtr(Ch7StringPtr *value)
{
	if (value == 0)
	{
		return FALSE;
	}

	strcpy_s(value->pasValue, 4, "AAA");
	wcscpy_s(value->pwsValue, 4, L"我我我");

	return TRUE;
}
BOOL Ch7ModifyCh7Struct(Ch7Struct *value)
{
	return Ch7ModifyCh7StringAW(&value->ch7StringAW);
}

BOOL Ch7ModifyCh7StructArray(Ch7StructArray *value)
{
	if (value == 0)
	{
		return FALSE;
	}

	for (int i = 0; i < 4; i++)
	{
		if (Ch7ModifyCh7StringAW(&value->ch7StringAWArray[i]) == FALSE)
		{
			return FALSE;
		}
		value->iArray[i] = 1234;
	}

	return TRUE;
}
BOOL Ch7ModifyCh7Pointer(Ch7Pointer *value)
{
	if (value == 0)
	{
		return FALSE;
	}
	*(value->iValuePtr) = 1234;
	return Ch7ModifyCh7StringAW(value->pch7StringAWPtr);
}

BOOL Ch7ModifyCh7PointerArray(Ch7PointerArray *value)
{
	if (value == 0)
	{
		return FALSE;
	}

	for (int i = 0; i < 4; i++)
	{
		if (value->iValuePtrArray[i])
		{
			*(value->iValuePtrArray[i]) = 1234;
		}

		if (value->pch7StringAWPtrArray[i])
		{
			Ch7ModifyCh7StringAW(value->pch7StringAWPtrArray[i]);
		}
	}

	return TRUE;
}