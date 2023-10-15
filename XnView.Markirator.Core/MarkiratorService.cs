using Microsoft.Extensions.DependencyInjection;
using XnView.Markirator.Core.Common.UseCases;
using XnView.Markirator.Core.Common.UseCases.Interfaces;
using XnView.Markirator.Core.UseCases.EvaluateTags;
using XnView.Markirator.Core.UseCases.GetXnViewDbFolder;
using XnView.Markirator.Core.UseCases.InstallDeepDanbooru;
using XnView.Markirator.Core.UseCases.JsonImportTags;
using XnView.Markirator.Core.UseCases.UpdateSettings;

namespace XnView.Markirator.Core;

public class MarkiratorService : IMarkiratorService
{
    private readonly IServiceProvider _serviceProvider;

    // CTOR
    public MarkiratorService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void EvaluateTags(EvaluateTags_Options options)
        => Run<EvaluateTags_UseCase, EvaluateTags_Options>(_serviceProvider, options);

    public void JsonImportTags(JsonImportTags_Options options)
        => Run<JsonImportTags_UseCase, JsonImportTags_Options>(_serviceProvider, options);

    public void InstallDeepDanbooru(InstallDeepDanbooru_Options options)
        => Run<InstallDeepDanbooru_UseCase, InstallDeepDanbooru_Options>(_serviceProvider, options);

    public GetSettings_ResultInfo GetSettings(GetSettings_Options options)
        => Run<GetSettings_UseCase, GetSettings_Options, GetSettings_ResultInfo>(_serviceProvider, options);

    public void UpdateSettings(UpdateSettings_Options options)
        => Run<UpdateSettings_UseCase, UpdateSettings_Options>(_serviceProvider, options);

    /// <summary>
    /// Running UseCase with dependency initialization
    /// </summary>
    static void Run<TUseCase, TOptions>(IServiceProvider serviceProvider, TOptions options)
        where TUseCase : IUseCase<TOptions>
    {
        Run<TUseCase, TOptions, ResultInfo>(serviceProvider, options);
    }

    static TResult Run<TUseCase, TOptions, TResult>(IServiceProvider serviceProvider, TOptions options)
        where TUseCase : IUseCase<TOptions, TResult>
    {
        using IServiceScope scope = serviceProvider
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        var useCase = serviceProvider.GetRequiredService<TUseCase>();

        return useCase.Execute(options);
    }
}