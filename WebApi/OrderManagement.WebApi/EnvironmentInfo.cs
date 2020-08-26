using System;
using System.Text;

namespace OrderManagement.WebApi
{
    public static class EnvironmentInfo
    {

        public static string GetFormattedInfo()
        {
            StringBuilder formattedInfo = new StringBuilder();
            formattedInfo.Append( 
                IsRunningInsideContainer ?
                    $"WebAPI running inside Container":
                    $"WebAPI running on: {OperatingSystem}"
                );

            //formattedInfo.Append($" and the machine name is: {Environment.MachineName}");
            
            return formattedInfo.ToString();
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