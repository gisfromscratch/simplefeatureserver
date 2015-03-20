﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GIS.Services.Feature.Testing.FeatureService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FeatureLayer", Namespace="http://schemas.datacontract.org/2004/07/GIS.Datasource.Feature.Data")]
    [System.SerializableAttribute()]
    public partial class FeatureLayer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FeatureService.IFeatureService")]
    public interface IFeatureService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFeatureService/QueryLayers", ReplyAction="http://tempuri.org/IFeatureService/QueryLayersResponse")]
        GIS.Services.Feature.Testing.FeatureService.FeatureLayer[] QueryLayers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFeatureService/QueryLayers", ReplyAction="http://tempuri.org/IFeatureService/QueryLayersResponse")]
        System.Threading.Tasks.Task<GIS.Services.Feature.Testing.FeatureService.FeatureLayer[]> QueryLayersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFeatureServiceChannel : GIS.Services.Feature.Testing.FeatureService.IFeatureService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FeatureServiceClient : System.ServiceModel.ClientBase<GIS.Services.Feature.Testing.FeatureService.IFeatureService>, GIS.Services.Feature.Testing.FeatureService.IFeatureService {
        
        public FeatureServiceClient() {
        }
        
        public FeatureServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FeatureServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FeatureServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FeatureServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public GIS.Services.Feature.Testing.FeatureService.FeatureLayer[] QueryLayers() {
            return base.Channel.QueryLayers();
        }
        
        public System.Threading.Tasks.Task<GIS.Services.Feature.Testing.FeatureService.FeatureLayer[]> QueryLayersAsync() {
            return base.Channel.QueryLayersAsync();
        }
    }
}
