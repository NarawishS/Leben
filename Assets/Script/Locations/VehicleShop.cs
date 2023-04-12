using UnityEngine;

namespace Script.Locations
{
    public class VehicleShop : MonoBehaviour
    {
        public Timer timer;

        public void BuyBicycle()
        {
            const int price = 500;
            const int happy = 50;

            var player = GameManager.instance.GetPlayer();

            if (player.GetWealth() >= price && player.GetVehicle() == Vehicle.None)
            {
                player.SetWealth(-price);
                player.SetHealth(+happy);
                player.SetVehicle(Vehicle.Bicycle);
                Debug.Log($"{player.name}: Buy {Vehicle.Bicycle}");
                timer.DecreaseTime(2);
            }
            else if (player.GetVehicle() != Vehicle.None)
            {
                Debug.Log($"{player.name}: Own {player.GetVehicle()}");
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void BuyMotorcycle()
        {
            const int price = 1000;
            const int happy = 100;


            var player = GameManager.instance.GetPlayer();

            Vehicle[] vehicles = { Vehicle.Motorcycle, Vehicle.Car, Vehicle.SuperCar };
            var canBuy = true;
            
            foreach (var vehicle in vehicles)
            {
                if (player.GetVehicle().Equals(vehicle))
                {
                    canBuy = false;
                    break;
                }
            }

            if (player.GetWealth() >= price && canBuy)
            {
                player.SetWealth(-price);
                player.SetHealth(+happy);

                player.SetVehicle(Vehicle.Motorcycle);
                Debug.Log($"{player.name}: Buy {Vehicle.Motorcycle}");
                timer.DecreaseTime(2);
            }
            else if (!canBuy)
            {
                Debug.Log($"{player.name}: Own {player.GetVehicle()}");
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void BuyCar()
        {
            const int price = 2000;
            const int happy = 200;

            Player player = GameManager.instance.GetPlayer();

            Vehicle[] vehicles = { Vehicle.Car, Vehicle.SuperCar };
            var canBuy = true;
            
            foreach (var vehicle in vehicles)
            {
                if (player.GetVehicle().Equals(vehicle))
                {
                    canBuy = false;
                    break;
                }
            }

            if (player.GetWealth() >= price && canBuy)
            {
                player.SetWealth(-price);
                player.SetHealth(+happy);

                player.SetVehicle(Vehicle.Car);
                Debug.Log($"{player.name}: Buy {Vehicle.Car}");
                timer.DecreaseTime(2);
            }
            else if (!canBuy)
            {
                Debug.Log($"{player.name}: Own {player.GetVehicle()}");
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void BuySuperCar()
        {
            const int price = 5000;
            const int happy = 500;

            var player = GameManager.instance.GetPlayer();

            if (player.GetWealth() >= price && player.GetVehicle() != Vehicle.SuperCar)
            {
                player.SetWealth(-price);
                player.SetHealth(+happy);

                player.SetVehicle(Vehicle.SuperCar);
                Debug.Log($"{player.name}: Buy {Vehicle.SuperCar}");
                timer.DecreaseTime(2);
            }
            else if (player.GetVehicle() == Vehicle.SuperCar)
            {
                Debug.Log($"{player.name}: Own {player.GetVehicle()}");
            }
            else
            {
                Debug.Log("No Money");
            }
        }

        public void Work()
        {
            var player = GameManager.instance.GetPlayer();

            if (player.GetJob() == Job.Vehicle)
            {
                Debug.Log($"{player.name}: work at {Job.Vehicle}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

                timer.DecreaseTime(2);
            }
            else
            {
                Debug.Log($"{player.name}: You did not apply for {Job.Vehicle}");
            }
        }
    }
}

