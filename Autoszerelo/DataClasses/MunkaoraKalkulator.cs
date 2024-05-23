namespace Autoszerelo.DataClasses
{
    public class MunkaoraKalkulator
    {
        private Munka _munka;
        public MunkaoraKalkulator(Munka munka)
        {
            _munka = munka;
        }

        public float GetCalculatedMunkaora()
        {
            return getKategoria() * getKor() * getSulyossag();
        }

        private float getKategoria()
        { 
            switch(_munka.MunkaKategoria)
            {
                case MunkaKategoria.Karosszeria:
                    return 3;
                case MunkaKategoria.Motor:
                    return 8;
                case MunkaKategoria.Futomu:
                    return 6;
                case MunkaKategoria.Fekberendezes:
                    return 4;
                default:
                    return 0;
            };
        }

        private float getKor()
        {
            int kor = DateTime.Today.Year - _munka.GyartasiEv.Year;

            if(kor < 5)
            {
                return 0.5f;
            }
            else if(kor < 10)
            {
                return 1f;
            }
            else if(kor < 20)
            {
                return 1.5f;
            }
            else 
            { 
                return 2f;
            }
        }

        private float getSulyossag()
        {
            if(_munka.HibaSulyossaga <= 2)
            {
                return 0.2f;
            }
            else if (_munka.HibaSulyossaga <= 4)
            {
                return 0.4f;
            }
            else if (_munka.HibaSulyossaga <= 7)
            {
                return 0.6f;
            }
            else if (_munka.HibaSulyossaga <= 9)
            {
                return 0.8f;
            }
            else
            {
                return 1;
            }
        }
    }
}
