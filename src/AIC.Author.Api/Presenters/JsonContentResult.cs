using Microsoft.AspNetCore.Mvc;

namespace AIC.Author.Presenters
{
  public sealed class JsonContentResult : ContentResult
  {
    public JsonContentResult()
    {
      ContentType = "application/json";
    }
  }
}
