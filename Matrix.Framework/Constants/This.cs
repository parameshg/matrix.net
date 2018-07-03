using System;

namespace Matrix.Framework.Constants
{
    public static class This
    {
        public static Guid Id { get { return Guid.Parse("12341234-1234-1234-1234-123412341234"); } }

        public static string Name { get { return "Matrix"; } }

        public static string Description { get { return "Microservices Chassis Framework and Boilerplate Modules"; } }
    }
}