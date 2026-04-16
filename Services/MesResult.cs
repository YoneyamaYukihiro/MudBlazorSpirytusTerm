namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// MES サーバー応答の共通結果ラッパー。
/// RET=1 時のエラーコード (MSG_CODE) とメッセージ (MSG) を保持する。
/// </summary>
/// <typeparam name="T">成功時のデータ型</typeparam>
public sealed record MesResult<T>(
    bool IsSuccess,
    T? Data = default,
    string ErrorCode = "",
    string ErrorMessage = ""
);
