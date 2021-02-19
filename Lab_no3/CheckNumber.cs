#region Using derectives

using System;

#endregion

namespace Lab_no3
{
	public class CheckNumber
	{
		public bool Check()
		{
			Console.WriteLine("Введите цифру (0-9)");

			if (Int32.TryParse(Console.ReadLine(), out var x))
			{
				switch (x)
				{
					case 0:
					{
						WriteNum("Ноль");

						break;
					}

					case 1:
					{
						WriteNum("Один");

						break;
					}

					case 2:
					{
						WriteNum("Два");

						break;
					}

					case 3:
					{
						WriteNum("Три");

						break;
					}

					case 4:
					{
						WriteNum("Четыре");

						break;
					}

					case 5:
					{
						WriteNum("Пять");

						break;
					}

					case 6:
					{
						WriteNum("Шесть");

						break;
					}

					case 7:
					{
						WriteNum("Семь");

						break;
					}

					case 8:
					{
						WriteNum("Восемь");

						break;
					}

					case 9:
					{
						WriteNum("Девять");

						break;
					}
				}

				return x >= 0 && x <= 9;
			}

			return false;
		}

		private void WriteNum(string num) => Console.WriteLine(num);

		public (bool, int) CheckInt()
		{
			if (Int32.TryParse(Console.ReadLine(), out var x)) return (true, x);

			return (false, Int32.MaxValue);
		}
	}
}