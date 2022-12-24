using ServicesRegistry.Enums;
using System;

namespace ServicesRegistry.Models
{
    public class ServiceDescription
    {
        public string Name { get; set; }

        public Service Service { get; set; }

        public DateTime Entered { get; set; }

        public long Port { get; set; }
    }
}
