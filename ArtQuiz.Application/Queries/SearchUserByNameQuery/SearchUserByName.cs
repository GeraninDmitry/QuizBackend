using ArtQuiz.Application.Enums;
using ArtQuiz.Domain;
using ArtQuiz.Domain.Quiz;
using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.SearchUsersByNameQuery
{
    public sealed partial class SearchUserByNameQuery : IQuery<OneOf<
        SearchUserByNameQuery.Results.SuccessResult, SearchUserByNameQuery.Results.NotFoundResult>>
    {
        public SearchUserByNameQuery(string userName)
        {
            UserName = userName;
        }

        private string UserName { get; set; }
    }
}