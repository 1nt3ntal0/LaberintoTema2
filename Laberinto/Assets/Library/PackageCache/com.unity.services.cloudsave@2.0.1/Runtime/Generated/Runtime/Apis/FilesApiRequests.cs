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
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Scripting;
using Unity.Services.CloudSave.Internal.Models;
using Unity.Services.CloudSave.Internal.Scheduler;
using Unity.Services.Authentication.Internal;

namespace Unity.Services.CloudSave.Internal.Files
{
    internal static class JsonSerialization
    {
        public static byte[] Serialize<T>(T obj)
        {
            return Encoding.UTF8.GetBytes(SerializeToString(obj));
        }

        public static string SerializeToString<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }

    /// <summary>
    /// FilesApiBaseRequest class
    /// </summary>
    [Preserve]
    internal class FilesApiBaseRequest
    {
        /// <summary>
        /// Helper function to add a provided key and value to the provided
        /// query params and to escape the values correctly if it is a URL.
        /// </summary>
        /// <param name="queryParams">A `List/<string/>` of the query parameters.</param>
        /// <param name="key">The key to be added.</param>
        /// <param name="value">The value to be added.</param>
        /// <returns>Returns a `List/<string/>` with the `key` and `value` added to the provided `queryParams`.</returns>
        [Preserve]
        public List<string> AddParamsToQueryParams(List<string> queryParams, string key, string value)
        {
            key = UnityWebRequest.EscapeURL(key);
            value = UnityWebRequest.EscapeURL(value);
            queryParams.Add($"{key}={value}");

            return queryParams;
        }

        /// <summary>
        /// Helper function to add a provided key and list of values to the
        /// provided query params and to escape the values correctly if it is a
        /// URL.
        /// </summary>
        /// <param name="queryParams">A `List/<string/>` of the query parameters.</param>
        /// <param name="key">The key to be added.</param>
        /// <param name="values">List of values to be added.</param>
        /// <param name="style">string for defining the style, currently unused.</param>
        /// <param name="explode">True if query params should be escaped and added separately.</param>
        /// <returns>Returns a `List/<string/>`</returns>
        [Preserve]
        public List<string> AddParamsToQueryParams(List<string> queryParams, string key, List<string> values, string style, bool explode)
        {
            if (explode)
            {
                foreach(var value in values)
                {
                    string escapedValue = UnityWebRequest.EscapeURL(value);
                    queryParams.Add($"{UnityWebRequest.EscapeURL(key)}={escapedValue}");
                }
            }
            else
            {
                string paramString = $"{UnityWebRequest.EscapeURL(key)}=";
                foreach(var value in values)
                {
                    paramString += UnityWebRequest.EscapeURL(value) + ",";
                }
                paramString = paramString.Remove(paramString.Length - 1);
                queryParams.Add(paramString);
            }

            return queryParams;
        }

        /// <summary>
        /// Helper function to add a provided key and value to the provided
        /// query params and to escape the values correctly if it is a URL.
        /// </summary>
        /// <param name="queryParams">A `List/<string/>` of the query parameters.</param>
        /// <param name="key">The key to be added.</param>
        /// <typeparam name="T">The type of the value to be added.</typeparam>
        /// <param name="value">The value to be added.</param>
        /// <returns>Returns a `List/<string/>`</returns>
        [Preserve]
        public List<string> AddParamsToQueryParams<T>(List<string> queryParams, string key, T value)
        {
            if (queryParams == null)
            {
                queryParams = new List<string>();
            }

            key = UnityWebRequest.EscapeURL(key);
            string valueString = UnityWebRequest.EscapeURL(value.ToString());
            queryParams.Add($"{key}={valueString}");
            return queryParams;
        }

        /// <summary>
        /// Constructs a string representing an array path parameter.
        /// </summary>
        /// <param name="pathParam">The list of values to convert to string.</param>
        /// <returns>String representing the param.</returns>
        [Preserve]
        public string GetPathParamString(List<string> pathParam)
        {
            string paramString = "";
            foreach(var value in pathParam)
            {
                paramString += UnityWebRequest.EscapeURL(value) + ",";
            }
            paramString = paramString.Remove(paramString.Length - 1);
            return paramString;
        }

