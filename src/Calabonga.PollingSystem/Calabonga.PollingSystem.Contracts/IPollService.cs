using Calabonga.OperationResults;

namespace Calabonga.PollingSystem.Contracts
{
    /// <summary>
    /// // Calabonga: update summary (2022-08-13 12:10 IPollService)
    /// </summary>
    public interface IPollService
    {
        /// <summary>
        /// // Calabonga: update summary (2022-08-13 12:10 IPollService)
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answers"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationResult<SaveResult>> SaveAsync(string question, List<string> answers, CancellationToken cancellationToken);
    }
}
