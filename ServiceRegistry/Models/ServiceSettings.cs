using ServicesRegistry.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesRegistry.Models
{
    public class ServiceSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Port { get; set; }

        public string Name { get; set; }

        public string Host { get; set; }

        public ServiceType Service { get; set; }

        public DateTime Entered { get; set; }
    }
}
