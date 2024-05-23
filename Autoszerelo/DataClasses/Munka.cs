﻿namespace Autoszerelo.DataClasses
{
    public class Munka
    {
        public Guid MunkaAzonosito { get; private set; }
        public Guid UgyfelSzam {  get; private set; }
        //regex
        public string Rendszam { get; private set; }
        //validacio
        public DateOnly GyartasiEv {  get; private set; }
        public MunkaKategoria MunkaKategoria { get; private set; }
        public string HibaRovidLeirasa { get; private set; }
        //validacio
        public int HibaSulyossaga { get; private set; }
        public MunkaAllapot MunkaAllapot { get; private set; }
    }
}
