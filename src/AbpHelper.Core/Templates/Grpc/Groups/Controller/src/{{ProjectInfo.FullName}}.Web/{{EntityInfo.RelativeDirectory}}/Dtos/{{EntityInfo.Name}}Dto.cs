using System;
using System.ComponentModel;

namespace {{ ProjectInfo.FullName }}.{{EntityInfo.RelativeDirectory}}.Dtos
{
    [Serializable]
    public class {{EntityInfo.Name}}Dto
    {
        {{~ for prop in EntityInfo.Properties ~}}
        public {{ prop.Type }}  {{ prop.Name}}  { get; set; }
        {{~ end ~}}
    }
}