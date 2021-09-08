using System;

namespace BLL.BusinessModels
{
    public class FilterSearchModel
    {
        public TimeSpan? MinTestDuration { get; set; } = null;
        public TimeSpan? MaxTestDuration { get; set; } = null;
    }
}
