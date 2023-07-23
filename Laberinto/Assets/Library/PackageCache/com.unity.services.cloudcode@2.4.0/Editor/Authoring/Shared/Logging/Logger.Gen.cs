// WARNING: Auto generated code. Modifications will be lost!
using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Unity.Services.CloudCode.Authoring.Editor.Shared.Logging
{
    static class Logger
    {
        const string k_Tag = "[CloudCodeAuthoring]";

        const string k_VerboseLoggingDefine = "ENABLE_UNITY_CLOUD_CODE_AUTHORING_VERBOSE_LOGGING";

        public static void Log(object message) => Debug.unityLogger.Log(k_Tag, message);
        public static void LogWarning(object message) => Debug.unityLogger.LogWarning(k_Tag, message);
        public static void LogError(object message) => Debug.unityLogger.LogError(k_Tag, message);
        public static void LogException(Exception exception) => Debug.unityLogger.Log(LogType.Exception, k_Tag, exception);

        [Conditional("UNITY_ASSERTIONS")]
        public static void LogAssertion(object message) => Debug.unityLogger.Log(LogType.Assert, k_Tag, message);

#if !ENABLE_UNITY_SERVICES_VERBOSE_LOGGING
        [Conditional(k_VerboseLoggingDefine)]
#endif
        public static void LogVerbose(object message) => Debug.unityLogger.Log(k_Tag, message);
    }
}
