using OneOf;
using UseCases;

namespace ArtQuiz.Application.Queries.CheckVerificationCodeQuery
{
    public sealed partial class CheckVerificationCodeQuery : IQuery<OneOf<
        CheckVerificationCodeQuery.Results.SuccessResult,
        CheckVerificationCodeQuery.Results.NotFoundResult,
        CheckVerificationCodeQuery.Results.ConflictResult>>
    {
        public CheckVerificationCodeQuery(string userName, string verificationCode)
        {
            UserName = userName;
            VerificationCode = verificationCode;
        }

        private string UserName { get; }
        private string VerificationCode { get; }
    }
}
