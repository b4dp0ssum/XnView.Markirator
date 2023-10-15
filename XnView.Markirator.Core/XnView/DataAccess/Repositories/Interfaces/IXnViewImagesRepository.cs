using XnView.Markirator.Core.XnView.Entities;

namespace XnView.Markirator.Core.XnView.DataAccess.Repositories.Interfaces;

internal interface IXnViewImagesRepository
{
    XnViewImage[] Find(IEnumerable<int> xnViewFolderIds);
}