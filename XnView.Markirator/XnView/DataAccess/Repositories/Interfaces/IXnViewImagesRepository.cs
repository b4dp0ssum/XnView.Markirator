using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;

internal interface IXnViewImagesRepository
{
    XnViewImage[] Find(IEnumerable<int> xnViewFolderIds);
}