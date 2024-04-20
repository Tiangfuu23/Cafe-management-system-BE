﻿
using System.Text.Json;

namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int Statuscode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
