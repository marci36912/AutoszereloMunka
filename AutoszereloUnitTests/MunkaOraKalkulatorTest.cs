using Autoszerelo.DataClasses;

namespace AutoszereloUnitTests
{
    public class MunkaOraKalkulatorTest
    {
        [Theory]
        [InlineData(MunkaKategoria.Karosszeria, 1.5)]
        [InlineData(MunkaKategoria.Motor, 4)]
        [InlineData(MunkaKategoria.Futomu, 3)]
        [InlineData(MunkaKategoria.Fekberendezes, 2)]
        public void GetCalculatedMunkaora_WithDifferentCategories_ReturnsExpectedResult(MunkaKategoria kategoria, float expected)
        {
            DateOnly manufacturingDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-1));
            Munka munka = new Munka()
            {
                MunkaKategoria = kategoria,
                GyartasiEv = manufacturingDate,
                HibaSulyossaga = 10
            };

            var actual = new MunkaoraKalkulator(munka).GetCalculatedMunkaora();

            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(4, 1.5)]
        [InlineData(9, 3)]
        [InlineData(19, 4.5)]
        [InlineData(21, 6)]
        public void GetCalculatedMunkaora_WithDifferentAges_ReturnsExpectedResult(int kor, float expected)
        {
            DateOnly manufacturingDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-kor));
            Munka munka = new Munka()
            {
                MunkaKategoria = MunkaKategoria.Karosszeria,
                GyartasiEv = manufacturingDate,
                HibaSulyossaga = 10
            };

            var actual = new MunkaoraKalkulator(munka).GetCalculatedMunkaora();

            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(1, 1.6f)]
        [InlineData(3, 3.2f)]
        [InlineData(5, 4.8f)]
        [InlineData(8, 6.4f)]
        [InlineData(10, 8)]
        public void GetCalculatedMunkaora_WithDifferentFlawScores_ReturnsExpectedResult(int sulyossag, float expected)
        {
            DateOnly manufacturingDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-6));
            Munka munka = new Munka()
            {
                MunkaKategoria = MunkaKategoria.Motor,
                GyartasiEv = manufacturingDate,
                HibaSulyossaga = sulyossag
            };

            var actual = new MunkaoraKalkulator(munka).GetCalculatedMunkaora();

            Assert.Equal(actual, expected);
        }
    }
}