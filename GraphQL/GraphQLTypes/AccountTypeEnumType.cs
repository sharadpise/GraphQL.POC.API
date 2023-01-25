using GraphQL.POC.API.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.POC.API.GraphQL.GraphQLTypes
{
    public class AccountTypeEnumType: EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Enum for Account types";
                
        }
    }
}
