using MudBlazor.Services;
using MudBlazorSpirytusTerm.Components;
using MudBlazorSpirytusTerm.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

if (OperatingSystem.IsWindows())
{
    builder.Services.AddScoped<ITfMessageClient, TfMessageClient>();
}
else
{
    builder.Services.AddScoped<ITfMessageClient, UnavailableTfMessageClient>();
}

builder.Services.AddScoped<LotListService>();
builder.Services.AddScoped<EquipmentService>();
builder.Services.AddScoped<TerminalService>();
builder.Services.AddScoped<LotActionService>();
builder.Services.AddScoped<WorkService>();
builder.Services.AddScoped<CarrierService>();
builder.Services.AddScoped<BatchService>();
builder.Services.AddScoped<EquipmentModeService>();
builder.Services.AddScoped<LotAttributeService>();
builder.Services.AddScoped<LotActionReservationService>();
builder.Services.AddScoped<LotDetailListService>();
builder.Services.AddScoped<LotTravelerVersionUpService>();
builder.Services.AddScoped<LotThrowRsvService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<BatchManagementService>();
builder.Services.AddScoped<ProcessStepLotListService>();
builder.Services.AddScoped<LotDetailService>();
builder.Services.AddScoped<LotHoldService>();
builder.Services.AddScoped<LotCommentService>();
builder.Services.AddScoped<McGroupLotListService>();
builder.Services.AddScoped<LotSeqChangeService>();

var app = builder.Build();

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
