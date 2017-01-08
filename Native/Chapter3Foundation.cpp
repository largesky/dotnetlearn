#include "Chapter3Foundation.h"

BOOL Ch3ModifyDog(Ch3Dog *dog)
{
	if (dog == NULL)
	{
		return FALSE;
	}

	dog->iValue = 1234;
	wcscpy_s(dog->wsValue, 4, L"Œ“Œ“Œ“");
	return TRUE;
}

BOOL Ch3ModifyDog1(int iValue, double * dValue, Ch3Dog * pDogValue)
{
	iValue = 1234;
	*dValue = 1234.1234;
	return Ch3ModifyDog(pDogValue);
}

BOOL Ch3ModifyDog2(int iValue, double * dValue, Ch3Dog dogValue)
{
	iValue = 1234;
	*dValue = 1234.1234;
	return Ch3ModifyDog(&dogValue);
}