using XnView.Markirator.Core.Common.Entities;
using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.Common.UseCases;
using XnView.Markirator.Core.Common.UseCases.Interfaces;
using XnView.Markirator.Core.UseCases.EvaluateTags.Entities;
using XnView.Markirator.Core.UseCases.EvaluateTags.Tools.Interfaces;
using XnView.Markirator.Core.XnView.Settings;
using XnView.Markirator.Core.XnView.Tools.TagsActualization;
using XnView.Markirator.Core.XnView.Tools.TagsAssigning;

namespace XnView.Markirator.Core.UseCases.Common;

internal abstract class BaseAssignTags_UseCase<TInput> : UseCase<TInput, ResultInfo>,
    IUseCase<TInput>
{
    private readonly IXnViewSettings _xnViewSettings;
    private readonly IXnViewTagsActualizer _xnViewTagsActualizer;
    private readonly IXnViewFoldersFiller _xnViewFoldersFiller;
    private readonly IXnViewImagesFiller _xnViewImagesFiller;
    private readonly IRequiredXnViewTagsFiller _requiredXnViewTagsFiller;
    private readonly IXnViewImageTagsSetter _xnViewImageTagsSetter;

    // CTOR
    public BaseAssignTags_UseCase(
        IOutputWriter outputWriter,
        IXnViewSettings xnViewSettings,
        IXnViewTagsActualizer xnViewTagsActualizer,
        IXnViewFoldersFiller xnViewFoldersFiller,
        IXnViewImagesFiller xnViewImagesFiller,
        IRequiredXnViewTagsFiller requiredXnViewTagsFiller,
        IXnViewImageTagsSetter xnViewImageTagsSetter) : base(outputWriter)
    {
        _xnViewSettings = xnViewSettings ?? throw new ArgumentNullException(nameof(xnViewSettings));
        _xnViewTagsActualizer = xnViewTagsActualizer ?? throw new ArgumentNullException(nameof(xnViewTagsActualizer));
        _xnViewFoldersFiller = xnViewFoldersFiller ?? throw new ArgumentNullException(nameof(xnViewFoldersFiller));
        _xnViewImagesFiller = xnViewImagesFiller ?? throw new ArgumentNullException(nameof(xnViewImagesFiller));
        _requiredXnViewTagsFiller = requiredXnViewTagsFiller ?? throw new ArgumentNullException(nameof(requiredXnViewTagsFiller));
        _xnViewImageTagsSetter = xnViewImageTagsSetter ?? throw new ArgumentNullException(nameof(xnViewImageTagsSetter));
    }

    protected override ResultInfo Handle(TInput input)
    {
        var imageTagsInfoArr = LoadImageTagsInfo(input);

        var assignImageTagsInfoArr = imageTagsInfoArr
            .Select(x => AssignImageTagsInfo.GetInstance(x, _xnViewSettings.ImagesCatalogPath))
            .ToArray();

        var tagsDict = _xnViewTagsActualizer.UpdateAndLoadTags(imageTagsInfoArr);

        _xnViewFoldersFiller.FillFolders(assignImageTagsInfoArr);
        _xnViewImagesFiller.FillImages(assignImageTagsInfoArr);
        _requiredXnViewTagsFiller.FillRequiredXnViewTags(assignImageTagsInfoArr, tagsDict);

        _xnViewImageTagsSetter.SetTags(assignImageTagsInfoArr);

        return new ResultInfo();
    }

    protected abstract ImageTagsInfo[] LoadImageTagsInfo(TInput input);
}
