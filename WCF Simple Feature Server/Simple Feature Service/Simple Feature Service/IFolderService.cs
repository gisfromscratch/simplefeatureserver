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
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GIS.Services
{
    /// <summary>
    /// Represents a folder service describing the available services and allows navigating through those services.
    /// </summary>
    [ServiceContract]
    public interface IFolderService
    {
        /// <summary>
        /// The description of this and all child services.
        /// </summary>
        /// <returns>The description using HTML format.</returns>
        [OperationContract(Name = @"Get")]
        /*[WebInvoke(Method = "GET", 
            UriTemplate = "/", 
            ResponseFormat = WebMessageFormat.Xml, 
            RequestFormat = WebMessageFormat.Xml, 
            BodyStyle = WebMessageBodyStyle.Bare)]*/
        [WebGet]
        string GetDescription();

        /// <summary>
        /// The description of this and all child services.
        /// </summary>
        /// <param name="format">The output format.</param>
        /// <returns>The description using the specified output format.</returns>
        [OperationContract]
        [WebGet]
        string GetDescription(OutputFormat format);
    }
}
