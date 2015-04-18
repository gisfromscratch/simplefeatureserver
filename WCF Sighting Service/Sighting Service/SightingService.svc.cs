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
using System.Data.Entity.Spatial;
using System.Globalization;
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
    public class SightingService : ISightingService
    {
        private const int WGS84 = 4326;

        public SightingDevice CreateDevice(string name)
        {
            using (var databaseModel = new GeodataEntities())
            {
                databaseModel.devices.Add(new devices { Name = name });
                databaseModel.SaveChanges();
                return new SightingDevice { Name = name };
            }
        }

        public Sighting.Services.Data.Sighting CreateSighting(double latitude, double longitude, DateTime date)
        {
            using (var databaseModel = new GeodataEntities())
            {
                var location = DbGeometry.PointFromText(string.Format(@"POINT ({0} {1})", longitude, latitude), WGS84);
                databaseModel.sightings.Add(new sightings { Shape = location, Date = date });
                databaseModel.SaveChanges();
                return new Sighting.Services.Data.Sighting { GeometryAsWellKnownText = location.AsText(), Date = date };
            }
        }

        public ICollection<SightingDevice> QueryAllDevices()
        {
            using (var databaseModel = new GeodataEntities())
            {
                var devices = from device in databaseModel.devices orderby device.Name select new SightingDevice { Name = device.Name };
                return devices.ToList();
            }
        }

        public ICollection<string> QueryAllSightings()
        {
            using (var databaseModel = new GeodataEntities())
            {
                var geometries = from sighting in databaseModel.sightings orderby sighting.Date select sighting.Shape.AsText();
                return geometries.ToList();
            }
        }
     }
}
