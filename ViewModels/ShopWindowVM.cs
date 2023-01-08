using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TableGame.GameServices;
using TableGame.Units;

namespace TableGame.ViewModels
{
    public partial class ShopWindowVM : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(BuyUnitCommand))]
        private Unit selectedShopUnit;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SellUnitCommand))]
        private Unit selectedPlayerUnit;

        public ShopWindowVM(Player activePlayer)
        {
            this.ActivePlayer = activePlayer;
            shopUnits = new ObservableCollection<Unit>();
            
            // загрузка доступных типов юнита для игрока
            foreach(var unitType in activePlayer.PlayerFraction.FractionUnits)
            {
                // создание объекта на базе допусного типа юнита для игрока
                var unit = Activator.CreateInstance(unitType) as Unit;

                shopUnits.Add(unit);
            }
        }

        // передача активного игрока (получение листа юнитов фракии)
        [ObservableProperty]
        private Player activePlayer;

        [ObservableProperty]
        ObservableCollection<Unit> shopUnits;


        [RelayCommand]
        public void BuyUnit(Unit unit)
        {
            if (unit == null)
                return;

            if((ActivePlayer.Money - unit.Price) < 0)
            {
                MessageBox.Show("Недостаточно денег", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ActivePlayer.UnitsInInvertory.Add((Unit)Activator.CreateInstance(unit.GetType()));
            ActivePlayer.Money -= unit.Price;
        }

        [RelayCommand]
        public void SellUnit(Unit unit)
        {
            if (unit == null)
                return;

            ActivePlayer.UnitsInInvertory.Remove(unit);
            ActivePlayer.Money += unit.Price;
        }

        [RelayCommand]
        public void DebugAddMoney()
        {
            ActivePlayer.Money += 100;
        }

    }
}
