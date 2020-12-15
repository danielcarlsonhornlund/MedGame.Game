// -------------------------------------------------------------------------------------------------
// Copyright (c) MedGame Technologies AB. All rights reserved.
// -------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;

namespace MedGame.Dtos.IoTHub
{
    public class IoTHubDevice
    {
        public Device Device { get; set; }

        public List<Twin> Devices { get; set; }

        public string DeviceName { get; set; }

        public string Value { get; set; }

        public string ConnectionString { get; set; }


        public static IoTHubDevice ConvertToIoTHubDeviceObject(string json)
        {
            var ioTHubDeviceAsObject = JsonConvert.DeserializeObject<IoTHubDevice>(json);

            return ioTHubDeviceAsObject;
        }
    }
}
