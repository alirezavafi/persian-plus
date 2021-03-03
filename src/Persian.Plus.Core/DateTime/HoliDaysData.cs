using System.Collections.Generic;
using System.Linq;

namespace Persian.Plus.Core.DateTime
{
    public class HoliDaysData
    {

        public IEnumerable<EventDay> GetEventsByDateRange(DateRange dateRange)
        {
            var allEvents = new List<EventDay>();
            var gregorianStartDate = dateRange.StartDate;
            var gregorianEndDate = dateRange.EndDate;
            var startYear = gregorianStartDate.Year;
            do
            {
                allEvents.AddRange(GetGregorianEventsByYear(startYear));
                startYear++;
            } while (startYear <= gregorianEndDate.Year);
            
            var hijriStartDate = new HijriDate(gregorianStartDate);
            var hijriEndDate = new HijriDate(gregorianEndDate);
            startYear = hijriStartDate.Year;
            do
            {
                allEvents.AddRange(GetHijriEventsByYear(startYear));
                startYear++;
            } while (startYear <= hijriEndDate.Year);

            var persianStartDate = new PersianDate(gregorianStartDate);
            var persianEndDate = new PersianDate(gregorianEndDate);
            startYear = persianStartDate.Year;
            do
            {
                allEvents.AddRange(GetPerisanEventsByYear(startYear));
                startYear++;
            } while (startYear <= persianEndDate.Year);

            var dateRangeEvents = allEvents
                .Where(x => x.DateTime >= gregorianStartDate && x.DateTime < gregorianEndDate).OrderBy(x => x.DateTime)
                .ToList();
            return dateRangeEvents;
        }

