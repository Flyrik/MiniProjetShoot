using UnityEngine;

public static class PlatformHelper
{
    public static bool IsQuest()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
            return true; // Quest / Android
        #else
            return false; // PC / Windows
        #endif
    }
}
