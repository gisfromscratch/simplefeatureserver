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
using GIS.Services.Testing.FolderService;

namespace GIS.Services.Testing.Fixtures
{
    /// <summary>
    /// Tests accessing the folder services.
    /// </summary>
    [TestClass]
    public class FolderServiceFixture
    {
        [TestMethod]
        public void TestGetDescription()
        {
            var folderService = new FolderServiceClient(@"BasicHttpBinding_IFolderService");
            var description = folderService.Get();
            Assert.IsNotNull(description, @"The description must not be null!");
            Assert.IsFalse(string.IsNullOrEmpty(description), @"The description must not be empty!");
        }
    }
}
