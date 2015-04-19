/*
 * Copyright 2015 Jan Tschada
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Sighting.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Sighting.Services
{
    /// <summary>
    /// Creates sightings from different devices.
    /// </summary>
    [ServiceContract]
    public interface ISightingService
    {
        /// <summary>
        /// Creates a new device.
        /// </summary>
        /// <param name="name">The name of the new device.</param>
        /// <returns>The newly created device.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = @"device/create", Method = @"PUT")]
        SightingDevice CreateDevice(string name);

        /// <summary>
        /// Creates a new sighting.
        /// </summary>
        /// <param name="latitude">The latitude where the sighting occured.</param>
        /// <param name="longitude">The longitude where the sighting occured.</param>
        /// <param name="date">The date when the sighting occured.</param>
        /// <returns>The newly created sighting.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = @"sighting/create", Method = @"PUT")]
        Sighting.Services.Data.Sighting CreateSighting(double latitude, double longitude, DateTime date);

        /// <summary>
        /// Queries all registered devices.
        /// </summary>
        /// <returns>The names of all registered devices.</returns>
        [OperationContract]
        [WebGet(UriTemplate = @"devices")]
        ICollection<SightingDevice> QueryAllDevices();

        /// <summary>
        /// Queries all sightings.
        /// </summary>
        /// <returns>The well known text representations of all sightings.</returns>
        [OperationContract]
        [WebGet(UriTemplate = @"sightings")]
        ICollection<string> QueryAllSightings();
    }
}
