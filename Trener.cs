class Trener
{

    public string Jmeno { get; set; }
    public Cichnamon Aktualni { get; set; }
    public int Lvl { get; set; }

    public Trener(string jmeno, Cichnamon aktualni)
    {
        Jmeno = jmeno;
        Aktualni = aktualni;
        Lvl = 1; // zacatek: trener lvl1
    }
}
