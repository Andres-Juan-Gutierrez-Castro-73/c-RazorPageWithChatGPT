using OpenAI_API;
using OpenAI_API.Completions;

namespace integrationChatGPT.Services
{
    public class AnswerGeneratorService : IAnswerGeneratorService
    {
        public async Task<string> GenerateAnswer(string prompt)
        {
            string apiKey = "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";
            string answer = string.Empty;

            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = prompt;
            completion.MaxTokens = 4000;
            var result = await openai.Completions.CreateCompletionAsync(completion);

            if (result != null)
            {
                foreach (var item in result.Completions)
                {
                    answer = item.Text;
                }
            }

            return answer;
        }
    }
}
