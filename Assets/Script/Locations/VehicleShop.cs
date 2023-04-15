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


            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price && player.GetVehicle() == Vehicle.None)
            {
                coinSFX.Play();
                player.SetWealth(-price);

                player.SetVehicle(Vehicle.Bicycle);
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Buy {Vehicle.Bicycle}");
                timer.DecreaseTime(2);
            }
            else if (player.GetVehicle() != Vehicle.None)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Own {player.GetVehicle()}");
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


                player.SetVehicle(Vehicle.Motorcycle);
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Buy {Vehicle.Motorcycle}");
                timer.DecreaseTime(2);
            }
            else if (!canBuy)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Own {player.GetVehicle()}");
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


                player.SetVehicle(Vehicle.Car);
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Buy {Vehicle.Car}");
                timer.DecreaseTime(2);
            }
            else if (!canBuy)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Own {player.GetVehicle()}");
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


            var player = GameManager.Instance.GetPlayer();

            if (player.GetWealth() >= price && player.GetVehicle() != Vehicle.SuperCar)
            {
                coinSFX.Play();
                player.SetWealth(-price);


                player.SetVehicle(Vehicle.SuperCar);
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Buy {Vehicle.SuperCar}");
                timer.DecreaseTime(2);
            }
            else if (player.GetVehicle() == Vehicle.SuperCar)
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: Own {player.GetVehicle()}");
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

            const int baseSalary = 50;
            const int workExp = 1;
            const int burnOut = 15;

            var salary = Mathf.CeilToInt(baseSalary * (1 + player.GetWorkExp() / 100f + player.GetEducation() / 100f));

            if (player.GetJob() == Job.University)
            {
                coinSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: work at {Job.University}");

                player.SetWealth(+salary);
                player.SetWorkExp(+workExp);
                player.SetBurnOut(+burnOut);

                timer.DecreaseTime(2);
            }
            else
            {
                actionFailSFX.Play();
                GameManager.Instance.ShowFloatingText($"{player.GetName()}: You did not apply for {Job.University}");
            }
        }
    }
}