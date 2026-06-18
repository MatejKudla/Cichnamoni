class Program
{

    // Vypis jmeno Cichnamona + HP
    static void VypisStav(Cichnamon cichnamon)
    {
        if (cichnamon.Hp < 0){
            cichnamon.Hp = 0;
        }
        Console.WriteLine(cichnamon.Jmeno + ": " + cichnamon.Hp + " HP");
    }

    static void Main()
    {
        Random nahoda = new Random();

        // Tvorba utoku
        Utok ember = new Utok("Ember");
        Utok blastBurn = new Utok("Blast Burn");
        Utok waterGun = new Utok("Water Gun");
        Utok hydroPump = new Utok("Hydro Pump");
        Utok thunderShock = new Utok("Thunder Shock");
        Utok thunderbolt = new Utok("Thunderbolt");

        // Moznosti Cichnamonu pro hrace
        Cichnamon[] nabidka = new Cichnamon[2];
        nabidka[0] = new Cichnamon("Chadrizzard", 40, ember, blastBurn);
        nabidka[1] = new Cichnamon("Blastoiser", 45, waterGun, hydroPump);

        // cichnamon pro pocitac
        Cichnamon PocitacCichnamon = new Cichnamon("Crazy Pikacho", 35, thunderShock, thunderbolt);

        // Vyber cichnamona pro hrace
        Console.WriteLine("Vyber si sveho Cichnamona:");
        Console.WriteLine("1 - " + nabidka[0].Jmeno);
        Console.WriteLine("2 - " + nabidka[1].Jmeno);
        Console.Write("Zadej cislo: ");
        string volbaHrace = Console.ReadLine();

        Cichnamon hracuvCichnamon;

        if (volbaHrace == "1"){
            hracuvCichnamon = nabidka[0]; // Vybral Chadrizzarda
        }

        else{
            hracuvCichnamon = nabidka[1]; // Vybral Blastoiser
        }


        Trener hrac = new Trener("Hrac", hracuvCichnamon);
        Trener oponent = new Trener("Pocitac", PocitacCichnamon);

        Console.WriteLine("\nzacatek souboje");

        Cichnamon hracuvAktualni = hrac.Aktualni;
        Cichnamon oponentuvAktualni = oponent.Aktualni;

        VypisStav(hracuvAktualni);
        VypisStav(oponentuvAktualni);
        Console.WriteLine("----------------------------------------");

        // hlavni while pro vyber moznosti utoku a heal a souboj
        while (hracuvAktualni.Hp > 0 && oponentuvAktualni.Hp > 0)
        {
            Console.WriteLine("1 - Zakladni utok");
            Console.WriteLine("2 - Specialni utok");
            Console.WriteLine("3 - Heal");
            Console.Write("Vyber moznost: ");
            string akce = Console.ReadLine();

            Console.WriteLine(); // prazdnej radek 

            // vyber hrace
            if (akce == "1")
                {
                    hracuvAktualni.UtocZakladnim(oponentuvAktualni, nahoda);
                    }
                else if (akce == "2")
                    {
                        hracuvAktualni.UtocSpecialnim(oponentuvAktualni, nahoda);
                        }
                    else
                    {
                        hracuvAktualni.VyleciSe();
                        }

            VypisStav(oponentuvAktualni);

            if (oponentuvAktualni.Hp > 0)
            {
                Console.WriteLine("\n   hraje souper");

                int volbaPocitace = nahoda.Next(1, 4);
            // volba pocitace
                if (volbaPocitace == 1)
                    {
                        oponentuvAktualni.UtocZakladnim(hracuvAktualni, nahoda);
                        }
                    else if (volbaPocitace == 2)
                        {
                            oponentuvAktualni.UtocSpecialnim(hracuvAktualni, nahoda);
                            }
                        else
                            { 
                                oponentuvAktualni.VyleciSe();
                                }

                VypisStav(hracuvAktualni);
            }

            Console.WriteLine("\n----------------------------------------");
        }

        Console.WriteLine("\n    KONEC HRY ");

        Console.ReadLine();

        // lvl trenera + 1
        if (oponentuvAktualni.Hp <= 0)
        {
            hrac.Lvl += 1;
            Console.WriteLine(hrac.Jmeno + " ziskal lvl! Aktualni lvl: " + hrac.Lvl);
        }
    }
}
