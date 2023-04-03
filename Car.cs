namespace CarSim
{
    public class Car
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public decimal initialDistance { get; set; }
        public decimal distanceRequired { get; set; }
        public int Speed { get; set; }
    }
}
