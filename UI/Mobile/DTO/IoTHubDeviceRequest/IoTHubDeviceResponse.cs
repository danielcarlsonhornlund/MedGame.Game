// -------------------------------------------------------------------------------------------------
// Copyright (c) MedGame Technologies AB. All rights reserved.
// -------------------------------------------------------------------------------------------------

using Microsoft.Azure.Devices;

namespace MedGame.Dtos.IoTHub
{
    public class IoTHubDeviceResponse
    {
        public Device Device { get; set; }

        public string DeviceName { get; set; }

        public string Value { get; set; }

        public string ConnectionString { get; set; }
    }
}
