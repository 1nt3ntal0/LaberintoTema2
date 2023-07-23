using System.Collections.Generic;

namespace Unity.Services.CloudCode.Authoring.Editor.Core.Model
{
    struct ScriptInfo : IScript
    {
        public ScriptName Name { get; }
        public List<CloudCodeParameter> Parameters { get; set; }
        public Language? Language { get; set; }
        public string Path => "";
        public string Body { get; set; }

        public ScriptInfo(string scriptName, string extension, Language language = Model.Language.JS)
        {
            Name = new ScriptName(scriptName + extension);
            Language = language;
            Parameters = new List<CloudCodeParameter>();
            Body = "";
        }

        public ScriptInfo(ScriptName scriptName, Language language = Model.Language.JS)
        {
            Name = scriptName;
            Language = language;
            Parameters = new List<CloudCodeParameter>();
            Body = "";
        }
    }
}
