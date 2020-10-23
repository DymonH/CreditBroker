using System;

namespace Hlopov.Common.JWT.Models
{
    public sealed class JwtTokenResult
    {
        public string Token { get; internal set; }

        public TimeSpan Expires { get; set; }
    }
}