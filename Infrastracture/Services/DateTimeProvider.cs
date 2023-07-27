using DinnerApp.Application.Common;
using DinnerApp.Application.Common.Interfaces.Services;

namespace DinnerApp.Infrastracture.Services;

public class DateTimeProvider : IDateTimeProvider
{

    public DateTime UtcNow => DateTime.UtcNow;

}

