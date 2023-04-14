using UnityEngine;

namespace Script.Locations
{
    public class VehicleShop : MonoBehaviour
    {
        public Timer timer;
        
        public AudioSource coinSFX;
        public AudioSource actionFailSFX;

        public void BuyBicycle()
        {
            const int price = 500;
            const int happy = 50;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price && player.GetVehicle() == Vehicle.None)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+happy);
                player.SetVehicle(Vehicle.Bicycle);
                GameManager.Instance.ShowFloatingText($"{player.name}: Buy {Vehicle.Bicycle}");
                timer.DecreaseTime(2);
            }
            else if (player.GetVehicle() != Vehicle.None)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: Own {player.GetVehicle()}");
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuyMotorcycle()
        {
            const int price = 1000;
            const int happy = 100;


            var player = GameManager.Instance.GetPlayer();

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
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+happy);

                player.SetVehicle(Vehicle.Motorcycle);
                GameManager.Instance.ShowFloatingText($"{player.name}: Buy {Vehicle.Motorcycle}");
                timer.DecreaseTime(2);
            }
            else if (!canBuy)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: Own {player.GetVehicle()}");
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuyCar()
        {
            const int price = 2000;
            const int happy = 200;

            Player player = GameManager.Instance.GetPlayer();

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
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+happy);

                player.SetVehicle(Vehicle.Car);
                GameManager.Instance.ShowFloatingText($"{player.name}: Buy {Vehicle.Car}");
                timer.DecreaseTime(2);
            }
            else if (!canBuy)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: Own {player.GetVehicle()}");
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void BuySuperCar()
        {
            const int price = 5000;
            const int happy = 500;

            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price && player.GetVehicle() != Vehicle.SuperCar)
            {
                coinSFX.Play();
                player.SetWealth(-price);
                player.SetHealth(+happy);

                player.SetVehicle(Vehicle.SuperCar);
                GameManager.Instance.ShowFloatingText($"{player.name}: Buy {Vehicle.SuperCar}");
                timer.DecreaseTime(2);
            }
            else if (player.GetVehicle() == Vehicle.SuperCar)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: Own {player.GetVehicle()}");
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText("No Money");
            }
        }

        public void Work()
        {
            var player = GameManager.Instance.GetPlayer();

            if (player.GetJob() == Job.Vehicle)
            {
                coinSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: work at {Job.Vehicle}");

                player.SetWealth(50);
                player.SetWorkExp(10);
                player.SetBurnOut(15);

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.name}: You did not apply for {Job.Vehicle}");
            }
        }
    }
}

