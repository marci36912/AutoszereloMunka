using Autoszerelo.DataClasses;

namespace AutoszereloUnitTests
{
    public class MunkaOraKalkulatorTest
    {
        [Theory]
        [InlineData(MunkaKategoria.Karosszeria, 1, 10, 1.5)]
        [InlineData(MunkaKategoria.Motor, 1, 10, 4)]
        [InlineData(MunkaKategoria.Futomu, 1, 10, 3)]
        [InlineData(MunkaKategoria.Fekberendezes, 1, 10, 2)]
        public void GetCalculatedMunkaora_WithDifferentCategories_ReturnsExpectedResult(MunkaKategoria kategoria, int kor, int sulyossag, float expected)
        {
            DateOnly manufacturingDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-kor));
            Munka munka = new Munka()
            {
                MunkaKategoria = kategoria,
                GyartasiEv = manufacturingDate,
                HibaSulyossaga = sulyossag
            };

            var actual = new MunkaoraKalkulator(munka).GetCalculatedMunkaora();

            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(MunkaKategoria.Karosszeria, 4, 10, 1.5)]
        [InlineData(MunkaKategoria.Karosszeria, 9, 10, 3)]
        [InlineData(MunkaKategoria.Karosszeria, 19, 10, 4.5)]
        [InlineData(MunkaKategoria.Karosszeria, 21, 10, 6)]
        public void GetCalculatedMunkaora_WithDifferentAges_ReturnsExpectedResult(MunkaKategoria kategoria, int kor, int sulyossag, float expected)
        {
            DateOnly manufacturingDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-kor));
            Munka munka = new Munka()
            {
                MunkaKategoria = kategoria,
                GyartasiEv = manufacturingDate,
                HibaSulyossaga = sulyossag
            };

            var actual = new MunkaoraKalkulator(munka).GetCalculatedMunkaora();

            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(MunkaKategoria.Karosszeria, 1, 1, 0.3)]
        [InlineData(MunkaKategoria.Karosszeria, 1, 3, 0.6)]
        [InlineData(MunkaKategoria.Karosszeria, 1, 5, 0.9)]
        [InlineData(MunkaKategoria.Karosszeria, 1, 8, 1.2)]
        [InlineData(MunkaKategoria.Karosszeria, 1, 10, 1.5)]
        public void GetCalculatedMunkaora_WithDifferentFlawScores_ReturnsExpectedResult(MunkaKategoria kategoria, int kor, int sulyossag, float expected)
        {
            DateOnly manufacturingDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-kor));
            Munka munka = new Munka()
            {
                MunkaKategoria = kategoria,
                GyartasiEv = manufacturingDate,
                HibaSulyossaga = sulyossag
            };

            var actual = new MunkaoraKalkulator(munka).GetCalculatedMunkaora();

            Assert.Equal(actual, expected);
        }
    }
}