        /// <summary>
        /// Constructs the body of the request based on IO stream.
        /// </summary>
        /// <param name="stream">The IO stream to use.</param>
        /// <returns>Byte array representing the body.</returns>
        public byte[] ConstructBody(System.IO.Stream stream)
        {
            if (stream != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    stream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
            return null;
        }

        /// <summary>
        /// Construct the request body based on string value.
        /// </summary>
        /// <param name="s">The input body.</param>
        /// <returns>Byte array representing the body.</returns>
        public byte[] ConstructBody(string s)
        {
            return System.Text.Encoding.UTF8.GetBytes(s);
        }

        /// <summary>
        /// Construct request body based on generic object.
        /// </summary>
        /// <param name="o">The object to use.</param>
        /// <returns>Byte array representing the body.</returns>
        public byte[] ConstructBody(object o)
        {
            return JsonSerialization.Serialize(o);
        }

        /// <summary>
        /// Generate an accept header.
        /// </summary>
        /// <param name="accepts">list of accepts objects.</param>
        /// <returns>The generated accept header.</returns>
        public string GenerateAcceptHeader(string[] accepts)
        {
            if (accepts.Length == 0)
            {
                return null;
            }
            for (int i = 0; i < accepts.Length; ++i)
            {
                if (string.Equals(accepts[i], "application/json", System.StringComparison.OrdinalIgnoreCase))
                {
                    return "application/json";
                }
            }
            return string.Join(", ", accepts);
        }

        private static readonly Regex JsonRegex = new Regex(@"application\/json(;\s)?((charset=utf8|q=[0-1]\.\d)(\s)?)*");

        /// <summary>
        /// Generate Content Type Header.
        /// </summary>
        /// <param name="contentTypes">The content types.</param>
        /// <returns>The Content Type Header.</returns>
        public string GenerateContentTypeHeader(string[] contentTypes)
        {
            if (contentTypes.Length == 0)
            {
                return null;
            }

            for(int i = 0; i < contentTypes.Length; ++i)
            {
                if (!string.IsNullOrWhiteSpace(contentTypes[i]) && JsonRegex.IsMatch(contentTypes[i]))
                {
                    return contentTypes[i];
                }
            }
            return contentTypes[0];
        }

        /// <summary>
        /// Generate multipart form file section.
        /// </summary>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="stream">The file stream to use.</param>
        /// <param name="contentType">The content type.</param>
        /// <returns>Returns a multipart form section.</returns>
        public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, System.IO.FileStream stream, string contentType)
        {
            return new MultipartFormFileSection(paramName, ConstructBody(stream), GetFileName(stream.Name), contentType);
        }

        /// <summary>
        /// Generate multipart form file section.
        /// </summary>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="stream">The IO stream to use.</param>
        /// <param name="contentType">The content type.</param>
        /// <returns>Returns a multipart form section.</returns>
        public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, System.IO.Stream stream, string contentType)
        {
            return new MultipartFormFileSection(paramName, ConstructBody(stream), Guid.NewGuid().ToString(), contentType);
        }