        private IEnumerable<EventDay> GetHijriEventsByYear(int hijriYear)
        {
            var days = new List<EventDay>();
            days.Add(new EventDay(61, hijriYear, 1, 10, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.SadnessEvent, "عاشورای حسینی"));
            days.Add(new EventDay(61, hijriYear, 2, 20, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.SadnessEvent, "اربعین حسینی"));
            days.Add(new EventDay(61, hijriYear, 2, 28, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.SadnessEvent, "رحلت رسول اکرم؛شهادت امام حسن مجتبی علیه السلام"));
            days.Add(new EventDay(61, hijriYear, 2, 29, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.SadnessEvent, "شهادت امام رضا علیه السلام"));
            days.Add(new EventDay(61, hijriYear, 3, 8, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.SadnessEvent, "شهادت امام حسن عسکری علیه السلام"));
            days.Add(new EventDay(61, hijriYear, 3, 17, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.HappyEvent, "میلاد رسول اکرم و امام جعفر صادق علیه السلام"));
            days.Add(new EventDay(61, hijriYear, 6, 3, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.SadnessEvent, "شهادت حضرت فاطمه زهرا سلام الله علیها"));
            days.Add(new EventDay(61, hijriYear, 7, 13, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.HappyEvent, "ولادت امام علی علیه السلام و روز پدر", SpecialDay.MenDay));
            days.Add(new EventDay(61, hijriYear, 7, 27, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.HappyEvent, "مبعث رسول اکرم"));
            days.Add(new EventDay(61, hijriYear, 8, 15, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.HappyEvent, "ولادت حضرت قائم عجل الله تعالی فرجه و جشن  نیمه شعبان"));
            days.Add(new EventDay(61, hijriYear, 9, 21, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.SadnessEvent, "شهادت حضرت علی علیه السلام"));
            days.Add(new EventDay(61, hijriYear, 10, 1, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.HappyEvent | EventType.Eyd, "عید سعید فطر"));
            days.Add(new EventDay(61, hijriYear, 10, 2, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.HappyEvent, "تعطیل به مناسبت عید سعید فطر"));
            days.Add(new EventDay(61, hijriYear, 10, 25, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.SadnessEvent, "شهادت امام جعفر صادق علیه السلام"));
            days.Add(new EventDay(61, hijriYear, 12, 10, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.HappyEvent | EventType.Eyd, "عید سعید قربان"));
            days.Add(new EventDay(61, hijriYear, 12, 18, CalenderType.HijriCalendar, EventType.Holiday | EventType.ReligiousEvent | EventType.HappyEvent | EventType.Eyd, "عید سعید غدیر خم"));
            days.Add(new EventDay(95,hijriYear,  1, 12, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.SadnessEvent, "شهادت امام زین العابدین علیه السلام"));
            days.Add(new EventDay(1,hijriYear,  3, 1, CalenderType.HijriCalendar, EventType.ReligiousEvent, "هجرت پیامبر اکرم از مکه به مدینه"));
            days.Add(new EventDay(-53,hijriYear,  3, 12, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.HappyEvent, "میلاد رسول اکرم به روایت اهل سنت"));
            days.Add(new EventDay(-53,hijriYear,  3, 12, CalenderType.HijriCalendar, EventType.ReligiousEvent, "آغاز هفته وحدت"));
            days.Add(new EventDay(232, hijriYear, 4, 8, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.HappyEvent, "ولادت امام حسن عسکری علیه السلام"));
            days.Add(new EventDay(201,hijriYear,  4, 10, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.SadnessEvent, "وفات حضرت معصومه سلام الله علیها"));
            days.Add(new EventDay(5, hijriYear, 5, 5, CalenderType.HijriCalendar, EventType.ReligiousEvent| EventType.HappyEvent, "ولادت حضرت زینب سلام الله علیها و روز پرستار و بهورز", SpecialDay.NurseDay));
            days.Add(new EventDay(-8, hijriYear, 6, 20, CalenderType.HijriCalendar, EventType.ReligiousEvent| EventType.HappyEvent, "ولادت حضرت فاطمه زهرا سلام الله علیها و روز زن", SpecialDay.WomenDay));
            days.Add(new EventDay(57, hijriYear, 7, 1, CalenderType.HijriCalendar, EventType.ReligiousEvent| EventType.HappyEvent, "ولادت امام محمد باقر علیه السلام"));
            days.Add(new EventDay(254,hijriYear,  7, 3, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.SadnessEvent, "شهادت امام علی النقی الهادی علیه السلام"));
            days.Add(new EventDay(195,hijriYear,  7, 10, CalenderType.HijriCalendar, EventType.ReligiousEvent| EventType.HappyEvent, "ولادت امام محمد تقی علیه السلام"));
            days.Add(new EventDay(62, hijriYear, 7, 15, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.SadnessEvent, "وفات حضرت زینب سلام الله علیها"));
            days.Add(new EventDay(183, hijriYear, 7, 25, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.SadnessEvent, "شهادت امام موسی کاظم علیه السلام"));
            days.Add(new EventDay(4,hijriYear,  8, 3, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.HappyEvent, "ولادت سالار شهیدان، امام حسین علیه السلام و روز پاسدار"));
            days.Add(new EventDay(26,hijriYear,  8, 4, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.HappyEvent, "ولادت ابوالفضل العباس علیه السلام و روز جانباز"));
            days.Add(new EventDay(38, hijriYear, 8, 5, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.HappyEvent, "ولادت امام زین العابدین علیه السلام"));
            days.Add(new EventDay(-3,hijriYear,  9, 10, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.SadnessEvent, "وفات حضرت خدیجه (س)"));
            days.Add(new EventDay(33,hijriYear,  8, 11, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.HappyEvent, "ولادت حضرت علی اکبر علیه السلام و روز جوان"));
            days.Add(new EventDay(3,hijriYear,  9, 15, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.HappyEvent, "ولادت امام حسن مجتبی علیه السلام"));
            days.Add(new EventDay(1, hijriYear, 9, 18, CalenderType.HijriCalendar, EventType.ReligiousEvent, "شب قدر"));
            days.Add(new EventDay(40,hijriYear,  9, 19, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.SadnessEvent, "ضربت خوردن حضرت علی علیه السلام"));
            days.Add(new EventDay(1,hijriYear,  9, 20, CalenderType.HijriCalendar, EventType.ReligiousEvent, "شب قدر"));
            days.Add(new EventDay(1,hijriYear,  9, 22, CalenderType.HijriCalendar, EventType.ReligiousEvent, "شب قدر"));
            days.Add(new EventDay(173,hijriYear,  11, 1, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.HappyEvent, "ولادت حضرت معصومه سلام الله علیها و روز دختر", SpecialDay.DaughterDay));
            days.Add(new EventDay(148,hijriYear,  11, 11, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.HappyEvent, "ولادت امام رضا علیه السلام"));
            days.Add(new EventDay(1,hijriYear,  11, 29, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.SadnessEvent, "شهادت امام محمد تقی علیه السلام"));
            days.Add(new EventDay(114,hijriYear,  12, 7, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.SadnessEvent, "شهادت امام محمد باقرعلیه السلام"));
            days.Add(new EventDay(1,hijriYear,  12, 9, CalenderType.HijriCalendar, EventType.ReligiousEvent, "روز عرفه"));
            days.Add(new EventDay(212,hijriYear,  12, 15, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.HappyEvent, "ولادت امام علی النقی الهادی علیه السلام"));
            days.Add(new EventDay(61,hijriYear,  12, 20, CalenderType.HijriCalendar, EventType.ReligiousEvent | EventType.HappyEvent, "ولادت امام موسی کاظم علیه السلام"));

            return days;
        }
        
