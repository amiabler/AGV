﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgvClientWPF.AgvProductService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UniqueItemModel", Namespace="http://schemas.datacontract.org/2004/07/AgvServiceLib.DataModel")]
    [System.SerializableAttribute()]
    public partial class UniqueItemModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> BoxTypeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CheckCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> CreatedAtField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KNrField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KNrWithYearField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KskNrField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NrField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PartNrField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string QRField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> StateField;
        
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
        public System.Nullable<int> BoxTypeId {
            get {
                return this.BoxTypeIdField;
            }
            set {
                if ((this.BoxTypeIdField.Equals(value) != true)) {
                    this.BoxTypeIdField = value;
                    this.RaisePropertyChanged("BoxTypeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CheckCode {
            get {
                return this.CheckCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CheckCodeField, value) != true)) {
                    this.CheckCodeField = value;
                    this.RaisePropertyChanged("CheckCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> CreatedAt {
            get {
                return this.CreatedAtField;
            }
            set {
                if ((this.CreatedAtField.Equals(value) != true)) {
                    this.CreatedAtField = value;
                    this.RaisePropertyChanged("CreatedAt");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string KNr {
            get {
                return this.KNrField;
            }
            set {
                if ((object.ReferenceEquals(this.KNrField, value) != true)) {
                    this.KNrField = value;
                    this.RaisePropertyChanged("KNr");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string KNrWithYear {
            get {
                return this.KNrWithYearField;
            }
            set {
                if ((object.ReferenceEquals(this.KNrWithYearField, value) != true)) {
                    this.KNrWithYearField = value;
                    this.RaisePropertyChanged("KNrWithYear");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string KskNr {
            get {
                return this.KskNrField;
            }
            set {
                if ((object.ReferenceEquals(this.KskNrField, value) != true)) {
                    this.KskNrField = value;
                    this.RaisePropertyChanged("KskNr");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nr {
            get {
                return this.NrField;
            }
            set {
                if ((object.ReferenceEquals(this.NrField, value) != true)) {
                    this.NrField = value;
                    this.RaisePropertyChanged("Nr");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PartNr {
            get {
                return this.PartNrField;
            }
            set {
                if ((object.ReferenceEquals(this.PartNrField, value) != true)) {
                    this.PartNrField = value;
                    this.RaisePropertyChanged("PartNr");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string QR {
            get {
                return this.QRField;
            }
            set {
                if ((object.ReferenceEquals(this.QRField, value) != true)) {
                    this.QRField = value;
                    this.RaisePropertyChanged("QR");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> State {
            get {
                return this.StateField;
            }
            set {
                if ((this.StateField.Equals(value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AgvProductService.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/CreateUniqItem", ReplyAction="http://tempuri.org/IProductService/CreateUniqItemResponse")]
        AGVCenterLib.Model.Message.ResultMessage CreateUniqItem(AgvClientWPF.AgvProductService.UniqueItemModel item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/FindUniqItemByNr", ReplyAction="http://tempuri.org/IProductService/FindUniqItemByNrResponse")]
        AgvClientWPF.AgvProductService.UniqueItemModel FindUniqItemByNr(string nr);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : AgvClientWPF.AgvProductService.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<AgvClientWPF.AgvProductService.IProductService>, AgvClientWPF.AgvProductService.IProductService {
        
        public ProductServiceClient() {
        }
        
        public ProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AGVCenterLib.Model.Message.ResultMessage CreateUniqItem(AgvClientWPF.AgvProductService.UniqueItemModel item) {
            return base.Channel.CreateUniqItem(item);
        }
        
        public AgvClientWPF.AgvProductService.UniqueItemModel FindUniqItemByNr(string nr) {
            return base.Channel.FindUniqItemByNr(nr);
        }
    }
}