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
using GIS.Services.Testing.FeatureService;

namespace GIS.Services.Testing.Fixtures
{
    /// <summary>
    /// Tests querying the feature service.
    /// </summary>
    [TestClass]
    public class FeatureServiceFixture
    {
        [TestMethod]
        public void TestQueryLayers()
        {
            var client = new FeatureServiceClient();
            var layers = client.QueryLayers();
            Assert.IsNotNull(layers, @"Layers must be initialized!");
        }

        [TestMethod]
        public void TestQueryFeatures()
        {
            var client = new FeatureServiceClient();
            var layers = client.QueryLayers();
            foreach (var layer in layers)
            {
                var features = client.QueryFeatures(layer);
                Assert.IsNotNull(features, @"Features must be initialized!");
            }
        }
    }
}
