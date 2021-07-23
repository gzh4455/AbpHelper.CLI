using System.Collections.Concurrent;
using Elsa.Persistence.Memory;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.AbpHelper.Core.Protobufs
{
    public class ProtobufTypMapper:ISingletonDependency
    {
        private readonly ConcurrentDictionary<string, string> _mapping = new ConcurrentDictionary<string, string>();

        public ProtobufTypMapper()
        {
            _mapping.TryAdd("int", "int32");
            _mapping.TryAdd("string", "string");
            _mapping.TryAdd("bool", "bool");
            _mapping.TryAdd("long", "int64");
            _mapping.TryAdd("double", "double");
            _mapping.TryAdd("float", "float");
            _mapping.TryAdd("uint", "uint32");
            _mapping.TryAdd("ulong", "uint64");
            _mapping.TryAdd("DateTime", "google.protobuf.Timestamp");
            _mapping.TryAdd("DateTime?", "google.protobuf.Timestamp");
            _mapping.TryAdd("TimeSpan", "google.protobuf.Duration");
            _mapping.TryAdd("DateTimeOffset", "google.protobuf.Timestamp");
            _mapping.TryAdd("bool?", "google.protobuf.BoolValue");
            _mapping.TryAdd("double?", "google.protobuf.DoubleValue");
            _mapping.TryAdd("float?", "google.protobuf.FloatValue");
            _mapping.TryAdd("int?", "google.protobuf.Int32Value");
            _mapping.TryAdd("long?", "google.protobuf.Int64Value");
            _mapping.TryAdd("uint?", "google.protobuf.UInt32Value");
            _mapping.TryAdd("ulong?", "google.protobuf.UInt64Value");
            _mapping.TryAdd("ulong?", "google.protobuf.UInt64Value");
        }

        public string Map(string type)
        {
            _mapping.TryGetValue(type, out string result);
             return result;
        }
    }
}