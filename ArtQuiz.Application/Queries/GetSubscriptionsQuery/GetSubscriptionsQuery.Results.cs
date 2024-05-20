using ArtQuiz.Application.AppModels;
using ArtQuiz.Application.ReadModels.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtQuiz.Application.Queries.GetSubscriptionsQuery
{
    public sealed partial class GetSubscriptionsQuery
    {
        private static Results.SuccessResult Success(SubscriptionAppModel[] subscriptions) => new(subscriptions);

        public static class Results
        {
            public sealed class SuccessResult { public SuccessResult(SubscriptionAppModel[] subscriptions) => Subscriptions = subscriptions; public SubscriptionAppModel[] Subscriptions { get; } }
        }
    }
}
