using Large_Factorial;

namespace TestProject
{

    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
               Assert.That(Kata.Factorial(1), Is.EqualTo("1"));
               Assert.That(Kata.Factorial(5), Is.EqualTo("120"));
               Assert.That(Kata.Factorial(9), Is.EqualTo("362880"));
               Assert.That(Kata.Factorial(15), Is.EqualTo("1307674368000"));
        }

        [Test]
        public void ExtendedTests()
        {
            Assert.That(Kata.Factorial(100), Is.EqualTo("93326215443944152681699238856266700490715968264381621468592963895217599993229915608941463976156518286253697920827223758251185210916864000000000000000000000000"));
            Assert.That(Kata.Factorial(150), Is.EqualTo("57133839564458545904789328652610540031895535786011264182548375833179829124845398393126574488675311145377107878746854204162666250198684504466355949195922066574942592095735778929325357290444962472405416790722118445437122269675520000000000000000000000000000000000000"));
            Assert.That(Kata.Factorial(200), Is.EqualTo("788657867364790503552363213932185062295135977687173263294742533244359449963403342920304284011984623904177212138919638830257642790242637105061926624952829931113462857270763317237396988943922445621451664240254033291864131227428294853277524242407573903240321257405579568660226031904170324062351700858796178922222789623703897374720000000000000000000000000000000000000000000000000"));
            Assert.That(Kata.Factorial(250), Is.EqualTo("3232856260909107732320814552024368470994843717673780666747942427112823747555111209488817915371028199450928507353189432926730931712808990822791030279071281921676527240189264733218041186261006832925365133678939089569935713530175040513178760077247933065402339006164825552248819436572586057399222641254832982204849137721776650641276858807153128978777672951913990844377478702589172973255150283241787320658188482062478582659808848825548800000000000000000000000000000000000000000000000000000000000000"));
        }

        [Test]
        public void RandomTests()
        {
            var rand = new Random();

            Func<int, string> qwerty = delegate (int n)
            {
                var res = new List<int> { 1 };
                for (var i = 2; i <= n; ++i)
                {
                    var c = 0;
                    for (var j = 0; j < res.Count || c != 0; j++)
                    {
                        c += (j < res.Count ? res[j] : 0) * i;
                        if (res.Count <= j)
                        {
                            res.Add(c % 10);
                        }
                        else
                        {
                            res[j] = c % 10;
                        }
                        c = c / 10;
                    }
                }
                return string.Concat(res.ToArray().Reverse().ToArray());
            };

            for (var i = 0; i < 10; i++)
            {
                var a = rand.Next(0, 10);
                var expected = qwerty(a);
                Assert.That(Kata.Factorial(a), Is.EqualTo(expected), a + "!");
            }

            for (var i = 0; i < 10; i++)
            {
                var a = rand.Next(0, 80) + 100;
                var expected = qwerty(a);
                Assert.That(Kata.Factorial(a), Is.EqualTo(expected), a + "!");
            }
        }
    }
}