using GraphQL.Types;
using GraphQLTest.DataAcess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTest.GQLTypes.Payment
{
    public class PaymentType : ObjectGraphType<Database.Models.Payment>
    {
        public PaymentType(IPaymentRepository paymentRepository)
        {
            Field(x => x.Id);
            Field(x => x.Value);
            Field(x => x.DateCreated);
            Field(x => x.DateOverdue);
            Field(x => x.Paid);

            //simple example
            //Field<ListGraphType<PaymentType>>("payments", resolve: context => paymentRepository.GetAllForProperty(context.Source.Id));

            //in browser write this model
            //{
            //  properties
            //      {
            //          name,
            //          payments(last: 1 (any number)){
            //              id,
            //              value,
            //              dateCreated
            //          }
            //      }
            //}

            Field<ListGraphType<PaymentType>>("payments",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "last" }),
                resolve: context =>
                {
                    var lastItemsFilter = context.GetArgument<int?>("last");
                    return lastItemsFilter != null
                        ? paymentRepository.GetAllForProperty(context.Source.Id, lastItemsFilter.Value)
                        : paymentRepository.GetAllForProperty(context.Source.Id);
                });
        }
    }
}
