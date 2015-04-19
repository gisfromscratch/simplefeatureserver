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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Testing.Web;

namespace Sighting.Services.Testing
{
    /// <summary>
    /// Tests the creation of sightings.
    /// </summary>
    [TestClass]
    public class SightingFixture
    {
        [TestMethod]
        public void TestCreateSighting()
        {
            var randomCoordinates = new Random();
            using (var sightingClient = new SightingServiceClient())
            {
                var latitude = randomCoordinates.Next(-90, 90) * randomCoordinates.NextDouble();
                var longitude = randomCoordinates.Next(-180, 180) * randomCoordinates.NextDouble();
                var sighting = sightingClient.CreateSighting(latitude, longitude, DateTime.Now);
                Assert.IsNotNull(sighting, @"Sighting must not be null!");
                Assert.IsFalse(string.IsNullOrEmpty(sighting.GeometryAsWellKnownText), @"The well known text representation must be set!");
            }
        }
    }
}
