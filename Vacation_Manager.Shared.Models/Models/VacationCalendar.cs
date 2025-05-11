using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation_Manager.Shared.Models.Models;

public class VacationCalendar
{
    public VacationCalendar()
    {
    }
    public VacationCalendar(Assistent assistent, int year)
    {
        Assistent = assistent;
        Year = year;
        VacationList = new List<VacationPeriod>();
    }

    public int Id { get; set; }
    public int Year { get; set; }
    public int AssistentId { get; set; }
    public virtual Assistent Assistent { get; set; }
    public virtual ICollection<VacationPeriod> VacationList { get; set; }
}
