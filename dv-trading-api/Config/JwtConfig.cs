﻿namespace dv_trading_api.Config
{
    public class JwtConfig
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience {  get; set; } = string.Empty;
        public string SigningKey { get; set; } = string.Empty;
    }
}
