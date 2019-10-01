using GraphQL;
using GraphQLTest.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.Schema
{
    public class AppSchema : GraphQL.Types.Schema
    {
        public AppSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<PropertyQuery>();
        }
    }
}
