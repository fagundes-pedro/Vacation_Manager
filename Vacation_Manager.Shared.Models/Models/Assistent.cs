using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation_Manager.Shared.Models.Models;

public class Assistent
{
    public Assistent(string name, string email, List<DayOfWeek> daysOff)
    {
        Name = name;
        Email = email;
        VacationBalance = 22; // Default vacation balance
        DaysOff = daysOff;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int VacationBalance { get; set; }
    public List<VacationCalendar>? VacationCalendars { get; set; }
    public List<DayOfWeek> DaysOff { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Email} - {string.Join(", ", DaysOff)}";
    }

    public void AddVacationPeriod(VacationPeriod vacationPeriod)
    {
        if (VacationCalendars is null)
        {
            VacationCalendars = new List<VacationCalendar>();
        }
        var vacationCalendar = VacationCalendars.FirstOrDefault(vc => vc.Year.Equals(vacationPeriod.StartDate.Year));
        if (vacationCalendar is null)
        {
            vacationCalendar = new VacationCalendar(vacationPeriod.StartDate.Year, new List<VacationPeriod>());
            VacationCalendars.Add(vacationCalendar);
        }
        vacationCalendar.VacationList.Add(vacationPeriod);
        VacationBalance -= vacationPeriod.Duration;
    }
}
