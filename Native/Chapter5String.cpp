#include "Chapter5String.h"

int Ch5PrintAW(const char * message,const wchar_t *message1)
{
	int ret=printf(message)+wprintf(message1);
	return ret;
}

int Ch5PrintA(const char * message,const char * message1)
{
	return printf(message)+printf(message1);
}

int Ch5PrintW(const wchar_t * message,const wchar_t * message1)
{
	return wprintf(message)+wprintf(message1);
}

int Ch5Login(const wchar_t *name,const wchar_t *pwd,wchar_t *error)
{
	if(name==0 || pwd==0)
	{
		wcscpy_s(error,128,L"argument name or pwd is null");
		return 0;
	}

	wcscpy_s(error,24,L"success");
	return 1;
}

BOOL Ch5ModifyString(wchar_t *str,int size)
{
	if(str==0)
	{
		return FALSE;
	}

	for(int i=0;i<size;i++)
	{
		*(str+i)=L'ÎÒ';
	}
	return TRUE;
}

BOOL Ch5ModifyChar(wchar_t *chr)
{
	if(chr==0)
	{
		return FALSE;
	}

	*chr=L'A';

	return TRUE;
}