using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;

internal interface IXnViewImagesRepository
{
    Task<XnViewImage[]> Find(IEnumerable<int> xnViewFolderIds);
}