using System;
using System.Collections.Generic;
using System.Linq;

namespace SF2022User17Lib
{
    public class Calculations
    {
        /// <summary>
        /// Возвращает свободные интервалы в рабочее время между консультациями.
        /// </summary>
        /// <param name="startTimes">Список с началом занятых промежутков.</param>
        /// <param name="durations">Спискок с продолжительностью занятых промежутков.</param>
        /// <param name="beginWorkingTime">Начало рабочеого времени.</param>
        /// <param name="endWorkingTime">Конец рабочего времени.</param>
        /// <param name="consultationTime">Минимальное необходимое время посетителя.</param>
        /// <returns></returns>
        public static string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            // Находим занятое время.
            var busyTimes = new List<(TimeSpan StartTime, TimeSpan EndTime)>();

            for (int i = 0; i < startTimes.Length; i++)
            {
                TimeSpan endTime = startTimes[i] + TimeSpan.FromMinutes(durations[i]);
                busyTimes.Add((startTimes[i], endTime));
            }
            
            // Находим свободное время
            var freeTimes = new List<(TimeSpan StartTime, TimeSpan EndTime)>();

            if (busyTimes.Count == 0)
                freeTimes.Add((beginWorkingTime, endWorkingTime));
            else
            {
                for (int i = 0; i < busyTimes.Count; i++)
                {
                    // Находим первый интервал
                    if (i == 0 && busyTimes[i].StartTime > beginWorkingTime)
                        freeTimes.Add((beginWorkingTime, busyTimes[i].StartTime));
                    // Находим интервалы между консультациями
                    if (i < busyTimes.Count - 1 && busyTimes[i].EndTime < busyTimes[i + 1].StartTime)
                        freeTimes.Add((busyTimes[i].EndTime, busyTimes[i + 1].StartTime));
                    // Находим последний интервал
                    if (i == busyTimes.Count - 1 && busyTimes[i].EndTime < endWorkingTime)
                        freeTimes.Add((busyTimes[i].EndTime, endWorkingTime));
                }
            }
            // Находим доступное время
            var availableTimes = new List<(TimeSpan StartTime, TimeSpan EndTime)>();
            foreach (var time in freeTimes)
            {
                TimeSpan availableTime = time.EndTime - time.StartTime;
                int numConsultetions = (int)availableTime.TotalMinutes / consultationTime;
                
                for (int i = 0; i < numConsultetions; i++)
                {
                    TimeSpan startTime = time.StartTime + TimeSpan.FromMinutes(i * consultationTime);
                    TimeSpan endTime = startTime + TimeSpan.FromMinutes(consultationTime);
                    
                    // Добавление свободного времени
                    if (endTime <= time.EndTime)
                        availableTimes.Add((startTime, endTime));
                }
            }
            // Вывод
            return availableTimes.Select(p => $"{p.StartTime:hh\\:mm}-{p.EndTime:hh\\:mm}").ToArray();
        }
    }
}