using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class CacheKeys
    {
        public static string Entry => $"_Entry{0}";
        public static string CallbackEntry => "_Callback";
        public static string CallbackMessage => "_CallbackMessage";
        public static string Parent => "_Parent";
        public static string Child => "_Child";
        public static string DependentMessage => "_DependentMessage";
        public static string DependentCTS => "_DependentCTS";
        public static string Ticks => "_Ticks";
        public static string CancelMsg => "_CancelMsg";
        public static string CancelTokenSource => "_CancelTokenSource";
    }
}
