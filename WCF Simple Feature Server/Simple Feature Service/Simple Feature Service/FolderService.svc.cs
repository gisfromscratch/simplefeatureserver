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
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Hosting;
using System.Xml.Serialization;

namespace GIS.Services
{
    /// <summary>
    /// Represents a folder service.
    /// </summary>
    public class FolderService : IFolderService
    {
        public string GetDescription()
        {
            var xsltFilepath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"App_Data", @"ServiceDescriptionTemplate.xsl");
            return File.ReadAllText(xsltFilepath);

            var xmlSerializer = new XmlSerializer(typeof(FileInfo));
            var writer = new StringWriter();
            xmlSerializer.Serialize(writer, new FileInfo(xsltFilepath));
            return writer.ToString();
        }

        public string GetDescription(OutputFormat format)
        {
            var xsltFilepath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"App_Data", @"ServiceDescriptionTemplate.xsl");
            return File.ReadAllText(xsltFilepath);
        }
    }
}
