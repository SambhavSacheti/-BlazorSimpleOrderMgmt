using System;
using System.Text;

namespace OrderManagement.WebApi
{
    public static class EnvironmentInfo
    {

        public static string GetFormattedInfo()
        {
            if (IsRunningInsideContainer)
                return ($"WebAPI running inside Container"); 
            else
                return ($"WebAPI running on: {OperatingSystem}");

        }

        public static bool IsRunningInsideContainer =>
            Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") is object
            ? true : false;

        public static string OperatingSystem =>
            Environment.GetEnvironmentVariable("OS") is object ? 
            Environment.OSVersion.ToString() 
            : "N/A";
    }
}