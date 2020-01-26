using System;

public class Class1
{
	public Class1()
	{
		public int[] tablica = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	}

	static void losuj (int n)
{
	int[] tab = new int[n];
	Random gen = new Random();

	int i = 0;
	while (i<n)
    {
		int wylosowana_liczba = gen.Next(1, 10);
		if (!tab.Contains(wylosowana_liczba))
		{ tab[i] = wylosowana_liczba;
			i++;
		}
    }
}

}
