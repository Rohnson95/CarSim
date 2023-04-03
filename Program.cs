namespace CarSim
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Car Simulator!");
            Console.ReadKey();


            Car firstCar = new Car
            {
                Id = 1,
                Name = "Lightning McQueen",
                initialDistance = 0,
                distanceRequired = 10000,
                Speed = 120
            };

            var firstCarTask = CarRace(firstCar);

            var carTasks = new List<Task> { firstCarTask };

            while (carTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(carTasks);

                if (finishedTask == firstCarTask)
                {
                    Console.WriteLine("First Car is done!");
                    Car carResult = firstCarTask.Result;
                    PrintCars(carResult);
                }
                await finishedTask;
                carTasks.Remove(finishedTask);
                Console.ReadKey();
            }
        }

        public async static Task Wait(int delay = 1)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));
            Console.WriteLine(".");
        }
        public static void PrintCars(Car car)
        {
            Console.WriteLine($"{car.Name} has finished the race and driven {car.initialDistance}");
        }

        public async static Task<Car> CarRace(Car car)
        {
            //Var 30e sekund ska något hända. Efter 30 sekunder har bilarna färdats 1km förutsatt att inget gått fel
            //hur ska vi då skriva detta
            //Bilen har en hastighet på 120km/h, det tar 5 minuter för den att färdas sträckan
            //120km/h är 33,33 m/s
            //Måste skapa nån form av distans som den ska upp till
            int time = 30;

            while (true)
            {
                await Wait(time);
                Console.WriteLine($"30 seconds of driving has occurred! and the distance is now:{car.initialDistance} ");

                //Bilen kör med 33.33m/s
                //
                car.initialDistance += (33.33M * time);

                if (car.initialDistance >= car.distanceRequired)
                {
                    return car;
                }



            }

        }

    }
}