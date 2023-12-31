//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.CloudCode.Authoring.Client.Http;



namespace Unity.Services.CloudCode.Authoring.Client.Models
{
    /// <summary>
    /// Information about the currently active version of the Script.
    /// </summary>
    [Preserve]
    [DataContract(Name = "cloud_code_get_script_response_activeScript")]
    internal class CloudCodeGetScriptResponseActiveScript
    {
        /// <summary>
        /// Information about the currently active version of the Script.
        /// </summary>
        /// <param name="code">The code of the active version of the Script</param>
        /// <param name="version">The version id of the active version of the Script</param>
        /// <param name="datePublished">Date time in ISO 8601 format. Null if there is no associated value.</param>
        [Preserve]
        public CloudCodeGetScriptResponseActiveScript(string code, int version, DateTime? datePublished)
        {
            Code = code;
            Version = version;
            DatePublished = datePublished;
        }

        /// <summary>
        /// The code of the active version of the Script
        /// </summary>
        [Preserve]
        [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = true)]
        public string Code{ get; }
        
        /// <summary>
        /// The version id of the active version of the Script
        /// </summary>
        [Preserve]
        [DataMember(Name = "version", IsRequired = true, EmitDefaultValue = true)]
        public int Version{ get; }
        
        /// <summary>
        /// Date time in ISO 8601 format. Null if there is no associated value.
        /// </summary>
        [Preserve]
        [DataMember(Name = "datePublished", IsRequired = true, EmitDefaultValue = true)]
        public DateTime? DatePublished{ get; }
    
        /// <summary>
        /// Formats a CloudCodeGetScriptResponseActiveScript into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Code != null)
            {
                serializedModel += "code," + Code + ",";
            }
            serializedModel += "version," + Version.ToString() + ",";
            if (DatePublished != null)
            {
                serializedModel += "datePublished," + DatePublished.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a CloudCodeGetScriptResponseActiveScript as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Code != null)
            {
                var codeStringValue = Code.ToString();
                dictionary.Add("code", codeStringValue);
            }
            
            var versionStringValue = Version.ToString();
            dictionary.Add("version", versionStringValue);
            
            if (DatePublished != null)
            {
                var datePublishedStringValue = DatePublished.ToString();
                dictionary.Add("datePublished", datePublishedStringValue);
            }
            
            return dictionary;
        }
    }
}
