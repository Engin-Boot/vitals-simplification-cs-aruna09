using System;
namespace VitalChecker
{
    public class CheckBPM
    {
        public void IsBpmOk(float bpm)
        {
            if (bpm < 70)
                Console.WriteLine("BPM less than the minimum.");
            else if (bpm > 150)
                Console.WriteLine("BPM more than the maximum.");
            else
                Console.WriteLine("BPM within Limits");
        }
    }
    public class CheckSpo2
    {
        public void IsSpo2Ok(float spo2)
        {
            if (spo2 < 90)
                Console.WriteLine("SPo2 less than the minimum.");
            else
                Console.WriteLine("SPo2 within Limits");
        }
    }
    public class CheckRespRate
    {
        public void IsRespRateOk(float respRate)
        {
            if (respRate < 30)
                Console.WriteLine("Respiration Rate less than the minimum.");
            else if (respRate > 95)
                Console.WriteLine("Respiration Rate more than the maximum.");
            else
                Console.WriteLine("Respiration Rate within Limits");
        }
    }
    public delegate void CheckVitals(float value);
    public class Checker
    {
        CheckVitals vitals;
        public Checker(CheckVitals vitals)
        {
            this.vitals = vitals;
        }
        public void CheckVital(float value)
        {
            this.vitals.Invoke(value);
        }
    }

    class Program
    {
        static CheckBPM checkBPM = new CheckBPM();
        static CheckSpo2 checkSpo2 = new CheckSpo2();
        static CheckRespRate checkRespRate = new CheckRespRate();
        static void Main(string[] args)
        {
            Checker checkVitalBpm = new Checker(new CheckVitals(checkBPM.IsBpmOk));
            checkVitalBpm.CheckVital(55);

            Checker checkVitalSpo2 = new Checker(new CheckVitals(checkSpo2.IsSpo2Ok));
            checkVitalSpo2.CheckVital(99);

            Checker checkVitalRespRate = new Checker(new CheckVitals(checkRespRate.IsRespRateOk));
            checkVitalRespRate.CheckVital(62);
        }
    }
}
