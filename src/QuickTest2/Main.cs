using System;

namespace QuickTest2
{
	class MainClass
	{
		public static void PrintArray(Array b)
		{
			Console.Write("[");
			for (int ii = 0; ii < b.Rank; ii++) 
			{
				if (ii > 0)
					Console.Write(",");
				Console.Write(b.GetLength(ii));
			}
			Console.WriteLine("]");
			if (b.Rank == 2) {
				int nr = b.GetLength(0);
				int nc = b.GetLength(1);
				for (int ii = 0; ii < nr; ii++)
				{
					for (int jj = 0; jj < nc; jj++)
					{
						if (jj > 0)
							Console.Write(",");
						int[] index = new int[2]{ii,jj};
						Console.Write(b.GetValue(index));
						
					}
					Console.WriteLine("");
				}
			} else if (b.Rank == 1) {
				for (int ii = 0; ii < b.GetLength (0); ii++)
				{
					if (ii > 0)
						Console.Write(",");
					Console.Write(b.GetValue(ii));
					
				}
				Console.WriteLine("");
			} else {
				Console.WriteLine("Result matrix has rank > 2");	
			}
		}
		public static void Main (string[] args)
		{
			//int[,] a = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
			//var b = Boo.Lang.Runtime.RuntimeServices.GetMultiDimensionalRange1(a,new int[]{3,0,0,1},new bool[] {true,false});
			int[,] a = new int[2, 2] { { 1, 2 }, { 3, 4 } };
			var b = Boo.Lang.Runtime.RuntimeServices.GetMultiDimensionalRange1(a,new int[]{0,1,0,0},new bool[] {false,true}, new bool[] {true, false});
			PrintArray(a);
			PrintArray(b);
			
		}
	}
}
