using GraphQL.POC.API.Contracts;
using GraphQL.POC.API.Entities;
using GraphQL.POC.API.GraphQL.GraphQLTypes;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.POC.API.GraphQL.GraphQLQueries
{
    public class AppMutation:ObjectGraphType
    {
        public AppMutation(IOwnerRepository ownerRepository)
        {
            Field<OwnerType>(
                "createOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name="owner"}),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    return ownerRepository.CreateOwner(owner);
                });

            Field<OwnerType>(
                "updateOwner",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    var dbOwner = ownerRepository.GetById(ownerId);
                    if (dbOwner == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                        return null;
                    }

                    return ownerRepository.UpdateOwner(dbOwner, owner);
                });

            Field<StringGraphType>(
                "deleteOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: context=>
                {
                    var owner = ownerRepository.GetById(context.GetArgument<Guid>("ownerId"));
                    if (owner == null) 
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                        return null;
                    }
                    ownerRepository.DeleteOwner(owner);
                    return $"The owner with the Id: " + owner.Id + " has been deleted.";
                });
        }
    }
}
