
#include "stdafx.h"
#include "Native.h"

typedef enum _Ch8DataType
{
	INT_TYPE,
	DOUBLE_TYPE,
	CH8SAMPLE_TYPE
}Ch8DataType;

typedef union _Ch8Sample
{
	int iValue;
	double dValue;
}Ch8Sample;

typedef union _Ch8Complex
{
	int IValue;
	Ch8Sample ch8SampleValue;
}Ch8Complex;

typedef struct _Ch8StructWithUnion
{
	Ch8DataType ch8DataType;
	union _InneralUnion
	{
		int iValue;
		Ch8Sample ch8SampleValue;
	}InneralUnion;
}Ch8StructWithUnion;

EXTERN_C
{
	NATIVE_API BOOL Ch8ModifyCh8Sample(Ch8Sample *value, Ch8DataType ch8DataType);

	NATIVE_API BOOL Ch8ModifyCh8Complex(Ch8Complex *value, Ch8DataType ch8DataType);

	NATIVE_API BOOL Ch8ModifyCh8StructWithUnion(Ch8StructWithUnion *value);

	NATIVE_API BOOL Ch8ModifyCh8StructWithUnionByValue(Ch8StructWithUnion value);

	NATIVE_API BOOL __stdcall Ch8ModifyCh8StructWithUnionByValueStd(Ch8StructWithUnion value);
}