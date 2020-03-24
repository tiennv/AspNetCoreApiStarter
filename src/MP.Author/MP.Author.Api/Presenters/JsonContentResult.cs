﻿using Microsoft.AspNetCore.Mvc;

namespace MP.Author.Api.Presenters
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
