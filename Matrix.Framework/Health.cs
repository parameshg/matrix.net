using System.Collections.Generic;

namespace Matrix.Framework
{
    public class Health
    {
        public bool Healthy { get { return Errors.Count.Equals(0); } }

        public List<string> Errors { get; }

        public Health()
        {
            Errors = new List<string>();
        }
    }
}