using System;
using FakeData;

namespace FakesDataGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = FakeDataInitializer.Init(2, true);
        }
    }
}