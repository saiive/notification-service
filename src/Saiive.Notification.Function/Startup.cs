﻿using System.Collections.Generic;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Saiive.Notification.Check;
using Saiive.Notification.Function;
using Saiive.Notifications.Messenger.Core;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Saiive.Notification.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddAlertCheckerFunction();
            builder.Services.AddMessengerCore();


            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}