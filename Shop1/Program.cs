using System;

namespace Shop1
{
	class Program
	{
		public static void Main(string[] args)
		{
			Shop Auto = new Shop();
			Customer Human = new Customer();
			int tmp = -1;
			bool exit = false;
			bool quit = false;
			bool more = false;
			do
			{
				if (!more) 
				{
					Human = new Customer();
				}
				tmp = -1;
				while(tmp != 0)
				{
					Console.WriteLine("Enter your money or 0 to choose smth");
					tmp = int.Parse(System.Console.ReadLine());
					if(tmp != 0)
					{
						if(Auto.insert(tmp))
						{
							Human.in_coin(tmp);
						}
					}
				}
				
				tmp = -1;
				
				while(tmp != 0 || tmp != 4 || tmp != 5)
				{
					Console.WriteLine("Enter 1 to choose cake, 2 to biscuit, 3 to wafer"+
					                         ", 4 to get renting, 5 to insert more money,"+
													" 0 to exit or 9 to switch off the machine");
					tmp = int.Parse(Console.ReadLine());
					if (tmp == 9)
					{
						quit = true;
						break;
					}
					if (tmp == 4)
					{
						Human.get_rentig(Auto.renting());
						continue;
					} else if (tmp == 5) {
						more = true;
						break;
					} else if (tmp == 0) {
						exit = true;
						break;
					} else {
						Auto.Choose(tmp);
					}
				}
				if (quit == true) break;
				if (more == true) 
				{
					continue;
				}
				if (exit == true)
				{
					more = false;
					continue;
				}
					
			} while (!quit);
			
			Console.WriteLine("Good Bye ^^");
			Console.ReadKey(true);
		}
	}
	
	class Shop
	{
		int[] monets;
		int[] goods;
		int  made;
		
		public Shop()
		{
			Console.WriteLine("Welcome!");
			monets = new int[4];
			goods = new int[3];
			goods[0] = 4;
			goods[1] = 3;
			goods[2] = 10;
			made = 0;
		}
		
		public bool insert(int a)
		{
			switch (a)
			{
				case 1:
					monets[0]++;
					made +=1;
					return true;
				case 2:
					monets[1]++;
					made += 2;
					return true;
				case 5:
					monets[2]++;
					made += 5;
					return true;
				case 10:
					monets[3]++;
					made += 10;
					return true;
				default:
					Console.WriteLine("Wrong coin");
					return false;
			}
		}
		
		public int renting()
		{
			int t_made = 0;
			int[] t_mon = new int[4];
			
			while(made - t_made >= 10 && t_mon[3] < monets[3])
			{
				t_made += 10;
				t_mon[3]++;
			}
			while(made - t_made >= 5 && t_mon[2] < monets[2])
			{
				t_made += 5;
				t_mon[2]++;
			}
			while(made - t_made >= 2 && t_mon[1] < monets[1])
			{
				t_made += 2;
				t_mon[1]++;
			}
			while(made - t_made >= 1 && t_mon[0] < monets[0])
			{
				t_made += 1;
				t_mon[0]++;
			}
			
			if (t_made == made)
			{
				for(int i = 0; i < 4; i++)
				{
					monets[i] -= t_mon[i];
				}
				made = 0;
				return t_made;
			}
			else
			{
				Console.WriteLine("Smth wrong, call staff");
				return 0;
			}
		}
		
		
		public bool Choose(int a)
		{
			switch(a)
			{
				case 1:
					if (made >= 50 && goods[0] > 0)
					{
						Console.WriteLine("Take your cake");
						made -= 50;
						goods[0]--;
						return true;
					}
					
					if (made < 50)
					{
						Console.WriteLine("Not enought money");
					}
					if (goods[0] == 0)
					{
						Console.WriteLine("Not enoght cakes");
					}
					return false;
				case 2:
					if (made >= 30 && goods[1] > 0)
					{
						Console.WriteLine("Take your biscuit");
						made -= 30;
						goods[1]--;
						return true;
					}
					
					if (made < 30)
					{
						Console.WriteLine("Not enought money");
					}
					if (goods[1] == 0)
					{
						Console.WriteLine("Not enoght buscuit");
					}
					return false;
				case 3:
					if (made >= 10 && goods[2] > 0)
					{
						Console.WriteLine("Take your wafer");
						made -= 10;
						goods[2]--;
						return true;
					}
					
					if (made < 10)
					{
						Console.WriteLine("Not enought money");
					}
					if (goods[2] == 0)
					{
						Console.WriteLine("Not enoght wafers");
					}
					return false;
				default:
					Console.WriteLine("Wrong goods");
					return false;
			}
		}
	}

	
	class Customer
	{
		int purse;
		
		public Customer()
		{
			purse = 150;
			Console.WriteLine("New Customer");
		}
		public void in_coin(int a)
		{
			if (purse - a < 0)
			{
				Console.WriteLine("Such coins are over");
			} else
			{
				purse -= a;
			}
		}
		public void get_rentig(int a)
		{
			purse += a;
		}
	}
}