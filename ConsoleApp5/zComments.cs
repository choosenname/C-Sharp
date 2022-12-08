/*static void Main(string[] args)
       {
           ArmoredOgr armoredOgr = new ArmoredOgr("Куско", 300, 250, 14, SexEnum.Male, 15, 15);
           Ogr ogr = new Ogr("игорь Бруско", 350, 300, 25, SexEnum.None, 30);
           Wyvern wyvern = new Wyvern("Дребр", 500, 250, 45, SexEnum.Female, 28);


           ArrayMythicalCreature array = new ArrayMythicalCreature
           {
               new MythicalCreature[] { armoredOgr, ogr, wyvern,
               new Ogr("лешка", 250, 300, 30, SexEnum.Male, 50),
               new ArmoredOgr("cursed", 300, 400, 25, SexEnum.Female, 100, 30),
               new Dragon("draconchik", 1500, 1500, 10, SexEnum.None),
               new ArmoredOgr("John Xina", 350, 500, 11, SexEnum.None, 75, 50),
               new ArmoredOgr("лепешка", 300, 400, 25, SexEnum.Female, 100, 30),}
           };

           int index = 0;
           foreach (var item in array)
               Console.WriteLine(index++ + ". " + item);


           Console.WriteLine("Метод IndexOf");
           Console.WriteLine(array.IndexOf(wyvern));


           Console.WriteLine("Метод Insert");

           Dragon dragon = new Dragon("Драгобебр", 2000, 2500, 300, SexEnum.Male);

           array.Insert(array.IndexOf(wyvern), dragon);

           index = 0;
           foreach (var item in array)
               Console.WriteLine(index++ + ". " + item);


           Console.WriteLine("Метод RemoveAt");
           array.RemoveAt(3);
           array.Show();


           Console.WriteLine("Метод Add");
           array.Add(wyvern);
           array.Show();


           Console.WriteLine("Метод Remove");
           array.Remove(new ArmoredOgr("лепешка", 300, 400, 25, SexEnum.Female, 100, 30));
           array.Show();


           Console.WriteLine("Метод Contains");
           Console.WriteLine(array.Contains(wyvern));


           Console.WriteLine("Метод CopyTo");
           MythicalCreature[] array1 = new MythicalCreature[array.Count + 4];
           array.CopyTo(array1, 4);
           index = 0;
           foreach (var item in array1)
               Console.WriteLine(index++ + ". " + item);

           array.SortByName();
           Console.WriteLine(array);

           MythicalCreature mythical = array.MaxDamage();
           Console.WriteLine(mythical);

           array.Clear();
           array.Show();

           /*ArrayMythicalCreature array1 = new ArrayMythicalCreature
           {
               new MythicalCreature[] { dragon,
               new ArmoredOgr("Лазупин", 300, 400, 25, MythicalCreature.SexEnum.Female, 100, 30)}
           };

           Console.WriteLine($"{array}\nVS\n{array1}");

           Console.WriteLine("\n\nПобедители:\n{0}", array.Figth(array1) > 0 ? array : array1);//

           Console.ReadLine();
       }*/