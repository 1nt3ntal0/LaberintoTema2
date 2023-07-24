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
using Unity.Services.CloudCode.Internal.Http;



namespace Unity.Services.CloudCode.Internal.Models
{
    /// <summary>
    /// RunModuleArguments model
    /// </summary>
    [Preserve]
    [DataContract(Name = "RunModuleArguments")]
    internal class RunModuleArguments
    {
        /// <summary>
        /// Creates an instance of RunModuleArguments.
        /// </summary>
        /// <param name="@params">Object containing key-value pairs that map on to the parameter definitions for the given function of a module. Parameters are required according to the arguments defined in the function signature. </param>
        [Preserve]
        public RunModuleArguments(object @params)
        {
            Params = (IDeserializable) JsonObject.GetNewJsonObjectResponse(@params);
        }

        /// <summary>
        /// Object containing key-value pairs that map on to the parameter definitions for the given function of a module. Parameters are required according to the arguments defined in the function signature. 
        /// </summary>
        [Preserve][JsonConverter(typeof(JsonObjectConverter))]
        [DataMember(Name = "params", IsRequired = true, EmitDefaultValue = true)]
        public IDeserializable Params{ get; }
    
        /// <summary>
        /// Formats a RunModuleArguments into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Params != null)
            {
                serializedModel += "params," + Params.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a RunModuleArguments as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            return dictionary;
        }
    }
}