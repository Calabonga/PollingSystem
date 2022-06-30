using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace Calabonga.PollingSystem.BlazorLib
{
    public class PollCreateModel : ComponentBase
    {
        public List<string> Errors { get; } = new();

        public string? QuestionText { get; set; } = "Какая сегодня погода, на ваш взгляд?";

        public List<AnswerInput> Answers { get; set; } = new()
        {
            new AnswerInput{Text = "Нормальная"},
            new AnswerInput{Text = "Хорошая"},
            new AnswerInput{Text = "Отличная"},
            new AnswerInput{Text = "Плохая"},
            new AnswerInput{Text = "Хрень"}
        };

        public bool IsValid =>
            !string.IsNullOrEmpty(QuestionText)
            && QuestionText.Length > 0
            && Answers.Count is > 1 and <= 10;

        protected void AddAnswer()
        {
            Answers.Add(new AnswerInput());
        }

        protected void DeleteAnswer(AnswerInput item)
        {
            Answers.Remove(item);
        }

        protected void Validate()
        {
            var errors = ValidatePoll();

            var validationResults = errors.ToList();
            if (validationResults.Any())
            {
                Errors.AddRange(validationResults.Select(x => x.ErrorMessage).ToList()!);
            }
            else
            {
                Errors.Clear();
            }
        }

        protected Task SaveAnswer()
        {
            Validate();
            if (Errors.Any())
            {
                return Task.CompletedTask;
            }
            
            // save to DB

            return Task.CompletedTask;
        }

        private IEnumerable<ValidationResult> ValidatePoll()
        {
            if (string.IsNullOrWhiteSpace(QuestionText))
            {
                yield return new ValidationResult("Не задан вопрос для голосования.");
            }

            if (QuestionText is {Length: > 512 or < 3})
            {
                yield return new ValidationResult("Длина вопроса для голосования должна быть более 3 и менее 512 символов.");
            }

            if (!Answers.Any())
            {
                yield return new ValidationResult("Не заданы ответы для голосования.");
                yield break;
            }

            if (Answers.Count < 2)
            {
                yield return new ValidationResult("Требуется более двух вариантов ответа.");
            }

            if (Answers.Count > 10)
            {
                yield return new ValidationResult("Можно задать не более 10 вариантов ответа.");
            }

            foreach (var answer in Answers)
            {
                if (string.IsNullOrWhiteSpace(answer.Text))
                {
                    yield return new ValidationResult("Не задан текст ответа.");
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(answer.Text) && answer.Text.Length > 512)
                {
                    yield return new ValidationResult($"\"{answer.Text}\" слишком длинный. Можно не более 512 символов.");
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(answer.Text) && answer.Text.Length < 3)
                {
                    yield return new ValidationResult($"\"{answer.Text}\" слишком короткий. Можно не менее 3 символов.");
                }
            }

        }
    }

    public class AnswerInput
    {
        public string? Text { get; set; }

    }

}
