using ServiceRegistry.Models;
using ServicesRegistry.Enums;
using System;

namespace ServicesRegistry.Models
{
    public class ServiceSettings : BaseEntity
    {
        public string Name { get; set; }

        public ServiceType Service { get; set; }

        public DateTime Entered { get; set; }

        public long Port { get; set; }
    }
}
