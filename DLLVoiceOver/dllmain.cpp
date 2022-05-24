#include "pch.h"

#include "WindowsVoice.h"

#include <sapi.h>

#include <atlbase.h>
#pragma warning(disable:4996) 
#include <sphelper.h>
#pragma warning(default: 4996)
namespace WindowsVoice {

    CSpDynamicString selectedLang;
  void speechThreadFunc()
  {
    ISpVoice * pVoice = NULL;

    if (FAILED(::CoInitializeEx(NULL, COINITBASE_MULTITHREADED)))
    {
      theStatusMessage = L"Failed to initialize COM for Voice.";
      return;
    }


    HRESULT hr = CoCreateInstance(CLSID_SpVoice, NULL, CLSCTX_ALL, IID_ISpVoice, (void **)&pVoice);
    /// <summary>
    /// Voices
    /// </summary>
    CComPtr<ISpObjectToken>        cpVoiceToken;
    CComPtr<IEnumSpObjectTokens>   cpEnum;
    CComPtr<ISpVoice>              cpVoice;
    ULONG                          ulCount = 0;

    if (!SUCCEEDED(hr))
    {
      LPSTR pText = 0;

      ::FormatMessage(FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
        NULL, hr, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), pText, 0, NULL);
      LocalFree(pText);
      theStatusMessage = L"Failed to create Voice instance.";
      return;
    }
    theStatusMessage = L"Speech ready.";
    
    ISpObjectToken* cpToken(NULL);
   
    SpFindBestToken(SPCAT_VOICES, L"language=409;gender=female", L"", &cpToken);
    CComPtr<ISpDataKey> cpSpAttributesKey;

    if (SUCCEEDED(hr = cpToken->OpenKey(L"Attributes", &cpSpAttributesKey)))
    {
        cpSpAttributesKey->GetStringValue(L"language", &selectedLang);
        
    }
    pVoice->SetVoice(cpToken);
    cpToken->Release();


    SPVOICESTATUS voiceStatus;
    wchar_t* priorText = nullptr;
    while (!shouldTerminate)
    {
      if (stopText == true) {
          pVoice->Pause();
          pVoice->Speak(nullptr, SPF_ASYNC | SPF_PURGEBEFORESPEAK, nullptr);
          pVoice->Resume();
          
          stopText = false;
      }
      pVoice->GetStatus(&voiceStatus, NULL);
      if (voiceStatus.dwRunningState == SPRS_IS_SPEAKING)
      {
        if (priorText == nullptr)
          theStatusMessage = L"Error: SPRS_IS_SPEAKING but text is NULL";
        else
        {
          theStatusMessage = L"Speaking: ";
          theStatusMessage.append(priorText);
          if (!theSpeechQueue.empty())
          {
            theMutex.lock();
            
            if (lstrcmpW(theSpeechQueue.front(), priorText) == 0)
            {
              delete[] theSpeechQueue.front();
              theSpeechQueue.pop_front();
            }
            theMutex.unlock();
          }
        }
      }
      else
      {
        theStatusMessage = L"Waiting.";
        if (priorText != NULL)
        {
          delete[] priorText;
          priorText = NULL;
        }
        if (!theSpeechQueue.empty())
        {
          theMutex.lock();
          priorText = theSpeechQueue.front();
          theSpeechQueue.pop_front();
          theMutex.unlock();
          pVoice->Speak(priorText, SPF_IS_XML | SPF_ASYNC, NULL);

        }
      }
      Sleep(50);
    }
    pVoice->Pause();
    pVoice->Release();

    theStatusMessage = L"Speech thread terminated.";
  }

  void addToSpeechQueue(const char* text)
  {
    if (text)
    {
      int len = strlen(text) + 1;
      wchar_t *wText = new wchar_t[len];

      memset(wText, 0, len);
      ::MultiByteToWideChar(CP_UTF8, NULL, text, -1, wText, len);

      theMutex.lock();
      theSpeechQueue.push_back(wText);
      theMutex.unlock();
    }
  }
  void clearSpeechQueue()
  {
    theMutex.lock();
    theSpeechQueue.clear();
    theMutex.unlock();
  }
  void initSpeech()
  {
    shouldTerminate = false;
    if (theSpeechThread != nullptr)
    {
      theStatusMessage = L"Windows Voice thread already started.";
      return;
    }
    theStatusMessage = L"Starting Windows Voice.";
    theSpeechThread = new std::thread(WindowsVoice::speechThreadFunc);

    addToSpeechQueue(selectedLang);
  }
  void destroySpeech()
  {
    if (theSpeechThread == nullptr)
    {
      theStatusMessage = L"Speach thread already destroyed or not started.";
      return;
    }
    theStatusMessage = L"Destroying speech.";
    shouldTerminate = true;
    theSpeechThread->join();
    theSpeechQueue.clear();
    delete theSpeechThread;
    theSpeechThread = nullptr;
    CoUninitialize();
    theStatusMessage = L"Speech destroyed.";
  }
  void statusMessage(char* msg, int msgLen)
  {
    size_t count;
    wcstombs_s(&count, msg, msgLen, theStatusMessage.c_str(), msgLen);
  }
  void silenceQueue() {
      if (stopText == false) {
          clearSpeechQueue();
          theMutex.lock();
          stopText = true;
          theMutex.unlock();
      }
  }
  int getLanguage() {
      return selectedLang;
  }
}


BOOL APIENTRY DllMain(HMODULE, DWORD ul_reason_for_call, LPVOID)
{
  switch (ul_reason_for_call)
  {
  case DLL_PROCESS_ATTACH:
  case DLL_THREAD_ATTACH:
  case DLL_THREAD_DETACH:
  case DLL_PROCESS_DETACH:
    break;
  }
  
  return TRUE;
}