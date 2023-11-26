﻿using System.Text.Json.Serialization;

namespace Yorozuya.WpfApp.Common;

/// <summary>
/// API 响应类
/// </summary>
/// <typeparam name="TData">数据类型，在 Data 包含多个数据时使用Dictionary<string,JsonElement>以进一步反序列化 </typeparam>
public class ApiResponse<TData>
{
    [JsonPropertyName("code")]
    public long Code { get; set; }

    [JsonPropertyName("data")]
    public TData? Data { get; set; } = default;

    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;

    public bool IsSuccessStatusCode => Code >= 200 && Code <= 299;

    public void EnsureSuccessStatusCode()
    {
        if (!IsSuccessStatusCode)
            throw new ApiResponseException(Message);
    }
}