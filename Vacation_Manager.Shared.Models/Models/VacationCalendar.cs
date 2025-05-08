using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation_Manager.Shared.Models.Models;

public class VacationCalendar
{
    public VacationCalendar(int year, List<VacationPeriod> vacationList)
    {
        //AssistenteId = assistenteId;
        Year = year;
        VacationList = vacationList;
    }

    public int Id { get; set; }
    public int Year { get; set; }
    public virtual int AssistenteId { get; set; }
    public List<VacationPeriod> VacationList { get; set; }
}
