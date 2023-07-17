namespace NLayer.Core.Utilities.Extensions
{
    public static class DateTimeExtensions
    {
        // Resim upload işlemlerinde kullanılacak extension metod.
        public static string FullDateAndTimeStringWithUnderScore(this DateTime dateTime)
        {
            return $"{dateTime.Microsecond}_{dateTime.Second}_{dateTime.Minute}_{dateTime.Hour}_{dateTime.Day}_{dateTime.Month}_{dateTime.Year}";

            /* 
             * ! Kullanıcıyı kaydederken öncelikle adını ekliyorum ve devamında bu extension metodumu çalıştırıyorum.
             * Çıktı => ŞafakCivelek_587_5_38_12_3_10_2023.png
             * Çıktı => MetinBozkurt_601_5_38_12_3_10_2023.png
             */
        }
    }
}
