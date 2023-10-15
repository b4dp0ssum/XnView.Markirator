using XnView.Markirator.Core.XnView.Entities;

namespace XnView.Markirator.Core.XnView.DataAccess.Repositories.Interfaces;

internal interface IXnViewFoldersRepository
{
    XnViewFolder[] Find(IEnumerable<string> filePathList);
}