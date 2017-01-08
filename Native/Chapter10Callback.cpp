#include "Chapter10Callback.h"
#include <process.h>

Ch10DogArrivedHandler *g_Ch10DogArrivedHandler;

HANDLE g_HDetectThread = NULL;
BOOL g_BStop = FALSE;

unsigned int __stdcall DetectThread(void *param)
{
	INT64 count = 0;
	Ch10Dog dog = { 1234, L"This is a dog" };

	while (g_BStop == FALSE)
	{
		g_Ch10DogArrivedHandler(count++, L"2014-01-27 23:59:59", &dog);
		Sleep(2000);
	}

	return 0;
}

BOOL StartDetect(Ch10DogArrivedHandler *value)
{
	if (g_HDetectThread != NULL || value == NULL)
	{
		return FALSE;
	}
	g_Ch10DogArrivedHandler = value;
	g_HDetectThread = (HANDLE)_beginthreadex(0, 0, DetectThread, 0, 0, 0);
	g_BStop = FALSE;

	return TRUE;
}

BOOL StopDetect()
{
	if (g_HDetectThread == NULL)
	{
		return FALSE;
	}

	g_BStop = TRUE;

	if (WaitForSingleObject(g_HDetectThread, 5000) != WAIT_OBJECT_0)
	{
		_endthreadex((unsigned)g_HDetectThread);
	}
	g_HDetectThread = NULL;
	g_Ch10DogArrivedHandler = NULL;
	return TRUE;

}