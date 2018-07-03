using System.Collections.Generic;
using Matrix.Framework;

namespace Matrix.Web.Models
{
    public class HomeViewModel
    {
        public Dictionary<string, Health> Health { get; set; }

        public HomeViewModel()
        {
            Health = new Dictionary<string, Health>();
        }
    }
}