#pragma once

#include "Native.h"

extern "C" NATIVE_API int Ch5PrintAW(const char * message,const wchar_t *message1);

extern "C" NATIVE_API int Ch5PrintA(const char * message,const char * message1);

extern "C" NATIVE_API int Ch5PrintW(const wchar_t * message,const wchar_t * message1);

extern "C" NATIVE_API int Ch5Login(const wchar_t *name,const wchar_t *pwd,wchar_t *error);

extern "C" NATIVE_API BOOL Ch5ModifyString(wchar_t *str,int size); 

extern "C" NATIVE_API BOOL Ch5ModifyChar(wchar_t *chr);


