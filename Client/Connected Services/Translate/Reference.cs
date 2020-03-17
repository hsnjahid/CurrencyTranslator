﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NumberToWord.Client.Translate {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Translate.ITranslateService")]
    public interface ITranslateService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITranslateService/ToWord", ReplyAction="http://tempuri.org/ITranslateService/ToWordResponse")]
        string ToWord(double number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITranslateService/ToWord", ReplyAction="http://tempuri.org/ITranslateService/ToWordResponse")]
        System.Threading.Tasks.Task<string> ToWordAsync(double number);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITranslateServiceChannel : NumberToWord.Client.Translate.ITranslateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TranslateServiceClient : System.ServiceModel.ClientBase<NumberToWord.Client.Translate.ITranslateService>, NumberToWord.Client.Translate.ITranslateService {
        
        public TranslateServiceClient() {
        }
        
        public TranslateServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TranslateServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TranslateServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TranslateServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ToWord(double number) {
            return base.Channel.ToWord(number);
        }
        
        public System.Threading.Tasks.Task<string> ToWordAsync(double number) {
            return base.Channel.ToWordAsync(number);
        }
    }
}
