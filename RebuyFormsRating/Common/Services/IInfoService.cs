using System;

namespace RebuyFormsRating.Common.Services
{
    public interface IInfoService
    {
        string AppVersionName { get; }
        string AppVersionCode { get; }
        int AppBuildVersionCode { get; }
    }
}
