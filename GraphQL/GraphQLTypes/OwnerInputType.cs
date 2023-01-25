﻿using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.POC.API.GraphQL.GraphQLTypes
{
    public class OwnerInputType: InputObjectGraphType
    {
        public OwnerInputType()
        {
            Name = "ownerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("address");
        }
    }
}
