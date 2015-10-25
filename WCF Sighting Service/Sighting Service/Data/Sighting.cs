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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Sighting.Services.Data
{
    /// <summary>
    /// Represents a sighting having a geometry and a datetime.
    /// </summary>
    [DataContract]
    public class Sighting
    {
        /// <summary>
        /// The latitude of this sighting.
        /// </summary>
        [DataMember]
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude of this sighting.
        /// </summary>
        [DataMember]
        public double Longitude { get; set; }

        /// <summary>
        /// The well known text representation of the underlying geometry.
        /// </summary>
        [DataMember]
        public string GeometryAsWellKnownText { get; set; }

        /// <summary>
        /// The date when this sighting occured.
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }
    }
}