using ArtQuiz.Application.ReadModels;
using ArtQuiz.Domain.Quiz;
using OneOf;
using ReadModels;
using UseCases;

namespace ArtQuiz.Application.Queries.GetQuizAmountQuery
{
    public sealed partial class GetQuizAmountQuery
    {
        internal sealed class Handler : IQueryHandler<GetQuizAmountQuery,
            OneOf<Results.SuccessResult>>
        {
            private readonly IReadModel _readModel;
            private readonly IReadModelQueryExecutor _readModelExecutor;

            public Handler(IReadModel readModel, IReadModelQueryExecutor readModelExecutor)
            {
                _readModel = readModel;
                _readModelExecutor = readModelExecutor;
            }

            public async Task<OneOf<Results.SuccessResult>>
                Handle(GetQuizAmountQuery request, CancellationToken cancellationToken)
            {
                var amount = await _readModelExecutor
                    .CountAsync(_readModel.Quizzes
                        .Where(i => i.Application == request.ApplicationType)
                        .Where(i => request.IsAuthorized || i.Status == QuizStatus.QuizStatusEnum.Published)
                        .Where(i => i.UserId == request.UserId), cancellationToken);

                return Success(amount);
            }
        }
    }
}