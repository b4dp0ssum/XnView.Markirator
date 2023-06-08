using XnView.Markirator.App.XnView.Entities;

namespace XnView.Markirator.App.XnView.DataAccess.Repositories.Interfaces;

internal interface IXnViewFoldersRepository
{
    XnViewFolder[] Find(IEnumerable<string> filePathList);
}