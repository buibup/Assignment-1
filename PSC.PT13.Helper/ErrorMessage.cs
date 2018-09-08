using System;
using System.Collections.Generic;
using System.Text;

namespace PSC.PT13.Helper
{
    public sealed class ErrorMessage
    {
        public static string ClearRetrunCode(string message)
        {
            if (message.IndexOf("\r") >= 0) message = message.Replace("\r", "");
            if (message.IndexOf("\n") >= 0) message = message.Replace("\n", " ");
            return message;
        }

        public static string EncodeMessage(string message)
        {
            return "{#@" + message + "{#@";
        }

        public static string DecodeMessage(string message)
        {
            message = ClearRetrunCode(message);
            if (message.IndexOf("{#@") >= 0)
            {
                int index1 = message.IndexOf("{#@") + 3;
                int index2 = message.LastIndexOf("{#@") - 1;
                int len = index2 - index1 + 1;
                return message.Substring(index1, len);
            }
            else
                return message;
        }
    }
}
