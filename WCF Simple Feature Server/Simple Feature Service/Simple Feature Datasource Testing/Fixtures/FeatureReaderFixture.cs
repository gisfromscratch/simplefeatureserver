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
using System.IO;

namespace GIS.Datasources.Testing.Fixtures
{
    /// <summary>
    /// Tests reading various kind of datasources.
    /// </summary>
    [TestClass]
    public class FeatureReaderFixture
    {
        /// <summary>
        /// Tests reading of shapefiles.
        /// </summary>
        [TestMethod]
        public void TestPointShapefileRead()
        {
            const string ShapefilePath = @"..\..\..\..\..\data\Points.shp";

            Assert.IsTrue(File.Exists(ShapefilePath), @"The shapefile does not exists!");

            var reader = new SimpleFeatureReader();
            var layers = reader.GetFeatureLayer(ShapefilePath);
            Assert.IsNotNull(layers, @"The layers were not intialized!");


        }

        /// <summary>
        /// Tests reading of OSM features.
        /// </summary>
        [TestMethod]
        public void TestOsmRead()
        {
            const string OsmFilePath = @"data\";
        }
    }
}
