#pragma once

#include "stdafx.h"
#include "Native.h"

typedef struct _Ch7Basic
{
	int iValue;
	double dValue;
	BOOL bWinValue;
	bool bValue;
}Ch7Basic;

typedef struct _Ch7CharA
{
	char acValue1;
	char acValue2;
}Ch7CharA;

typedef struct _Ch7CharAW
{
	wchar_t wcValue;
	char acValue;
}Ch7CharAW;

typedef struct _Ch7StringA
{
	char asValue1[4];
	char asValue2[4];
}Ch7StringA;


typedef struct _Ch7StringAW
{
	wchar_t wsValue[4];
	char asValue[4];
}Ch7StringAW;

typedef struct _Ch7StringPtr
{
	wchar_t * pwsValue;
	char * pasValue;
}Ch7StringPtr;

typedef struct _Ch7Struct
{
	Ch7StringAW ch7StringAW;
}Ch7Struct;

typedef struct _Ch7StructArray
{
	Ch7StringAW ch7StringAWArray[4];
	int iArray[4];
}Ch7StructArray;

typedef struct _Ch7Pointer
{
	Ch7StringAW *pch7StringAWPtr;
	int *iValuePtr;
}Ch7Pointer;

typedef struct _Ch7PointerArray
{
	Ch7StringAW *pch7StringAWPtrArray[4];
	int *iValuePtrArray[4];
}Ch7PointerArray;

EXTERN_C
{
	NATIVE_API BOOL Ch7ModifyCh7Basic(Ch7Basic *value);

	NATIVE_API BOOL Ch7ModifyCh7CharA(Ch7CharA *value);
	
	NATIVE_API BOOL Ch7ModifyCh7CharAW(Ch7CharAW *value);

	NATIVE_API BOOL Ch7ModifyCh7StringA(Ch7StringA *value);

	NATIVE_API BOOL Ch7ModifyCh7StringAW(Ch7StringAW *value);

	NATIVE_API BOOL Ch7ModifyCh7StringPtr(Ch7StringPtr *value);

	NATIVE_API BOOL Ch7ModifyCh7Struct(Ch7Struct *value);

	NATIVE_API BOOL Ch7ModifyCh7StructArray(Ch7StructArray *value);

	NATIVE_API BOOL Ch7ModifyCh7Pointer(Ch7Pointer *value);

	NATIVE_API BOOL Ch7ModifyCh7PointerArray(Ch7PointerArray *value);
}