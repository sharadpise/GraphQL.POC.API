using GraphQL.POC.API.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.POC.API.GraphQL.GraphQLTypes
{
    public class AccountType:ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property of the Account Object.");            
            Field(x => x.Description).Description("Description property of Account");            
            Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("Owner Id property of Account");
            Field<AccountTypeEnumType>("Type", "Enum for account type");
        }
    }
}
