using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain
{
    public enum EventTypes
    {
        PageView, Event, VisitTime
    }

    public enum GoalTypes
    {
        Destination, Duration, PageCountPerSession, Event
    }

    public enum ExperimentTypes
    {
        Destination, Duration, PageCountPerSession, Event
    }

    public enum DurationTypes
    {
        ThreeDays, OneWeek, TwoWeeks
    }

    public enum FilterTypes
    {
        Equal, Contains, StartsWith
    }
    public enum SortOrder
    {
        None, Asc, Desc
    }
}
