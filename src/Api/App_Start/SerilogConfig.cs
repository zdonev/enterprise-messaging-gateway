using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serilog;

namespace EnterpriseMessagingGateway.Api
{
    public static class SerilogConfig
    {
        public static void LoggerConfig()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}