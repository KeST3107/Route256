using NUnit.Framework;

namespace Route256

{
    [TestFixture]
    public class TaskTest
    {
        [Test]
        public void ATaskTest()
        {
            var input = "hEllo world! nUnIt TesT. тАКжЕ рАбоТаЕт нА РУССКОМ";
            var output = "Hello World! Nunit Test. Также Работает На Русском";

            var input1 = "hEllo world! nUnIt TesT.";
            var output1 = "hEllo world! nUnIt TesT.";

            var input2 = "hEllo world! nUnIt TesT. тАКжЕ рАбоТаЕт нА РУССКОМ hEllo world! nUnIt TesT. тАКжЕ рАбоТаЕт нА РУССКОМ";
            var output2 = "Hello World! Nunit Test. Также Работает На Русском Hello World! Nunit Test. Также Работает На Русском";

            Assert.That(ATask.Run(input) == output, Is.True);
            Assert.That(ATask.Run(input1) == output1, Is.False);
            Assert.That(ATask.Run(input2) == output2, Is.True);
        }

        [Test]
        public void BTaskTest()
        {
            var input = "Привет мир!Привет мир!Привет мир!Привет мир!Привет мир!Привет мир!Привет мир!Привет мир!Привет мир!Привет мир!";
            var output = "1111111122123322222442355333336634774444488459955555101056111166666121267131377777141478151588888161689171799999181891019191010101010202010";

            var input1 = "FFFFFFFFFFFFFFFFF";
            var output1 = "1234567891011121314151617";

            var input2 = "01234567890123456789";
            var output2 = "11111111112222222222";

            var input3 = "FFFFFFFFFFFFFFFFF";
            var output3 = "11111111112222222222";

            Assert.That(BTask.Run(input) == output, Is.True);
            Assert.That(BTask.Run(input1) == output1, Is.True);
            Assert.That(BTask.Run(input2) == output2, Is.True);
            Assert.That(BTask.Run(input3) == output3, Is.False);
        }

        [Test]
        public void CTaskTest()
        {
            var input = "10.0.0.0 10.0.0.50";
            var output = "50";

            var input1 = "159.197.181.188 160.138.68.148";
            var output1 = "12881624";

            var input2 = "10.0.0.0 10.0.0.150";
            var output2 = "149";

            var input3 = "10.0.0.0 10.0.0.250";
            var output3 = "100";

            Assert.That(CTask.Run(input) == output, Is.True);
            Assert.That(CTask.Run(input1) == output1, Is.True);
            Assert.That(CTask.Run(input2) == output2, Is.False);
            Assert.That(CTask.Run(input3) == output3, Is.False);
        }

        [Test]
        public void DTaskTest()
        {
            var input = "1000 2000 1000 2000 5000";
            var output = "True";

            var input1 = "2000 2000 1000 2000 5000";
            var output1 = "False";

            var input2 = "5000 2000 1000 2000 5000";
            var output2 = "True";

            var input3 = "1000 2000 1000 2000 5000 1000 2000 5000 1000 2000 2000 2000 1000 1000 1000 5000 5000 5000";
            var output3 = "True";

            Assert.That(DTask.Run(input) == output, Is.True);
            Assert.That(DTask.Run(input1) == output1, Is.True);
            Assert.That(DTask.Run(input2) == output2, Is.False);
            Assert.That(DTask.Run(input3) == output3, Is.False);
        }
        [Test]
        public void ETaskTest()
        {
            var input = "MMLXII MMLX";
            var output = "1";

            var input1 = "MMLX MMLXII";
            var output1 = "-1";

            var input2 = "MMLXII MMLXII";
            var output2 = "0";

            var input3 = "MMLXII MMLXII";
            var output3 = "1";

            Assert.That(ETask.Run(input) == output, Is.True);
            Assert.That(ETask.Run(input1) == output1, Is.True);
            Assert.That(ETask.Run(input2) == output2, Is.True);
            Assert.That(ETask.Run(input3) == output3, Is.False);
        }
        [Test]
        public void FTaskTest()
        {
            var input = "a&b|c=d&!a a True b False c True d True";
            var output = "False";

            var input1 = "a&b|c=d&!a a True b False c False d True";
            var output1 = "True";

            var input2 = "a&b|c=d&!a=a&b|c=d&!a=a&b|c=d&!a a True b True c True d False";
            var output2 = "False";

            var input3 = "a=b=c=d=e a True b True c True d True e False";
            var output3 = "True";

            Assert.That(FTask.Run(input) == output, Is.True);
            Assert.That(FTask.Run(input1) == output1, Is.True);
            Assert.That(FTask.Run(input2) == output2, Is.True);
            Assert.That(FTask.Run(input3) == output3, Is.False);
        }
    }
}
