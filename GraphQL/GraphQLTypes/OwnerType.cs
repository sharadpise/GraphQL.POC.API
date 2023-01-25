using GraphQL.DataLoader;
using GraphQL.POC.API.Contracts;
using GraphQL.POC.API.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.POC.API.GraphQL.GraphQLTypes
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(IAccountRepository accountRepository, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the Owner Object.");
            Field(x => x.Name).Description("Name property from the Owner object.");
            Field(x => x.Address).Description("Account property from the Owner object.");
            Field<ListGraphType<AccountType>>(
                "accounts",
                resolve: context =>
                {
                    var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, Account>("GetAccountsByOwnerIds", accountRepository.GetAccountsByOwnerIds);
                    return loader.LoadAsync(context.Source.Id);
                });

        }
    }
}
