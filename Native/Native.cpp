// Native.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "Native.h"
#include <stdio.h>
#include <locale.h>
#include <stdlib.h>

// ���ǵ���������һ��ʾ��
NATIVE_API int nNative=0;

// ���ǵ���������һ��ʾ����
NATIVE_API int fnNative(void)
{
	return 42;
}

// �����ѵ�����Ĺ��캯����
// �й��ඨ�����Ϣ������� Native.h
CNative::CNative()
{
	return;
}