using System;
using BuilderDesign;
using Xunit;


namespace Builder.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var build = new HeroBuilder();
            var value = new VehicleCreator(build);
            value.CreateVehicle();
            var a = value.GetVehicle();

            Assert.Equal("Hero", a.Model);
            Assert.Equal("4 Stroke", a.Engine);
            Assert.Equal("Plastic", a.Body);
            Assert.Equal("120 km/hr", a.Transmission);
            Assert.Equal("Seat Cover", a.Accessories[0]);
            Assert.Equal("Rear Mirror", a.Accessories[1]);

        }

        [Fact]
        public void Test2()
        {
            var build = new HondaBuilder();
            var value = new VehicleCreator(build);
            value.CreateVehicle();
            var a = value.GetVehicle();

            Assert.Equal("Honda", a.Model);
            Assert.Equal("4 Stroke", a.Engine);
            Assert.Equal("Plastic", a.Body);
            Assert.Equal("125 km/hr", a.Transmission);
            Assert.Equal("Seat Cover", a.Accessories[0]);
            Assert.Equal("Rear Mirror", a.Accessories[1]);
            Assert.Equal("Helmet", a.Accessories[2]);

        }
    }
}
