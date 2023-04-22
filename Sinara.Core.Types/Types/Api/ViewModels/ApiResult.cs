namespace Sinara.Core.Types.Api.ViewModels
{
    public class ApiResult
    {
        public ErrorResult[] Errors { get; set; }
        public object Data { get; set; }
    }
}