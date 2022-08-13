using Calabonga.OperationResults;
using Calabonga.PollingSystem.Contracts;
using Calabonga.PollingSystem.Entities;
using Calabonga.UnitOfWork;

namespace Calabonga.PollingSystem.Web.Infrastructure
{
    public class PollService : IPollService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PollService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<SaveResult>> SaveAsync(string question, List<string> answers, CancellationToken cancellationToken)
        {
            var answersForPoll = answers.Select(x => new Answer(Guid.Empty, x)).ToList();
            var poll = new Poll(question, answersForPoll);

            var repository = _unitOfWork.GetRepository<Poll>();

            await repository.InsertAsync(poll, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            var operation = OperationResult.CreateResult<SaveResult>();
            
            if (!_unitOfWork.LastSaveChangesResult.IsOk)
            {
                operation.AddError(_unitOfWork.LastSaveChangesResult.Exception ?? new InvalidOperationException());
                return operation;
            }

            operation.Result = new SaveResult
            {
                TotalPolls = await repository.CountAsync(null, cancellationToken)
            };
            operation.AddSuccess("Успешно сохранено новое голосование");
            return operation;

        }
    }
}
