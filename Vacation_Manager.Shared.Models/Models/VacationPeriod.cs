using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation_Manager.Shared.Models.Models;

public class VacationPeriod
{
    public VacationPeriod()
    {
    }
    public VacationPeriod(VacationCalendar calendar, DateOnly startDate, DateOnly endDate, string description = "Sem descrição")
    {
        VacationCalendar = calendar;
        StartDate = startDate;
        EndDate = endDate;
        Duration = (endDate.ToDateTime(TimeOnly.MinValue) - startDate.ToDateTime(TimeOnly.MinValue)).Days + 1;
        Description = description;
    }

    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int Duration { get; set; }
    public string Description { get; set; }
    public int VacationCalendarId { get; set; }
    public virtual VacationCalendar VacationCalendar { get; set; }
}
