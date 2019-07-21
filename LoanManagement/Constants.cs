using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement
{
    public class Constants
    {
        public class AppConfiguration
        {
            public static readonly string DataStore = "DataStore";
        }

        public class Http
        {
            public static readonly string ContentType = "application/problem+json";
            public static readonly string ContentLanguage = "en";
        }

        public class Message
        {
            public static readonly string TitleGetObjects = "Get all objects";
            public static readonly string TitleGetObjectById = "Get object by Id";
            public static readonly string TitleCreateObject = "Create object";
            public static readonly string TitleUpdateObject = "Update object";

            public static readonly string ValidationFailed = "Object validation failed";
            public static readonly string ValidationFailedIdShouldBeNull = "Id is auto-generated key and should not be sent by creating an object";
            public static readonly string ValidationFailedIdsShouldMatch = "Id in query parameter and body of the request must match";

        }
    }
}
