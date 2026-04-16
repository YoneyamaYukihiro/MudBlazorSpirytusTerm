using MudBlazor.Services;
using MudBlazorSpirytusTerm.Components;
using MudBlazorSpirytusTerm.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ITfMessageClient, ActiveMqMessageClient>();

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
builder.Services.AddScoped<BatchLotService>();
builder.Services.AddScoped<ProcessStepLotListService>();
builder.Services.AddScoped<LotDetailService>();
builder.Services.AddScoped<LotHoldService>();
builder.Services.AddScoped<LotCommentService>();
builder.Services.AddScoped<McGroupLotListService>();
builder.Services.AddScoped<LotSeqChangeService>();
builder.Services.AddScoped<SectionPriorityService>();
builder.Services.AddScoped<TimeRestrictFlowService>();
builder.Services.AddScoped<LotSkipStepService>();
builder.Services.AddScoped<LotOutService>();
builder.Services.AddScoped<LotStepBackService>();
builder.Services.AddScoped<LotThrowinSubstrateService>();
builder.Services.AddScoped<LotCompositionService>();
builder.Services.AddScoped<LotDivideService>();
builder.Services.AddScoped<LotThrowRsvExtService>();
builder.Services.AddScoped<EquipmentDataService>();
builder.Services.AddScoped<AbnormalProcessingService>();
builder.Services.AddScoped<CfLotCompositionService>();
builder.Services.AddScoped<LotRemeasureService>();
builder.Services.AddScoped<WfChipStatusChangeService>();
builder.Services.AddScoped<CfkiWorkEndService>();
builder.Services.AddScoped<OppositeSubstrateService>();
builder.Services.AddScoped<DummyLoadUnloadService>();
builder.Services.AddScoped<RecipeSettingChangeService>();
builder.Services.AddScoped<SpecialFlowService>();
builder.Services.AddScoped<TpalBondingService>();

builder.Services.AddScoped<InventoryTransferService>();
builder.Services.AddScoped<ThrowInTransferListService>();
builder.Services.AddScoped<PartsHistoryService>();
builder.Services.AddScoped<TransportModeService>();
builder.Services.AddScoped<ReticleManualTransferService>();
builder.Services.AddScoped<CmpMaintenanceService>();
builder.Services.AddScoped<PrOrderService>();
builder.Services.AddScoped<PhotoFbParameterService>();
builder.Services.AddScoped<PhotoFbDataService>();
builder.Services.AddScoped<EquipmentMaterialService>();
builder.Services.AddScoped<LotProcessOrderService>();
builder.Services.AddScoped<HistoricalInventoryService>();
builder.Services.AddScoped<MaintenanceRecordService>();
builder.Services.AddScoped<PartsReceiptService>();
builder.Services.AddScoped<PartsManagementService>();
builder.Services.AddScoped<ActionReservationService>();
builder.Services.AddScoped<SorterTransferService>();
builder.Services.AddScoped<LotInfoChangeService>();
builder.Services.AddScoped<BatchLotInfoChangeService>();
builder.Services.AddScoped<MkLotCompositionService>();
builder.Services.AddScoped<JigManagementService>();
builder.Services.AddScoped<MkLotCompositionCfService>();
builder.Services.AddScoped<JigWaferSetService>();
builder.Services.AddScoped<InorganicSubstrateBondingService>();
builder.Services.AddScoped<TeosFbService>();
builder.Services.AddScoped<FrUsageHistoryService>();
builder.Services.AddScoped<GrbAttributeService>();
builder.Services.AddScoped<GrbLotDivideService>();
builder.Services.AddScoped<AldBatchReceiveService>();
builder.Services.AddScoped<AldWorkStartService>();
builder.Services.AddScoped<AldLotThrowInService>();
builder.Services.AddScoped<ATrayManagementService>();
builder.Services.AddScoped<ACarrierManagementService>();
builder.Services.AddScoped<OdfReservationService>();
builder.Services.AddScoped<VaporDepositionMaskService>();

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