        private string GetFileName(string filePath)
        {
            return System.IO.Path.GetFileName(filePath);
        }
    }

    /// <summary>
    /// CreateUploadUrlRequest
    /// Create File Upload Location
    /// </summary>
    [Preserve]
    internal class CreateUploadUrlRequest : FilesApiBaseRequest
    {
        /// <summary>Accessor for projectId </summary>
        [Preserve]
        
        public string ProjectId { get; }
        /// <summary>Accessor for playerId </summary>
        [Preserve]
        
        public string PlayerId { get; }
        /// <summary>Accessor for filename </summary>
        [Preserve]
        
        public string Filename { get; }
        /// <summary>Accessor for fileDetails </summary>
        [Preserve]
        public Unity.Services.CloudSave.Internal.Models.FileDetails FileDetails { get; }
        
        string PathAndQueryParams;

        /// <summary>
        /// CreateUploadUrl Request Object.
        /// Create File Upload Location
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="playerId">The player ID supplied by the Authorization service.</param>
        /// <param name="filename">filename param</param>
        /// <param name="fileDetails">FileDetails param</param>
        [Preserve]
        public CreateUploadUrlRequest(string projectId, string playerId, string filename, Unity.Services.CloudSave.Internal.Models.FileDetails fileDetails = default(Unity.Services.CloudSave.Internal.Models.FileDetails))
        {
            
            ProjectId = projectId;
            
            PlayerId = playerId;
            
            Filename = filename;
            FileDetails = fileDetails;
            

            PathAndQueryParams = $"/v1/files/projects/{projectId}/players/{playerId}/items/{filename}";

            List<string> queryParams = new List<string>();

            if (queryParams.Count > 0)
            {
                PathAndQueryParams = $"{PathAndQueryParams}?{string.Join("&", queryParams)}";
            }
        }

        /// <summary>
        /// Helper function for constructing URL from request base path and
        /// query params.
        /// </summary>
        /// <param name="requestBasePath"></param>
        /// <returns></returns>
        public string ConstructUrl(string requestBasePath)
        {
            return requestBasePath + PathAndQueryParams;
        }

        /// <summary>
        /// Helper for constructing the request body.
        /// </summary>
        /// <returns>A list of IMultipartFormSection representing the request body.</returns>
        public byte[] ConstructBody()
        {
            if(FileDetails != null)
            {
                return ConstructBody(FileDetails);
            }
            return null;
        }

        /// <summary>
        /// Helper function for constructing the headers.
        /// </summary>
        /// <param name="accessToken">The auth access token to use.</param>
        /// <param name="operationConfiguration">The operation configuration to use.</param>
        /// <returns>A dictionary representing the request headers.</returns>
        public Dictionary<string, string> ConstructHeaders(IAccessToken accessToken,
            Configuration operationConfiguration = null)
        {
            var headers = new Dictionary<string, string>();
            if(!string.IsNullOrEmpty(accessToken.AccessToken))
            {
                headers.Add("authorization", "Bearer " + accessToken.AccessToken);
            }

            // Analytics headers
            headers.Add("Unity-Client-Version", Application.unityVersion);
            headers.Add("Unity-Client-Mode", Scheduler.EngineStateHelper.IsPlaying ? "play" : "edit");

            string[] contentTypes = {
                "application/json"
            };

            string[] accepts = {
                "application/json",
                "application/problem+json"
            };

            var acceptHeader = GenerateAcceptHeader(accepts);
            if (!string.IsNullOrEmpty(acceptHeader))
            {
                headers.Add("Accept", acceptHeader);
            }
            var httpMethod = "POST";
            var contentTypeHeader = GenerateContentTypeHeader(contentTypes);
            if (!string.IsNullOrEmpty(contentTypeHeader))
            {
                headers.Add("Content-Type", contentTypeHeader);
            }
            else if (httpMethod == "POST" || httpMethod == "PATCH")
            {
                headers.Add("Content-Type", "application/json");
            }


            // We also check if there are headers that are defined as part of
            // the request configuration.
            if (operationConfiguration != null && operationConfiguration.Headers != null)
            {
                foreach (var pair in operationConfiguration.Headers)
                {
                    headers[pair.Key] = pair.Value;
                }
            }

            return headers;
        }
    }
    /// <summary>
    /// DeleteFileRequest
    /// Delete File
    /// </summary>
    [Preserve]
    internal class DeleteFileRequest : FilesApiBaseRequest
    {
        /// <summary>Accessor for projectId </summary>
        [Preserve]
        
        public string ProjectId { get; }
        /// <summary>Accessor for playerId </summary>
        [Preserve]
        
        public string PlayerId { get; }
        /// <summary>Accessor for filename </summary>
        [Preserve]
        
        public string Filename { get; }
        /// <summary>Accessor for writeLock </summary>
        [Preserve]
        public string WriteLock { get; }
        
        string PathAndQueryParams;

        /// <summary>
        /// DeleteFile Request Object.
        /// Delete File
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="playerId">The player ID supplied by the Authorization service.</param>
        /// <param name="filename">filename param</param>
        /// <param name="writeLock">Enforces conflict checking when deleting a file. Omitting this field ignores write conflicts. When present, an error response will be returned if the writeLock in the request does not match the stored writeLock.</param>
        [Preserve]
        public DeleteFileRequest(string projectId, string playerId, string filename, string writeLock = default(string))
        {
            
            ProjectId = projectId;
            
            PlayerId = playerId;
            
            Filename = filename;
            WriteLock = writeLock;
            

            PathAndQueryParams = $"/v1/files/projects/{projectId}/players/{playerId}/items/{filename}";

            List<string> queryParams = new List<string>();

            if(!string.IsNullOrEmpty(WriteLock))
            {
                queryParams = AddParamsToQueryParams(queryParams, "writeLock", WriteLock);
            }
            if (queryParams.Count > 0)
            {
                PathAndQueryParams = $"{PathAndQueryParams}?{string.Join("&", queryParams)}";
            }
        }

        /// <summary>
        /// Helper function for constructing URL from request base path and
        /// query params.
        /// </summary>
        /// <param name="requestBasePath"></param>
        /// <returns></returns>
        public string ConstructUrl(string requestBasePath)
        {
            return requestBasePath + PathAndQueryParams;
        }

        /// <summary>
        /// Helper for constructing the request body.
        /// </summary>
        /// <returns>A list of IMultipartFormSection representing the request body.</returns>
        public byte[] ConstructBody()
        {
            return null;
        }

        /// <summary>
        /// Helper function for constructing the headers.
        /// </summary>
        /// <param name="accessToken">The auth access token to use.</param>
        /// <param name="operationConfiguration">The operation configuration to use.</param>
        /// <returns>A dictionary representing the request headers.</returns>
        public Dictionary<string, string> ConstructHeaders(IAccessToken accessToken,
            Configuration operationConfiguration = null)
        {
            var headers = new Dictionary<string, string>();
            if(!string.IsNullOrEmpty(accessToken.AccessToken))
            {
                headers.Add("authorization", "Bearer " + accessToken.AccessToken);
            }

            // Analytics headers
            headers.Add("Unity-Client-Version", Application.unityVersion);
            headers.Add("Unity-Client-Mode", Scheduler.EngineStateHelper.IsPlaying ? "play" : "edit");

            string[] contentTypes = {
            };

            string[] accepts = {
                "application/problem+json"
            };

            var acceptHeader = GenerateAcceptHeader(accepts);
            if (!string.IsNullOrEmpty(acceptHeader))
            {
                headers.Add("Accept", acceptHeader);
            }
            var httpMethod = "DELETE";
            var contentTypeHeader = GenerateContentTypeHeader(contentTypes);
            if (!string.IsNullOrEmpty(contentTypeHeader))
            {
                headers.Add("Content-Type", contentTypeHeader);
            }
            else if (httpMethod == "POST" || httpMethod == "PATCH")
            {
                headers.Add("Content-Type", "application/json");
            }


            // We also check if there are headers that are defined as part of
            // the request configuration.
            if (operationConfiguration != null && operationConfiguration.Headers != null)
            {
                foreach (var pair in operationConfiguration.Headers)
                {
                    headers[pair.Key] = pair.Value;
                }
            }

            return headers;
        }
    }
    /// <summary>
    /// GetFileUrlRequest
    /// Get file download URL
    /// </summary>
    [Preserve]
    internal class GetFileUrlRequest : FilesApiBaseRequest
    {
        /// <summary>Accessor for projectId </summary>
        [Preserve]
        
        public string ProjectId { get; }
        /// <summary>Accessor for playerId </summary>
        [Preserve]
        
        public string PlayerId { get; }
        /// <summary>Accessor for filename </summary>
        [Preserve]
        
        public string Filename { get; }
        string PathAndQueryParams;

        /// <summary>
        /// GetFileUrl Request Object.
        /// Get file download URL
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="playerId">The player ID supplied by the Authorization service.</param>
        /// <param name="filename">filename param</param>
        [Preserve]
        public GetFileUrlRequest(string projectId, string playerId, string filename)
        {
            
            ProjectId = projectId;
            
            PlayerId = playerId;
            
            Filename = filename;


            PathAndQueryParams = $"/v1/files/projects/{projectId}/players/{playerId}/items/{filename}";

            List<string> queryParams = new List<string>();

            if (queryParams.Count > 0)
            {
                PathAndQueryParams = $"{PathAndQueryParams}?{string.Join("&", queryParams)}";
            }
        }

        /// <summary>
        /// Helper function for constructing URL from request base path and
        /// query params.
        /// </summary>
        /// <param name="requestBasePath"></param>
        /// <returns></returns>
        public string ConstructUrl(string requestBasePath)
        {
            return requestBasePath + PathAndQueryParams;
        }

        /// <summary>
        /// Helper for constructing the request body.
        /// </summary>
        /// <returns>A list of IMultipartFormSection representing the request body.</returns>
        public byte[] ConstructBody()
        {
            return null;
        }

        /// <summary>
        /// Helper function for constructing the headers.
        /// </summary>
        /// <param name="accessToken">The auth access token to use.</param>
        /// <param name="operationConfiguration">The operation configuration to use.</param>
        /// <returns>A dictionary representing the request headers.</returns>
        public Dictionary<string, string> ConstructHeaders(IAccessToken accessToken,
            Configuration operationConfiguration = null)
        {
            var headers = new Dictionary<string, string>();
            if(!string.IsNullOrEmpty(accessToken.AccessToken))
            {
                headers.Add("authorization", "Bearer " + accessToken.AccessToken);
            }

            // Analytics headers
            headers.Add("Unity-Client-Version", Application.unityVersion);
            headers.Add("Unity-Client-Mode", Scheduler.EngineStateHelper.IsPlaying ? "play" : "edit");

            string[] contentTypes = {
            };

            string[] accepts = {
                "application/json",
                "application/problem+json"
            };

            var acceptHeader = GenerateAcceptHeader(accepts);
            if (!string.IsNullOrEmpty(acceptHeader))
            {
                headers.Add("Accept", acceptHeader);
            }
            var httpMethod = "GET";
            var contentTypeHeader = GenerateContentTypeHeader(contentTypes);
            if (!string.IsNullOrEmpty(contentTypeHeader))
            {
                headers.Add("Content-Type", contentTypeHeader);
            }
            else if (httpMethod == "POST" || httpMethod == "PATCH")
            {
                headers.Add("Content-Type", "application/json");
            }


            // We also check if there are headers that are defined as part of
            // the request configuration.
            if (operationConfiguration != null && operationConfiguration.Headers != null)
            {
                foreach (var pair in operationConfiguration.Headers)
                {
                    headers[pair.Key] = pair.Value;
                }
            }

            return headers;
        }
    }
    /// <summary>
    /// GetProjectDetailsRequest
    /// Get project details
    /// </summary>
    [Preserve]
    internal class GetProjectDetailsRequest : FilesApiBaseRequest
    {
        /// <summary>Accessor for projectId </summary>
        [Preserve]
        
        public string ProjectId { get; }
        string PathAndQueryParams;

        /// <summary>
        /// GetProjectDetails Request Object.
        /// Get project details
        /// </summary>
        /// <param name="projectId">Project ID</param>
        [Preserve]
        public GetProjectDetailsRequest(string projectId)
        {
            
            ProjectId = projectId;


            PathAndQueryParams = $"/v1/files/projects/{projectId}";

            List<string> queryParams = new List<string>();

            if (queryParams.Count > 0)
            {
                PathAndQueryParams = $"{PathAndQueryParams}?{string.Join("&", queryParams)}";
            }
        }

        /// <summary>
        /// Helper function for constructing URL from request base path and
        /// query params.
        /// </summary>
        /// <param name="requestBasePath"></param>
        /// <returns></returns>
        public string ConstructUrl(string requestBasePath)
        {
            return requestBasePath + PathAndQueryParams;
        }

        /// <summary>
        /// Helper for constructing the request body.
        /// </summary>
        /// <returns>A list of IMultipartFormSection representing the request body.</returns>
        public byte[] ConstructBody()
        {
            return null;
        }

        /// <summary>
        /// Helper function for constructing the headers.
        /// </summary>
        /// <param name="accessToken">The auth access token to use.</param>
        /// <param name="operationConfiguration">The operation configuration to use.</param>
        /// <returns>A dictionary representing the request headers.</returns>
        public Dictionary<string, string> ConstructHeaders(IAccessToken accessToken,
            Configuration operationConfiguration = null)
        {
            var headers = new Dictionary<string, string>();
            if(!string.IsNullOrEmpty(accessToken.AccessToken))
            {
                headers.Add("authorization", "Bearer " + accessToken.AccessToken);
            }

            // Analytics headers
            headers.Add("Unity-Client-Version", Application.unityVersion);
            headers.Add("Unity-Client-Mode", Scheduler.EngineStateHelper.IsPlaying ? "play" : "edit");

            string[] contentTypes = {
            };

            string[] accepts = {
                "application/json",
                "application/problem+json"
            };

            var acceptHeader = GenerateAcceptHeader(accepts);
            if (!string.IsNullOrEmpty(acceptHeader))
            {
                headers.Add("Accept", acceptHeader);
            }
            var httpMethod = "GET";
            var contentTypeHeader = GenerateContentTypeHeader(contentTypes);
            if (!string.IsNullOrEmpty(contentTypeHeader))
            {
                headers.Add("Content-Type", contentTypeHeader);
            }
            else if (httpMethod == "POST" || httpMethod == "PATCH")
            {
                headers.Add("Content-Type", "application/json");
            }


            // We also check if there are headers that are defined as part of
            // the request configuration.
            if (operationConfiguration != null && operationConfiguration.Headers != null)
            {
                foreach (var pair in operationConfiguration.Headers)
                {
                    headers[pair.Key] = pair.Value;
                }
            }

            return headers;
        }
    }
    /// <summary>
    /// ListFilesRequest
    /// List files
    /// </summary>
    [Preserve]
    internal class ListFilesRequest : FilesApiBaseRequest
    {
        /// <summary>Accessor for projectId </summary>
        [Preserve]
        
        public string ProjectId { get; }
        /// <summary>Accessor for playerId </summary>
        [Preserve]
        
        public string PlayerId { get; }
        /// <summary>Accessor for after </summary>
        [Preserve]
        public string After { get; }
        
        string PathAndQueryParams;

        /// <summary>
        /// ListFiles Request Object.
        /// List files
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="playerId">The player ID supplied by the Authorization service.</param>
        /// <param name="after">The filename after which to retrieve the list of files</param>
        [Preserve]
        public ListFilesRequest(string projectId, string playerId, string after = default(string))
        {
            
            ProjectId = projectId;
            
            PlayerId = playerId;
            After = after;
            

            PathAndQueryParams = $"/v1/files/projects/{projectId}/players/{playerId}/items";

            List<string> queryParams = new List<string>();

            if(!string.IsNullOrEmpty(After))
            {
                queryParams = AddParamsToQueryParams(queryParams, "after", After);
            }
            if (queryParams.Count > 0)
            {
                PathAndQueryParams = $"{PathAndQueryParams}?{string.Join("&", queryParams)}";
            }
        }

        /// <summary>
        /// Helper function for constructing URL from request base path and
        /// query params.
        /// </summary>
        /// <param name="requestBasePath"></param>
        /// <returns></returns>
        public string ConstructUrl(string requestBasePath)
        {
            return requestBasePath + PathAndQueryParams;
        }

        /// <summary>
        /// Helper for constructing the request body.
        /// </summary>
        /// <returns>A list of IMultipartFormSection representing the request body.</returns>
        public byte[] ConstructBody()
        {
            return null;
        }

        /// <summary>
        /// Helper function for constructing the headers.
        /// </summary>
        /// <param name="accessToken">The auth access token to use.</param>
        /// <param name="operationConfiguration">The operation configuration to use.</param>
        /// <returns>A dictionary representing the request headers.</returns>
        public Dictionary<string, string> ConstructHeaders(IAccessToken accessToken,
            Configuration operationConfiguration = null)
        {
            var headers = new Dictionary<string, string>();
            if(!string.IsNullOrEmpty(accessToken.AccessToken))
            {
                headers.Add("authorization", "Bearer " + accessToken.AccessToken);
            }

            // Analytics headers
            headers.Add("Unity-Client-Version", Application.unityVersion);
            headers.Add("Unity-Client-Mode", Scheduler.EngineStateHelper.IsPlaying ? "play" : "edit");

            string[] contentTypes = {
            };

            string[] accepts = {
                "application/json",
                "application/xml",
                "multipart/form-data",
                "text/html",
                "application/problem+json"
            };

            var acceptHeader = GenerateAcceptHeader(accepts);
            if (!string.IsNullOrEmpty(acceptHeader))
            {
                headers.Add("Accept", acceptHeader);
            }
            var httpMethod = "GET";
            var contentTypeHeader = GenerateContentTypeHeader(contentTypes);
            if (!string.IsNullOrEmpty(contentTypeHeader))
            {
                headers.Add("Content-Type", contentTypeHeader);
            }
            else if (httpMethod == "POST" || httpMethod == "PATCH")
            {
                headers.Add("Content-Type", "application/json");
            }


            // We also check if there are headers that are defined as part of
            // the request configuration.
            if (operationConfiguration != null && operationConfiguration.Headers != null)
            {
                foreach (var pair in operationConfiguration.Headers)
                {
                    headers[pair.Key] = pair.Value;
                }
            }

            return headers;
        }
    }
    /// <summary>
    /// SetupFileStorageRequest
    /// Provision File Storage
    /// </summary>
    [Preserve]
    internal class SetupFileStorageRequest : FilesApiBaseRequest
    {
        /// <summary>Accessor for projectId </summary>
        [Preserve]
        
        public string ProjectId { get; }
        /// <summary>Accessor for fileStorageSetupDetails </summary>
        [Preserve]
        public Unity.Services.CloudSave.Internal.Models.FileStorageSetupDetails FileStorageSetupDetails { get; }
        
        string PathAndQueryParams;

        /// <summary>
        /// SetupFileStorage Request Object.
        /// Provision File Storage
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="fileStorageSetupDetails">JSON containing 2 properties which are: organization ID and the project name</param>
        [Preserve]
        public SetupFileStorageRequest(string projectId, Unity.Services.CloudSave.Internal.Models.FileStorageSetupDetails fileStorageSetupDetails = default(Unity.Services.CloudSave.Internal.Models.FileStorageSetupDetails))
        {
            
            ProjectId = projectId;
            FileStorageSetupDetails = fileStorageSetupDetails;
            

            PathAndQueryParams = $"/v1/files/projects/{projectId}";

            List<string> queryParams = new List<string>();

            if (queryParams.Count > 0)
            {
                PathAndQueryParams = $"{PathAndQueryParams}?{string.Join("&", queryParams)}";
            }
        }

        /// <summary>
        /// Helper function for constructing URL from request base path and
        /// query params.
        /// </summary>
        /// <param name="requestBasePath"></param>
        /// <returns></returns>
        public string ConstructUrl(string requestBasePath)
        {
            return requestBasePath + PathAndQueryParams;
        }

        /// <summary>
        /// Helper for constructing the request body.
        /// </summary>
        /// <returns>A list of IMultipartFormSection representing the request body.</returns>
        public byte[] ConstructBody()
        {
            if(FileStorageSetupDetails != null)
            {
                return ConstructBody(FileStorageSetupDetails);
            }
            return null;
        }

        /// <summary>
        /// Helper function for constructing the headers.
        /// </summary>
        /// <param name="accessToken">The auth access token to use.</param>
        /// <param name="operationConfiguration">The operation configuration to use.</param>
        /// <returns>A dictionary representing the request headers.</returns>
        public Dictionary<string, string> ConstructHeaders(IAccessToken accessToken,
            Configuration operationConfiguration = null)
        {
            var headers = new Dictionary<string, string>();
            if(!string.IsNullOrEmpty(accessToken.AccessToken))
            {
                headers.Add("authorization", "Bearer " + accessToken.AccessToken);
            }

            // Analytics headers
            headers.Add("Unity-Client-Version", Application.unityVersion);
            headers.Add("Unity-Client-Mode", Scheduler.EngineStateHelper.IsPlaying ? "play" : "edit");

            string[] contentTypes = {
                "application/json"
            };

            string[] accepts = {
                "application/problem+json"
            };

            var acceptHeader = GenerateAcceptHeader(accepts);
            if (!string.IsNullOrEmpty(acceptHeader))
            {
                headers.Add("Accept", acceptHeader);
            }
            var httpMethod = "PUT";
            var contentTypeHeader = GenerateContentTypeHeader(contentTypes);
            if (!string.IsNullOrEmpty(contentTypeHeader))
            {
                headers.Add("Content-Type", contentTypeHeader);
            }
            else if (httpMethod == "POST" || httpMethod == "PATCH")
            {
                headers.Add("Content-Type", "application/json");
            }


            // We also check if there are headers that are defined as part of
            // the request configuration.
            if (operationConfiguration != null && operationConfiguration.Headers != null)
            {
                foreach (var pair in operationConfiguration.Headers)
                {
                    headers[pair.Key] = pair.Value;
                }
            }

            return headers;
        }
    }
}
