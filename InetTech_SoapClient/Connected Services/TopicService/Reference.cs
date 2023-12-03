﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TopicService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Entity", Namespace="http://eng.grammar/entity/topic")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TopicService.Level))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TopicService.Exercise))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TopicService.Topic))]
    public partial class Entity : object
    {
        
        private int idField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Level", Namespace="http://eng.grammar/entity/topic")]
    public partial class Level : TopicService.Entity
    {
        
        private string codeField;
        
        private string nameField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Exercise", Namespace="http://eng.grammar/entity/topic")]
    public partial class Exercise : TopicService.Entity
    {
        
        private string answerField;
        
        private string taskField;
        
        private TopicService.ExerciseType typeField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string answer
        {
            get
            {
                return this.answerField;
            }
            set
            {
                this.answerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string task
        {
            get
            {
                return this.taskField;
            }
            set
            {
                this.taskField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public TopicService.ExerciseType type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Topic", Namespace="http://eng.grammar/entity/topic")]
    public partial class Topic : TopicService.Entity
    {
        
        private string contentField;
        
        private TopicService.Exercise[] exercisesField;
        
        private TopicService.Level levelField;
        
        private string nameField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public TopicService.Exercise[] exercises
        {
            get
            {
                return this.exercisesField;
            }
            set
            {
                this.exercisesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public TopicService.Level level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ExerciseType", Namespace="http://eng.grammar/entity/topic")]
    public enum ExerciseType : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Translation = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TrueFalse = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CorrectTheMistake = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://eng.grammar/entity/topic", ConfigurationName="TopicService.ITopicService")]
    public interface ITopicService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://eng.grammar/entity/topic/ITopicService/AddTopic", ReplyAction="http://eng.grammar/entity/topic/ITopicService/AddTopicResponse")]
        System.Threading.Tasks.Task<int> AddTopicAsync(TopicService.Topic topic);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://eng.grammar/entity/topic/ITopicService/DeleteTopic", ReplyAction="http://eng.grammar/entity/topic/ITopicService/DeleteTopicResponse")]
        System.Threading.Tasks.Task<bool> DeleteTopicAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://eng.grammar/entity/topic/ITopicService/GetAllTopics", ReplyAction="http://eng.grammar/entity/topic/ITopicService/GetAllTopicsResponse")]
        System.Threading.Tasks.Task<TopicService.Topic[]> GetAllTopicsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://eng.grammar/entity/topic/ITopicService/GetTopicsByLevelId", ReplyAction="http://eng.grammar/entity/topic/ITopicService/GetTopicsByLevelIdResponse")]
        System.Threading.Tasks.Task<TopicService.Topic[]> GetTopicsByLevelIdAsync(int levelId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://eng.grammar/entity/topic/ITopicService/GetTopicById", ReplyAction="http://eng.grammar/entity/topic/ITopicService/GetTopicByIdResponse")]
        System.Threading.Tasks.Task<TopicService.Topic> GetTopicByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://eng.grammar/entity/topic/ITopicService/UpdateTopic", ReplyAction="http://eng.grammar/entity/topic/ITopicService/UpdateTopicResponse")]
        System.Threading.Tasks.Task<bool> UpdateTopicAsync(TopicService.Topic topic);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface ITopicServiceChannel : TopicService.ITopicService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class TopicServiceClient : System.ServiceModel.ClientBase<TopicService.ITopicService>, TopicService.ITopicService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TopicServiceClient() : 
                base(TopicServiceClient.GetDefaultBinding(), TopicServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ITopicService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TopicServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(TopicServiceClient.GetBindingForEndpoint(endpointConfiguration), TopicServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TopicServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TopicServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TopicServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TopicServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TopicServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<int> AddTopicAsync(TopicService.Topic topic)
        {
            return base.Channel.AddTopicAsync(topic);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteTopicAsync(int id)
        {
            return base.Channel.DeleteTopicAsync(id);
        }
        
        public System.Threading.Tasks.Task<TopicService.Topic[]> GetAllTopicsAsync()
        {
            return base.Channel.GetAllTopicsAsync();
        }
        
        public System.Threading.Tasks.Task<TopicService.Topic[]> GetTopicsByLevelIdAsync(int levelId)
        {
            return base.Channel.GetTopicsByLevelIdAsync(levelId);
        }
        
        public System.Threading.Tasks.Task<TopicService.Topic> GetTopicByIdAsync(int id)
        {
            return base.Channel.GetTopicByIdAsync(id);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateTopicAsync(TopicService.Topic topic)
        {
            return base.Channel.UpdateTopicAsync(topic);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITopicService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITopicService))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:7033/TopicService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return TopicServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ITopicService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return TopicServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ITopicService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ITopicService,
        }
    }
}
