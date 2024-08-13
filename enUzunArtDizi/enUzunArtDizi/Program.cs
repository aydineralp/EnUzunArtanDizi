namespace enUzunArtDizi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Dizinin eleman sayısını girin: ");
            int n = int.Parse(Console.ReadLine());

            int[] dizi = new int[n];
            Console.WriteLine("Dizinin elemanlarını girin:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"dizi[{i}] = ");
                dizi[i] = int.Parse(Console.ReadLine());
            }

            List<int> enUzunArtanAltDizi = EnUzunArtanAltDiziBul(dizi);

            Console.WriteLine("En Uzun Artan Alt Dizi:");
            foreach (int eleman in enUzunArtanAltDizi)
            {
                Console.Write(eleman + " ");
            }
        }

        static List<int> EnUzunArtanAltDiziBul(int[] dizi)
        {
            int n = dizi.Length;
            int[] uzunluklar = new int[n];
            int[] oncekiIndexler = new int[n];
            int maxUzunluk = 0;
            int maxIndex = -1;

            for (int i = 0; i < n; i++)
            {
                uzunluklar[i] = 1;
                oncekiIndexler[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (dizi[j] < dizi[i] && uzunluklar[j] + 1 > uzunluklar[i])
                    {
                        uzunluklar[i] = uzunluklar[j] + 1;
                        oncekiIndexler[i] = j;
                    }
                }

                if (uzunluklar[i] > maxUzunluk)
                {
                    maxUzunluk = uzunluklar[i];
                    maxIndex = i;
                }
            }

            List<int> enUzunArtanAltDizi = new List<int>();
            for (int i = maxIndex; i != -1; i = oncekiIndexler[i])
            {
                enUzunArtanAltDizi.Insert(0, dizi[i]);
            }

            return enUzunArtanAltDizi;
        }
    }
}
