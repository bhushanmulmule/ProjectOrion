using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Domain.SeedWork
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class Entity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTimeOffset CreatedAt { get; set; } = SystemClock.Now;
    }
}
