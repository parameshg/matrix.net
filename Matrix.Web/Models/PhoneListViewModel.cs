using System;
using System.Collections.Generic;
using Matrix.Agent.Postman.Model;
using Matrix.Agent.Registry.Model;

namespace Matrix.Web.Models
{
    public class PhoneListViewModel
    {
        public Guid Application { get; set; }

        public IList<Application> Applications { get; set; }

        public IList<PhoneMessageMetadata> Messages { get; set; }
    }
}