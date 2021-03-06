﻿
namespace IbanValidator.Specialized.Germany
{
    public class Bankleitzahl
    {
        public short ClearingArea { get; }
        public Bankengruppe Bankengruppe { get; }
        public short IndividualNumber { get; }

        public long Value { get; }

        public Bankleitzahl(long blz)
        {
            Value = blz;
            ClearingArea = (short)(blz / 100000);
            Bankengruppe = (Bankengruppe)(blz / 10000 % 10);
            IndividualNumber = (short)(blz % 1000);
        }

        public static Bankleitzahl Parse(string blz) => new Bankleitzahl(long.Parse(blz));
        public static bool TryParse(string blz, out Bankleitzahl result)
        {
            result = null;
            long parsedBlz;
            if (long.TryParse(blz, out parsedBlz))
                result = new Bankleitzahl(parsedBlz);
            return result != null;
        }
    }
}
