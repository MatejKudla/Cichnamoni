class Cichnamon
{
    public string Jmeno { get; set; }
    public int Hp { get; set; }
    public int MaxHp { get; set; }
    public Utok ZakladniUtok { get; set; }
    public Utok SpecialniUtok { get; set; }

    public Cichnamon(string jmeno, int maxHp, Utok zakladniUtok, Utok specialniUtok)
    {
        Jmeno = jmeno;
        MaxHp = maxHp;
        Hp = maxHp; // Na zacatku je full HP
        ZakladniUtok = zakladniUtok;
        SpecialniUtok = specialniUtok;

    }
    // ZakladniUtok
    public void UtocZakladnim(Cichnamon obet, Random nahoda)
    {
        int maxDmg = obet.Hp / 3;
        if (maxDmg < 1) maxDmg = 1;

        int finalDmg = nahoda.Next(1, maxDmg + 1);
        obet.Hp -= finalDmg;

        Console.WriteLine(this.Jmeno + " pouzil " + this.ZakladniUtok.Nazev + " a dal " + finalDmg + " dmg.");
    }
    // SpecialniUtok
    public void UtocSpecialnim(Cichnamon obet, Random nahoda)
    {
        int minDmg = obet.Hp / 3;
        int maxDmg = obet.Hp / 2;
        if (maxDmg <= minDmg)
            {
                maxDmg = minDmg + 1;
                }
        int finalDmg = nahoda.Next(minDmg, maxDmg + 1);
        obet.Hp -= finalDmg;

        Console.WriteLine(this.Jmeno + " vyvolal " + this.SpecialniUtok.Nazev + " a dal " + finalDmg + " dmg.");
    }
    // Heal
    public void VyleciSe()
    {
        int hodnotaHealu = (this.Hp * 30) / 100;

        this.Hp += hodnotaHealu;
        if (this.Hp > this.MaxHp)
            {
                this.Hp = this.MaxHp;
                    }

        Console.WriteLine(this.Jmeno + " se vylecil o " + hodnotaHealu + " HP.");
    }

}