        private IEnumerable<EventDay> GetPerisanEventsByYear(int persianYear)
        {
            var days = new List<EventDay>();
            days.Add(new EventDay(persianYear, 1, 1, CalenderType.PersianCalendar, EventType.Holiday | EventType.Eyd | EventType.HappyEvent, "جشن نوروز"));
            days.Add(new EventDay(persianYear, 1, 2, CalenderType.PersianCalendar, EventType.Holiday, "عیدنوروز"));
            days.Add(new EventDay(persianYear, 1, 3, CalenderType.PersianCalendar, EventType.Holiday, "عیدنوروز"));
            days.Add(new EventDay(persianYear, 1, 4, CalenderType.PersianCalendar, EventType.Holiday, "عیدنوروز"));
            days.Add(new EventDay(persianYear, 1, 12, CalenderType.PersianCalendar, EventType.Holiday, "روز جمهوری اسلامی ایران"));
            days.Add(new EventDay(persianYear, 1, 13, CalenderType.PersianCalendar, EventType.Holiday, "جشن سیزده به در"));
            days.Add(new EventDay(persianYear, 3, 14, CalenderType.PersianCalendar, EventType.Holiday, "رحلت حضرت امام خمینی"));
            days.Add(new EventDay(persianYear, 3, 15, CalenderType.PersianCalendar, EventType.Holiday, "قیام 15 خرداد"));
            days.Add(new EventDay(persianYear, 11, 22, CalenderType.PersianCalendar, EventType.Holiday, "پیروزی انقلاب اسلامی"));
            days.Add(new EventDay(persianYear, 12, 29, CalenderType.PersianCalendar, EventType.Holiday, "روز ملی شدن صنعت نفت ایران"));
            days.Add(new EventDay(persianYear, 1, 6, CalenderType.PersianCalendar, EventType.NationalEvent, "روز امید، روز شادباش نویسی"));
            days.Add(new EventDay(persianYear, 1, 6, CalenderType.PersianCalendar, EventType.NationalEvent, "زادروز آشو زرتشت، اَبَراِنسان بزرگ تاریخ"));
            days.Add(new EventDay(persianYear, 1, 10, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "جشن آبانگاه"));
            days.Add(new EventDay(persianYear, 1, 17, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "سروش روز،جشن سروشگان"));
            days.Add(new EventDay(1359, persianYear, 1, 19, CalenderType.PersianCalendar, EventType.NationalEvent, "شهادت آیت الله سید محمد باقر صدر و خواهر ایشان بنت الهدی توسط حکومت بعث عراق"));
            days.Add(new EventDay(persianYear, 1, 19, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "فروردین روز ، جشن فروردینگان"));
            days.Add(new EventDay(persianYear, 1, 20, CalenderType.PersianCalendar, EventType.NationalEvent, "روز ملّی فن آوری هسته ای"));
            days.Add(new EventDay(persianYear, 1, 21, CalenderType.PersianCalendar, EventType.NationalEvent, "روز هنر انقلاب اسلامی"));
            days.Add(new EventDay(1378, persianYear, 1, 21, CalenderType.PersianCalendar, EventType.NationalEvent, "شهادت امیر سپهبد علی سیاد شیرازی"));
            days.Add(new EventDay(persianYear, 1, 25, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت عطار نیشابوری"));
            days.Add(new EventDay(persianYear, 1, 29, CalenderType.PersianCalendar, EventType.NationalEvent, "روز ارتش جمهوری اسلامی ایران"));
            days.Add(new EventDay(persianYear, 2, 1, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت سعدی"));
            days.Add(new EventDay(1358, persianYear, 2, 2, CalenderType.PersianCalendar, EventType.NationalEvent, "تاسیس سپاه پاسداران انقلاب اسلامی)"));
            days.Add(new EventDay(1359, persianYear, 2, 2, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز اعلام انقلاب فرهنگی"));
            days.Add(new EventDay(persianYear, 2, 3, CalenderType.PersianCalendar, EventType.NationalEvent, "روزبزرگداشت شیخ بهایی"));
            days.Add(new EventDay(persianYear, 2, 3, CalenderType.PersianCalendar, EventType.NationalEvent, "روزملی کارآفرینی"));
            days.Add(new EventDay(1359, persianYear, 2, 5, CalenderType.PersianCalendar, EventType.NationalEvent, "شکست حمله ی نظامی آمریکا با ایران در طبس"));
            days.Add(new EventDay(persianYear, 2, 9, CalenderType.PersianCalendar, EventType.NationalEvent, "روزشوراها"));
            days.Add(new EventDay(persianYear, 2, 10, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "جشن چهلم نوروز"));
            days.Add(new EventDay(persianYear, 2, 10, CalenderType.PersianCalendar, EventType.NationalEvent, "روزملی خلیج فارس"));
            days.Add(new EventDay(1361, persianYear, 2, 10, CalenderType.PersianCalendar, EventType.NationalEvent, "آغاز عملیات بیت المقدس"));
            days.Add(new EventDay(persianYear, 2, 12, CalenderType.PersianCalendar, EventType.NationalEvent, "شهادت استاد مرتضی مطهری، روزمعلم"));
            days.Add(new EventDay(persianYear, 2, 15, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت شیخ صدوق"));
            days.Add(new EventDay(persianYear, 2, 15, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "جشن میانه بهار ، جشن بهاربد"));
            days.Add(new EventDay(persianYear, 2, 15, CalenderType.PersianCalendar, EventType.NationalEvent, "روز شیراز"));
            days.Add(new EventDay(persianYear, 2, 17, CalenderType.PersianCalendar, EventType.NationalEvent, "روز اسنادملی و میراث مکتوب"));
            days.Add(new EventDay(1270, persianYear, 2, 24, CalenderType.PersianCalendar, EventType.NationalEvent, "لغو امتیاز تنباکو به فتوای آیت الله میرزا حسن شیرازی"));
            days.Add(new EventDay(persianYear, 2, 25, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت فردوسی"));
            days.Add(new EventDay(persianYear, 2, 27, CalenderType.PersianCalendar, EventType.NationalEvent, "روز ارتباطات و روابط عمومی"));
            days.Add(new EventDay(persianYear, 2, 28, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت حکیم عمر خیام"));
            days.Add(new EventDay(persianYear, 3, 1, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بهره وری و بهینه سازی مصرف"));
            days.Add(new EventDay(persianYear, 3, 1, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت ملاصدرا"));
            days.Add(new EventDay(1361, persianYear, 3, 3, CalenderType.PersianCalendar, EventType.NationalEvent, "فتح خرمشهر در عملیات بیت المقدس"));
            days.Add(new EventDay(persianYear, 3, 3, CalenderType.PersianCalendar, EventType.NationalEvent, "روز مقاومت ایثار و پیروزی"));
            days.Add(new EventDay(persianYear, 3, 4, CalenderType.PersianCalendar, EventType.NationalEvent, "روز دزفول"));
            days.Add(new EventDay(persianYear, 3, 4, CalenderType.PersianCalendar, EventType.NationalEvent, "روز مقاومت و پایداری"));
            days.Add(new EventDay(persianYear, 3, 6, CalenderType.PersianCalendar, EventType.NationalEvent, "خرداد روز ، جشن خردادگان"));
            days.Add(new EventDay(1349, persianYear, 3, 20, CalenderType.PersianCalendar, EventType.NationalEvent, "شهادت آیت الله سعیدی"));
            days.Add(new EventDay(persianYear, 3, 25, CalenderType.PersianCalendar, EventType.NationalEvent, "روز ملی گل وگیاه"));
            days.Add(new EventDay(persianYear, 3, 27, CalenderType.PersianCalendar, EventType.NationalEvent, "روز جهاد کشاورزی"));
            days.Add(new EventDay(1356, persianYear, 3, 29, CalenderType.PersianCalendar, EventType.NationalEvent, "درگذشت دکتر علی شریعتی"));
            days.Add(new EventDay(1373, persianYear, 3, 30, CalenderType.PersianCalendar, EventType.NationalEvent, "انفجار در حرم حضرت امام رضا (ع)"));
            days.Add(new EventDay(1360, persianYear, 3, 31, CalenderType.PersianCalendar, EventType.NationalEvent, "شهادت دکتر مصطفی چمران"));
            days.Add(new EventDay(persianYear, 3, 31, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بسیج اساتید"));
            days.Add(new EventDay(persianYear, 4, 1, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "جشن آب پاشونک، جشن آغاز تابستان"));
            days.Add(new EventDay(persianYear, 4, 1, CalenderType.PersianCalendar, EventType.NationalEvent, "روز اصناف"));
            days.Add(new EventDay(1360, persianYear, 4, 1, CalenderType.PersianCalendar, EventType.NationalEvent, "روز تبلیغ و اطلاع رسانی دینی ، سالروز صدور فرمان امام خمینی (ره) مبنی بر تاسیس سازمان تبلیغات اسلامی"));
            days.Add(new EventDay(1360, persianYear, 4, 7, CalenderType.PersianCalendar, EventType.NationalEvent, "شهادت آیت الله دکتر بهشتی ؛ روز قوه قضاییه"));
            days.Add(new EventDay(persianYear, 4, 8, CalenderType.PersianCalendar, EventType.NationalEvent, "روز مبارزه با سلاح های شیمیایی و میکروبی"));
            days.Add(new EventDay(persianYear, 4, 10, CalenderType.PersianCalendar, EventType.NationalEvent, "روز صنعت و معدن"));
            days.Add(new EventDay(1361, persianYear, 4, 11, CalenderType.PersianCalendar, EventType.NationalEvent, "شهادت آیت الله صدوقی چهارمین شهید محراب"));
            days.Add(new EventDay(1368, persianYear, 4, 12, CalenderType.PersianCalendar, EventType.NationalEvent, "حمله به هواپیمای مسافربری جمهوری اسلامی ایران توسط ناوگان آمریکایی"));
            days.Add(new EventDay(persianYear, 4, 13, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز درگذشت دکتر معین"));
            days.Add(new EventDay(persianYear, 4, 13, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "تیر روز،جشن تیرگان"));
            days.Add(new EventDay(persianYear, 4, 14, CalenderType.PersianCalendar, EventType.NationalEvent, "روز قلم"));
            days.Add(new EventDay(persianYear, 4, 15, CalenderType.PersianCalendar, EventType.NationalEvent, "جشن خام خواری"));
            days.Add(new EventDay(persianYear, 4, 16, CalenderType.PersianCalendar, EventType.NationalEvent, "روز مالیات"));
            days.Add(new EventDay(persianYear, 4, 21, CalenderType.PersianCalendar, EventType.NationalEvent, "روز عفاف و حجاب"));
            days.Add(new EventDay(persianYear, 4, 25, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بهزیستی و تامین اجتماعی"));
            days.Add(new EventDay(1368, persianYear, 4, 27, CalenderType.PersianCalendar, EventType.NationalEvent, "اعلام پذیرش قطعنامه 598 شورای امنیت از سوی ایران"));
            days.Add(new EventDay(1367, persianYear, 5, 5, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز عملیات افتخار آفرین مرصاد"));
            days.Add(new EventDay(persianYear, 5, 6, CalenderType.PersianCalendar, EventType.NationalEvent, "روز ترویج آموزش های فنی و حرفه ای"));
            days.Add(new EventDay(persianYear, 5, 7, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "مرداد روز ، جشن مردادگان"));
            days.Add(new EventDay(persianYear, 5, 8, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت شیخ شهاب الدین سهروردی"));
            days.Add(new EventDay(persianYear, 5, 9, CalenderType.PersianCalendar, EventType.NationalEvent, "روز اهدای خون"));
            days.Add(new EventDay(persianYear, 5, 10, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "جشن چله تابستان"));
            days.Add(new EventDay(persianYear, 5, 14, CalenderType.PersianCalendar, EventType.NationalEvent, "صدور فرمان مشروطیت"));
            days.Add(new EventDay(1359, persianYear, 5, 16, CalenderType.PersianCalendar, EventType.NationalEvent, "تشکیل جهاد دانشگاهی"));
            days.Add(new EventDay(persianYear, 5, 17, CalenderType.PersianCalendar, EventType.NationalEvent, "روز خبرنگار"));
            days.Add(new EventDay(persianYear, 5, 26, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز ورود آزادگانِ سرافراز به وطن"));
            days.Add(new EventDay(1332, persianYear, 5, 28, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز کودتای 28 مرداد علیه دولت دکتر محمد مصدق"));
            days.Add(new EventDay(persianYear, 5, 28, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز فاجعه آتش زدن سینما رکس آبادان"));
            days.Add(new EventDay(persianYear, 5, 30, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت علامه مجلسی"));

            days.Add(new EventDay(persianYear, 6, 1, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت ابوعلی سینا و روز پزشک"));
            days.Add(new EventDay(persianYear, 6, 2, CalenderType.PersianCalendar, EventType.NationalEvent, "آغاز هفته دولت"));
            days.Add(new EventDay(persianYear, 6, 4, CalenderType.PersianCalendar, EventType.NationalEvent, "زادروز داراب (کوروش)"));
            days.Add(new EventDay(persianYear, 6, 4, CalenderType.PersianCalendar, EventType.NationalEvent, "روز کارمند"));
            days.Add(new EventDay(persianYear, 6, 4, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "شهریور روز ، جشن شهریورگان"));
            days.Add(new EventDay(persianYear, 6, 5, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت محمدبن زکریای رازی و روز داروساز"));
            days.Add(new EventDay(persianYear, 6, 8, CalenderType.PersianCalendar, EventType.NationalEvent, "روز مبارزه با تروریسم"));
            days.Add(new EventDay(1362, persianYear, 6, 10, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بانکداری اسلامی ، سالروز تصویب قانون عملیات بانکی بدون ربا"));
            days.Add(new EventDay(persianYear, 6, 11, CalenderType.PersianCalendar, EventType.NationalEvent, "روز صنعت چاپ"));
            days.Add(new EventDay(persianYear, 6, 12, CalenderType.PersianCalendar, EventType.NationalEvent, "روز مبارزه با استعمار انگلیس"));
            days.Add(new EventDay(persianYear, 6, 13, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت ابوریحان بیرونی"));
            days.Add(new EventDay(persianYear, 6, 13, CalenderType.PersianCalendar, EventType.NationalEvent, "روزتعاون"));
            days.Add(new EventDay(1360, persianYear, 6, 14, CalenderType.PersianCalendar, EventType.NationalEvent, "شهادت آیت الله قدوسی و سرتیب وحید دستجردی"));
            days.Add(new EventDay(persianYear, 6, 14, CalenderType.PersianCalendar, EventType.NationalEvent, "روز اکرام"));
            days.Add(new EventDay(1357, persianYear, 6, 17, CalenderType.PersianCalendar, EventType.NationalEvent, "قیام 17 شهریور"));
            days.Add(new EventDay(1358, persianYear, 6, 19, CalenderType.PersianCalendar, EventType.NationalEvent, "وفات آیت الله سید محمود طالقانی اولین امام جمعه تهران"));
            days.Add(new EventDay(1360, persianYear, 6, 20, CalenderType.PersianCalendar, EventType.NationalEvent, "شهادت دومین شهید محراب آیت الله مدنی"));
            days.Add(new EventDay(persianYear, 6, 21, CalenderType.PersianCalendar, EventType.NationalEvent, "روز سینما"));
            days.Add(new EventDay(persianYear, 6, 27, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت شهریار و شعر و ادب فارسی"));
            days.Add(new EventDay(1359, persianYear, 6, 31, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز آغاز جنگ تحمیلی و آغاز هفته دفاع مقدس"));
            days.Add(new EventDay(1360, persianYear, 7, 5, CalenderType.PersianCalendar, EventType.NationalEvent, "شکست حصر آبادان"));
            days.Add(new EventDay(persianYear, 7, 7, CalenderType.PersianCalendar, EventType.NationalEvent, "روز آتش نشانی و ایمنی"));
            days.Add(new EventDay(1360, persianYear, 7, 7, CalenderType.PersianCalendar, EventType.NationalEvent, "سقوط هواپیمای حامل جمعی از فرماندهان جنگ (کلاهدوز، نامجو، فلاحی، فکوری، جهان آرا)"));
            days.Add(new EventDay(persianYear, 7, 8, CalenderType.PersianCalendar, EventType.NationalEvent, "روزبزرگداشت مولوی"));
            days.Add(new EventDay(persianYear, 7, 9, CalenderType.PersianCalendar, EventType.NationalEvent, "روز همبستگی با کودکان و نوجوانان فلسطینی"));

            days.Add(new EventDay(persianYear, 7, 13, CalenderType.PersianCalendar, EventType.NationalEvent, "روز نیروی انتظامی"));
            days.Add(new EventDay(persianYear, 7, 14, CalenderType.PersianCalendar, EventType.NationalEvent, "روز دامپزشکی"));
            days.Add(new EventDay(persianYear, 7, 16, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "مهر روز ، جشن مهرگان"));
            days.Add(new EventDay(persianYear, 7, 20, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت حافظ"));
            days.Add(new EventDay(persianYear, 7, 20, CalenderType.PersianCalendar, EventType.NationalEvent, "روز ملی کاهش اثرات بلایای طبیعی"));
            days.Add(new EventDay(persianYear, 7, 21, CalenderType.PersianCalendar, EventType.NationalEvent, "جشن پیروزی کاوه و فریدون"));
            days.Add(new EventDay(persianYear, 7, 24, CalenderType.PersianCalendar, EventType.NationalEvent, "روز پیوند اولیاء و مربیان"));
            days.Add(new EventDay(persianYear, 7, 26, CalenderType.PersianCalendar, EventType.NationalEvent, "روز تربیت بدنی و ورزش"));
            days.Add(new EventDay(persianYear, 7, 29, CalenderType.PersianCalendar, EventType.NationalEvent, "روز صادرات"));
            days.Add(new EventDay(persianYear, 8, 1, CalenderType.PersianCalendar, EventType.NationalEvent, "روز آمار و برنامه ریزی"));
            days.Add(new EventDay(persianYear, 8, 7, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز ورود کوروش بزرگ به بابل در سال 539 پیش از میلاد"));
            days.Add(new EventDay(persianYear, 8, 8, CalenderType.PersianCalendar, EventType.NationalEvent, "روز نوجوان"));
            days.Add(new EventDay(persianYear, 8, 10, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "آبان روز، جشن آبانگان"));
            days.Add(new EventDay(persianYear, 8, 13, CalenderType.PersianCalendar, EventType.NationalEvent, "روز دانش آموز"));
            days.Add(new EventDay(persianYear, 8, 14, CalenderType.PersianCalendar, EventType.NationalEvent, "روز فرهنگ عمومی"));
            days.Add(new EventDay(persianYear, 8, 15, CalenderType.PersianCalendar, EventType.NationalEvent, "جشن میانه پاییز"));
            days.Add(new EventDay(persianYear, 8, 18, CalenderType.PersianCalendar, EventType.NationalEvent, "روز ملی کیفیت"));
            days.Add(new EventDay(persianYear, 8, 24, CalenderType.PersianCalendar, EventType.NationalEvent, "روز کتاب و کتاب خوانی"));
            days.Add(new EventDay(persianYear, 9, 1, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "آذر جشن"));
            days.Add(new EventDay(persianYear, 9, 5, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بسیج مستضعفان"));
            days.Add(new EventDay(persianYear, 9, 7, CalenderType.PersianCalendar, EventType.NationalEvent, "روز نیروی دریایی"));
            days.Add(new EventDay(persianYear, 9, 9, CalenderType.PersianCalendar, EventType.NationalEvent, "آذر روز، جشن آذرگان"));
            days.Add(new EventDay(persianYear, 9, 9, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت شیخ مفید"));
            days.Add(new EventDay(persianYear, 9, 10, CalenderType.PersianCalendar, EventType.NationalEvent, "روز مجلس"));
            days.Add(new EventDay(persianYear, 9, 12, CalenderType.PersianCalendar, EventType.NationalEvent, "تصویب قانون اساسی جمهوری اسلامی ایران"));
            days.Add(new EventDay(persianYear, 9, 13, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بیمه"));
            days.Add(new EventDay(persianYear, 9, 15, CalenderType.PersianCalendar, EventType.NationalEvent, "روز حسابدار"));
            days.Add(new EventDay(persianYear, 9, 16, CalenderType.PersianCalendar, EventType.NationalEvent, "روز دانشجو"));
            days.Add(new EventDay(persianYear, 9, 25, CalenderType.PersianCalendar, EventType.NationalEvent, "روز پژوهش"));
            days.Add(new EventDay(persianYear, 9, 26, CalenderType.PersianCalendar, EventType.NationalEvent, "روز حمل و نقل"));
            days.Add(new EventDay(persianYear, 9, 27, CalenderType.PersianCalendar, EventType.NationalEvent, "روز وحدت حوزه و دانشگاه"));
            days.Add(new EventDay(persianYear, 9, 30, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "جشن شب یلدا"));
            days.Add(new EventDay(persianYear, 9, 27, CalenderType.PersianCalendar, EventType.NationalEvent, "روز وحدت حوزه و دانشگاه"));
            days.Add(new EventDay(persianYear, 10, 1, CalenderType.PersianCalendar, EventType.NationalEvent, "روز میلاد خورشید، جشن خرم روز، نخستین جشن دیگان"));
            days.Add(new EventDay(1358, persianYear, 10, 7, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز تشکیل نهضت سواد آموزی"));
            days.Add(new EventDay(persianYear, 10, 5, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز شهادت آشو زرتشت، اَبَراِنسان بزرگ تاریخ"));
            days.Add(new EventDay(persianYear, 10, 8, CalenderType.PersianCalendar, EventType.NationalEvent, "دی به آذر روز، دومین جشن دیگان"));
            days.Add(new EventDay(persianYear, 10, 14, CalenderType.PersianCalendar, EventType.NationalEvent, "روز جهاد کشاورزی"));
            days.Add(new EventDay(persianYear, 10, 15, CalenderType.PersianCalendar, EventType.NationalEvent, "دی به مهر روز، سومین جشن دیگان"));
            days.Add(new EventDay(persianYear, 10, 15, CalenderType.PersianCalendar, EventType.NationalEvent, "روز خانواده"));
            days.Add(new EventDay(persianYear, 10, 15, CalenderType.PersianCalendar, EventType.NationalEvent, "تکریم بازنشستگان"));
            days.Add(new EventDay(1346, persianYear, 10, 17, CalenderType.PersianCalendar, EventType.NationalEvent, "درگذشت جهان پهلوان تختی"));
            days.Add(new EventDay(1356, persianYear, 10, 19, CalenderType.PersianCalendar, EventType.NationalEvent, "قیام خونین مردم قم"));
            days.Add(new EventDay(1230, persianYear, 10, 20, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز شهادت امیرکبیر به دستور ناصرالدین شاه قاجار"));
            days.Add(new EventDay(persianYear, 10, 23, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "دی به دین روز ، چهارمین جشن دیگان"));
            days.Add(new EventDay(persianYear, 10, 27, CalenderType.PersianCalendar, EventType.NationalEvent, "اجرای توافق نامه‌ی برجام"));
            days.Add(new EventDay(persianYear, 11, 1, CalenderType.PersianCalendar, EventType.NationalEvent, "زادروز فردوسی"));
            days.Add(new EventDay(persianYear, 11, 2, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "بهمن روز، جشن بهمنگان"));
            days.Add(new EventDay(persianYear, 11, 5, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "جشن نوسره"));
            days.Add(new EventDay(persianYear, 11, 10, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "جشن سده"));
            days.Add(new EventDay(persianYear, 11, 12, CalenderType.PersianCalendar, EventType.NationalEvent, "بازگشت امام خمینی (ره) به ایران"));
            days.Add(new EventDay(persianYear, 11, 12, CalenderType.PersianCalendar, EventType.NationalEvent, "آغاز دهه فجر"));
            days.Add(new EventDay(persianYear, 11, 15, CalenderType.PersianCalendar, EventType.NationalEvent, "جشن میانه زمستان"));
            days.Add(new EventDay(persianYear, 11, 18, CalenderType.PersianCalendar, EventType.NationalEvent, "روز ملی فناوری فضایی"));
            days.Add(new EventDay(persianYear, 11, 19, CalenderType.PersianCalendar, EventType.NationalEvent, "روز نیروی هوایی"));
            days.Add(new EventDay(persianYear, 11, 29, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "جشن سپندارمذگان ، روز عشق", SpecialDay.LoveDay));
            days.Add(new EventDay(persianYear, 12, 5, CalenderType.PersianCalendar, EventType.NationalEvent | EventType.HappyEvent, "جشن اسفندگان(سپندارمذگان) روز عشق بر اساس تقویم زرتشتی", SpecialDay.LoveDay));
            days.Add(new EventDay(persianYear, 12, 5, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت زمین و بانوان"));
            days.Add(new EventDay(persianYear, 12, 5, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت خواجه نصیر الدین طوسی و روز مهندس"));
            days.Add(new EventDay(persianYear, 12, 7, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز استقلال کانون وکلای دادگستری و روز وکیل مدافع"));
            days.Add(new EventDay(persianYear, 12, 7, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز درگذشت علی اکبر دهخدا"));
            days.Add(new EventDay(persianYear, 12, 9, CalenderType.PersianCalendar, EventType.NationalEvent, "روز حمایت از حقوق مصرف کنندگان"));
            days.Add(new EventDay(persianYear, 12, 14, CalenderType.PersianCalendar, EventType.NationalEvent, "روز احسان و نیکوکاری"));
            days.Add(new EventDay(persianYear, 12, 14, CalenderType.PersianCalendar, EventType.NationalEvent, "سالروز درگذشت دکتر محمد مصدق"));
            days.Add(new EventDay(persianYear, 12, 15, CalenderType.PersianCalendar, EventType.NationalEvent, "روز درختکاری"));
            days.Add(new EventDay(persianYear, 12, 22, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت شهدا"));
            days.Add(new EventDay(persianYear, 12, 25, CalenderType.PersianCalendar, EventType.NationalEvent, "پایان سرایش شاهنامه"));
            days.Add(new EventDay(persianYear, 12, 25, CalenderType.PersianCalendar, EventType.NationalEvent, "روز بزرگداشت پروین اعتصامی"));

            return days;
        }

        private IEnumerable<EventDay> GetGregorianEventsByYear(int gregorianYear)
        {
            var days = new List<EventDay>();
            days.Add(new EventDay(gregorianYear, 1, 1, CalenderType.GregorianCalendar, EventType.InternationalEvent | EventType.Eyd, "جشن آغاز سال نو میلادی"));
            days.Add(new EventDay(gregorianYear, 2, 14, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز ولنتاین، روز جهانی عشق", SpecialDay.LoveDay));
            days.Add(new EventDay(gregorianYear, 2, 21, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی زبان مادری"));
            days.Add(new EventDay(gregorianYear, 3, 8, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی زنان", SpecialDay.WomenDay));
            days.Add(new EventDay(gregorianYear, 3, 22, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی آب"));
            days.Add(new EventDay(gregorianYear, 3, 23, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی هواشناسی"));
            days.Add(new EventDay(gregorianYear, 3, 27, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی تئاتر"));
            days.Add(new EventDay(gregorianYear, 4, 7, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی بهداشت"));
            days.Add(new EventDay(gregorianYear, 4, 22, CalenderType.PersianCalendar, EventType.InternationalEvent, "جشن گیاه آوری ، روز زمین پاک"));
            days.Add(new EventDay(gregorianYear, 4, 29, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی روانشناس و مشاور"));
            days.Add(new EventDay(gregorianYear, 5, 1, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روزجهانی کارگر"));
            days.Add(new EventDay(gregorianYear, 5, 5, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی ماما"));
            days.Add(new EventDay(gregorianYear, 5, 8, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی صلیب سرخ و هلال احمر"));
            days.Add(new EventDay(gregorianYear, 5, 15, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی خانواده"));
            days.Add(new EventDay(gregorianYear, 5, 17, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی ارتباطات"));
            days.Add(new EventDay(gregorianYear, 5, 18, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی موزه و میراث فرهنگ"));
            days.Add(new EventDay(gregorianYear, 5, 21, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی توسعه فرهنگی"));
            days.Add(new EventDay(gregorianYear, 5, 31, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی بدون دخانیات"));
            days.Add(new EventDay(gregorianYear, 6, 5, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی محیط زیست"));
            days.Add(new EventDay(gregorianYear, 6, 10, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی صنایع دستی"));
            days.Add(new EventDay(gregorianYear, 6, 12, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی مبارزه با کار کودکان"));
            days.Add(new EventDay(gregorianYear, 6, 14, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی اهدای خون"));
            days.Add(new EventDay(gregorianYear, 6, 17, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی بیابان زدایی"));
            days.Add(new EventDay(gregorianYear, 6, 26, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی مبارزه با مواد مخدر"));
            days.Add(new EventDay(gregorianYear, 8, 1, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی شیر مادر"));
            days.Add(new EventDay(gregorianYear, 8, 13, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی چپ دست ها"));
            days.Add(new EventDay(gregorianYear, 8, 19, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی عکاسی"));
            days.Add(new EventDay(gregorianYear, 8, 21, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی مسجد"));
            days.Add(new EventDay(gregorianYear, 9, 10, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی پیشگیری از خودکشی"));
            days.Add(new EventDay(gregorianYear, 9, 11, CalenderType.GregorianCalendar, EventType.InternationalEvent, "حمله به برج‌های دوقلوی مرکز تجارت جهانی"));
            days.Add(new EventDay(gregorianYear, 9, 13, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز گرامیداشت برنامه نویسان"));
            days.Add(new EventDay(gregorianYear, 9, 21, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی صلح"));
            days.Add(new EventDay(gregorianYear, 9, 27, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی جهانگردی"));
            days.Add(new EventDay(gregorianYear, 9, 30, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی ناشنوایان"));
            days.Add(new EventDay(gregorianYear, 9, 30, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی دریا نوردی"));
            days.Add(new EventDay(gregorianYear, 9, 30, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی ترجمه و مترجم"));
            days.Add(new EventDay(gregorianYear, 10, 1, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی سالمندان"));
            days.Add(new EventDay(gregorianYear, 10, 5, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی معلم"));
            days.Add(new EventDay(gregorianYear, 10, 8, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز ملی کودک"));
            days.Add(new EventDay(gregorianYear, 10, 9, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی پست"));
            days.Add(new EventDay(gregorianYear, 10, 11, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی دختر", SpecialDay.DaughterDay));
            days.Add(new EventDay(gregorianYear, 10, 14, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی استاندارد"));
            days.Add(new EventDay(gregorianYear, 10, 15, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی عصای سفید"));
            days.Add(new EventDay(gregorianYear, 10, 16, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی غذا"));
            days.Add(new EventDay(gregorianYear, 10, 17, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی ریشه کنی فقر"));
            days.Add(new EventDay(gregorianYear, 10, 29, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی بزرگداشت کورش کبیر"));
            days.Add(new EventDay(gregorianYear, 11, 17, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی فلسفه"));
            days.Add(new EventDay(gregorianYear, 11, 20, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی کودک"));
            days.Add(new EventDay(gregorianYear, 11, 25, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی مبارزه با خشونت علیه زنان"));
            days.Add(new EventDay(gregorianYear, 12, 1, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی مبارزه با ایدز"));
            days.Add(new EventDay(gregorianYear, 12, 3, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی معلولان"));
            days.Add(new EventDay(gregorianYear, 12, 7, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی هواپیمایی"));
            days.Add(new EventDay(gregorianYear, 12, 25, CalenderType.GregorianCalendar, EventType.InternationalEvent | EventType.HappyEvent, "میلاد حضرت مسیح (ع) و جشن کریسمس"));
            days.Add(new EventDay(gregorianYear, 12, 3, CalenderType.GregorianCalendar, EventType.InternationalEvent, "روز جهانی معلولان"));

            return days;
        }
    }
}
