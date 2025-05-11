using System;
using System.Collections.Generic;
using System.Linq;
using Vacation_Manager.Shared.Models.Models;
using Vacation_Manager.Shared.DB.DataBase;


Assistent assistente1 = new("Pedro Fagundes", "pedro.fagundes@email.com", new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday });
Assistent assistente2 = new("Thauana Camila", "thauana.camila@email.com", new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday });
Assistent assistente3 = new("Nabla Fagundes", "nabla.fagundes@email.com", new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday });

foreach(var assistente in new List<Assistent> { assistente1, assistente2, assistente3 })
{
    Console.WriteLine(assistente.ToString());
}

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Adicionando férias para o assistente 1");
//assistente1.AddVacationPeriod(new VacationPeriod(new DateOnly(2023, 10, 1), new DateOnly(2023, 10, 15)));
//assistente1.AddVacationPeriod(new VacationPeriod(new DateOnly(2023, 12, 1), new DateOnly(2023, 12, 5)));
Thread.Sleep(3000);

Console.WriteLine($"Foram registados dois períodos de férias para o assistente {assistente1.Name}");
foreach(var periodo in assistente1.VacationCalendars.First().VacationList)
{
    Console.WriteLine($"Período de férias: {periodo.StartDate} a {periodo.EndDate} - {periodo.Duration} dias");
}

Console.WriteLine($"O saldo de férias do assistente {assistente1.Name} é de {assistente1.VacationBalance} dias");