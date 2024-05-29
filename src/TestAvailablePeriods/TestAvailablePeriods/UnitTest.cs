using SF2022User17Lib;

namespace TestAvailablePeriods;
/// <summary>
/// Test 1. Тестирование по примеру в задании 3 сессии.
/// Test 2. Тестирование определения начального интервала.
/// Test 3. Тестирование определения последного интервала.
/// Test 4. Тестирование нахождения интервалов при одной записи.
/// Test 5. Проверка на возможность пустого массива.
/// Test 6. Тестирование на маленькие доступные интервалы.
/// Test 7. Тестирование на большие интервалы.
/// Test 8. Проверка, если нет доступных интервалов.
/// Test 9. Тестирование разных временных интервалов.
/// Test 10. Определение доступных интервалов между большим количеством консультаций.
/// </summary>
public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }
    // Test 1. AvailablePeriods_FindAvailableTime_ReturnsCorrectedTime.
    // Тестирование с примером по заданию.
    [Test]
    public void AvailablePeriods_FindAvailableTime_ReturnsCorrectedTime()
    {
        TimeSpan[] startTimes = { 
            new (10,0,0),
            new (11,0,0),
            new (15,0,0),
            new (15,30,0),
            new (16,50,0), 
        };
        int[] durations = {60, 30, 10, 10, 40};
        TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
        TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
        int consultationTime = 30;

        var result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

        var expected = new[] { 
            "08:00-08:30",
            "08:30-09:00",
            "09:00-09:30",
            "09:30-10:00",
            "11:30-12:00",
            "12:00-12:30",
            "12:30-13:00",
            "13:00-13:30",
            "13:30-14:00",
            "14:00-14:30",
            "14:30-15:00",
            "15:40-16:10",
            "16:10-16:40",
            "17:30-18:00"
        };
        Assert.AreEqual(expected, result);
    }
    // Test 2. AvailablePeriods_NoConsultation_ReturnFullWorkingDay.
    // Тестирование обработки условия, при котором весь день свободен.
    [Test]
    public void AvailablePeriods_NoConsultation_ReturnsFullWorkindTime()
    {
        TimeSpan[] startTimes = new TimeSpan[0];
        int[] durations = new int[0];
        TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
        TimeSpan endWorkingTime = new TimeSpan(12, 0, 0);
        int consultationTime = 120;

        var result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        
        var expected = new[] { 
            "08:00-10:00",
            "10:00-12:00"
        };
        Assert.AreEqual(expected, result);
    }
    // Test 3. AvailablePeriods_ReturnsCorrectAvailableTimes_WhenOneConsultationExists().
    // Тестирование определения доступных интервалов с одной консультацией за день.
    [Test]
    public void AvailablePeriods_ReturnsCorrectAvailableTimes_WhenOneConsultationExists()
    {
        // Входящие параметры.
        var startTimes = new[] { new TimeSpan(10, 0, 0) };
        var durations = new[] { 60 };
        var beginWorkingTime = new TimeSpan(9, 0, 0);
        var endWorkingTime = new TimeSpan(18, 0, 0);
        var consultationTime = 60;

        var result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        
        var expected = new[] { 
            "09:00-10:00", 
            "11:00-12:00", 
            "12:00-13:00", 
            "13:00-14:00", 
            "14:00-15:00", 
            "15:00-16:00", 
            "16:00-17:00", 
            "17:00-18:00",
        };
        Assert.AreEqual(expected, result);
    }
    // Test 4. AvailablePeriods_NotEnoughTimeBetweenAppointments_ReturnsEmptyArray().
    // Тестирование, при котором нет доступных интервалов.
    [Test]
    public void AvailablePeriods_NotEnoughTimeBetweenAppointments_ReturnsEmptyArray()
    {
        TimeSpan[] startTimes = { new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0) };
        int[] durations = { 60, 60 };
        TimeSpan beginWorkingTime = new TimeSpan(9, 0, 0);
        TimeSpan endWorkingTime = new TimeSpan(11, 0, 0);
        int consultationTime = 60;


        string[] expected = new string[0];
        string[] actual = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

        CollectionAssert.AreEqual(expected, actual);
    }
    // Test 5. AvailablePeriods_FindFirstInterval_ReturnsCorrectedIntervals.
    // Нахождение первого интервала.
    [Test]
    public void AvailablePeriods_FindFirstInterval_ReturnsCorrectedIntervals()
    {
        TimeSpan[] startTimes = { TimeSpan.FromHours(8) };
        int[] durations = { 60 };
        TimeSpan beginWorkingTime = TimeSpan.FromHours(8);
        TimeSpan endWorkingTime = TimeSpan.FromHours(11);
        int consultationTime = 30;

        var result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        
        var expected = new[] { 
            "09:00-09:30", 
            "09:30-10:00", 
            "10:00-10:30", 
            "10:30-11:00", 
        };

        Assert.AreEqual(expected, result);
    }
    // Test 6. AvailablePeriods_FindLastInterval_ReturnsCorrectedIntervals.
    // Нахождение последнего интервала.
    [Test]
    public void AvailablePeriods_FindLastInterval_ReturnsCorrectedIntervals()
    {
        TimeSpan[] startTimes = { TimeSpan.FromHours(10) };
        int[] durations = { 60 };
        TimeSpan beginWorkingTime = TimeSpan.FromHours(8);
        TimeSpan endWorkingTime = TimeSpan.FromHours(11);
        int consultationTime = 30;

        var result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        
        var expected = new[] { 
            "08:00-08:30", 
            "08:30-09:00", 
            "09:00-09:30", 
            "09:30-10:00"
        };

        Assert.AreEqual(expected, result);
    }
    // Test 7. AvailablePeriods_SmallIntervals_ReturnsCorrectedIntervals.
    // Тестирование маленьких интервалов.
    [Test]
    public void AvailablePeriods_SmallIntervals_ReturnsCorrectedIntervals()
    {
        TimeSpan[] startTimes = { TimeSpan.FromHours(8) };
        int[] durations = { 45 };
        TimeSpan beginWorkingTime = TimeSpan.FromHours(8);
        TimeSpan endWorkingTime = TimeSpan.FromHours(9);
        int consultationTime = 5;

        var result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        
        var expected = new[] { 
            "08:45-08:50",
            "08:50-08:55",
            "08:55-09:00"
        };

        Assert.AreEqual(expected, result);
    }
    // Test 8. AvailablePeriods_LargeIntervals_ReturnsCorrectedIntervals.
    // Тестирование больших интервалов.
    [Test]
    public void AvailablePeriods_LargeIntervals_ReturnsCorrectedIntervals()
    {
        TimeSpan[] startTimes = { TimeSpan.FromHours(10) };
        int[] durations = { 180 };
        TimeSpan beginWorkingTime = TimeSpan.FromHours(8);
        TimeSpan endWorkingTime = TimeSpan.FromHours(18);
        int consultationTime = 180;

        var result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        
        var expected = new[] { 
            "13:00-16:00"
        };

        Assert.AreEqual(expected, result);
    }
    // Test 9. AvailablePeriods_UnisualConsultations_ReturnsCorrectedIntervals.
    // Тестирование необычных назначений.
    [Test]
    public void AvailablePeriods_UnisualConsultations_ReturnsCorrectedIntervals()
    {
        TimeSpan[] startTimes = { TimeSpan.FromHours(9), TimeSpan.FromHours(11) };
        int[] durations = { 23, 47};
        TimeSpan beginWorkingTime = TimeSpan.FromHours(8);
        TimeSpan endWorkingTime = TimeSpan.FromHours(12);
        int consultationTime = 30;

        var result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        
        var expected = new[] { 
            "08:00-08:30",
            "08:30-09:00",
            "09:23-09:53",
            "09:53-10:23",
            "10:23-10:53"
        };

        Assert.AreEqual(expected, result);
    }
    // Test 10. AvailablePeriods_FindIntervalBetweenConsultation_ReturnsCorrectedIntervals.
    // Тестирование определение интервалов между большим количеством консультаций.
    [Test]
    public void AvailablePeriods_FindIntervalBetweenConsultation_ReturnsCorrectedIntervals()
    {
        TimeSpan[] startTimes = { 
            TimeSpan.FromHours(10),
            TimeSpan.FromHours(11),
            TimeSpan.FromHours(12),
            TimeSpan.FromHours(13),
            TimeSpan.FromHours(17)
        };
        int[] durations = { 60, 45, 30, 180, 45};
        TimeSpan beginWorkingTime = TimeSpan.FromHours(10);
        TimeSpan endWorkingTime = TimeSpan.FromHours(18);
        int consultationTime = 15;

        var result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
        
        var expected = new[] { 
            "11:45-12:00",
            "12:30-12:45",
            "12:45-13:00",
            "16:00-16:15",
            "16:15-16:30",
            "16:30-16:45",
            "16:45-17:00",
            "17:45-18:00"
        };

        Assert.AreEqual(expected, result);
    }
}