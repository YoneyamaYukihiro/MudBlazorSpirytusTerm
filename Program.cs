using MudBlazor.Services;
using MudBlazorSpirytusTerm.Components;
using MudBlazorSpirytusTerm.Services;

var builder = WebApplication.CreateBuilder(args);

// ── MudBlazor ────────────────────────────────────────────────────
builder.Services.AddMudServices();

// ── Blazor ───────────────────────────────────────────────────────
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ── ActiveMQ / SPIRYTUS サービス ─────────────────────────────────
builder.Services.Configure<ActiveMqOptions>(
    builder.Configuration.GetSection(ActiveMqOptions.SectionName));

// SpirytusMqService は接続を保持するためシングルトン
builder.Services.AddSingleton<SpirytusMqService>();

// 各画面サービスはスコープ（リクエスト単位）
builder.Services.AddScoped<LotListService>();

// ─────────────────────────────────────────────────────────────────

var app = builder.Build();

// ── パイプライン ──────────────────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
