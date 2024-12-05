using System.ComponentModel.DataAnnotations;

namespace Tumakov
{
    class Building
    {
        #region Fields
        static int instance = 0;
        private int buildingIdentificator;
        private double heightInMeters;
        private int floorsAmount;
        private int apartmentsAmount;
        private int sectionsAmount;
        #endregion
        #region Properties
        public int BuildingIdentificator
        {
            get
            {
                return buildingIdentificator;
            }
            set
            {
                buildingIdentificator = value;
            }
        }
        public double HeightInMeters
        {
            get
            {
                return heightInMeters;
            }
            set 
            {
                heightInMeters = value;
            }
        }
        public int FloorsAmount
        {
            get
            {
                return floorsAmount;
            }
            set
            {
                floorsAmount = value;
            }
        }
        public int ApartmentsAmount
        {
            get
            {
                return apartmentsAmount;
            }
            set
            {
                apartmentsAmount = value;
            }
        }
        public int SectionsAmount
        {
            get
            {
                return sectionsAmount;
            }
            set
            {
                sectionsAmount = value;
            }
        }
        #endregion
        #region Constructor Methods
        private void CountInstance()
        {
            instance++;
        }
        public Building()
        {
            CountInstance();
            buildingIdentificator = instance;
            heightInMeters = -1;
            floorsAmount = -1;
            apartmentsAmount = -1;
            sectionsAmount = -1;
        }
        public Building(double heightInMeters, int floorsAmount, int apartmentsAmount, int sectionsAmount)
        {
            CountInstance();
            BuildingIdentificator = instance;
            this.heightInMeters = heightInMeters;
            this.floorsAmount = floorsAmount;
            this.apartmentsAmount = apartmentsAmount;
            this.sectionsAmount = sectionsAmount;    
        }
        #endregion
        #region Call Methods
        static public void StartTask()
        {
            Building buildingKazanMall = new Building();
            Console.WriteLine("Для торгового центра Казан Молл:");
            buildingKazanMall.HeightInMeters = 3*4;
            Console.WriteLine($"Высота - {buildingKazanMall.HeightInMeters} метров");
            buildingKazanMall.FloorsAmount = 4;
            Console.WriteLine($"Количество этажей - {buildingKazanMall.FloorsAmount}");
            buildingKazanMall.ApartmentsAmount = 250;
            Console.WriteLine($"Количество квартир - {buildingKazanMall.ApartmentsAmount}");
            buildingKazanMall.SectionsAmount = 4;
            Console.WriteLine($"Количество подъездов - {buildingKazanMall.SectionsAmount}");
            buildingKazanMall.CalculateFloorHeight(2);
            buildingKazanMall.CalculateFloorHeight(222);
            Building buildingMegaMall = new Building(3*4+2,3,200,3);
            Console.WriteLine("Для торгового центра Меги:");
            Console.WriteLine($"Высота - {buildingMegaMall.HeightInMeters} метров");
            Console.WriteLine($"Количество этажей - {buildingMegaMall.FloorsAmount}");
            Console.WriteLine($"Количество квартир - {buildingMegaMall.ApartmentsAmount}");
            Console.WriteLine($"Количество подъездов - {buildingMegaMall.SectionsAmount}");
            buildingMegaMall.CalculateAparmentsAmountInSection();
            buildingMegaMall.CalculateApartmentsAmountForOneFloor();
        }
        #endregion
        #region Math Methods
        public void CalculateFloorHeight(int floor)
        {
            if (floor < floorsAmount && floor > 0)
            {
                Console.WriteLine($"Высота {floor} этажа {heightInMeters / (double)floorsAmount * (double)floor} метров");
            }
            else
            {
                Console.WriteLine($"Этаж должен быть он 1 до {floorsAmount}");
            }
        }
        public void CalculateAparmentsAmountInSection()
        {
            Console.WriteLine($"В одном подъезде - {ApartmentsAmount / SectionsAmount}");
        }
        public void CalculateApartmentsAmountForOneFloor()
        {
            Console.WriteLine($"На одном этаже - {ApartmentsAmount/floorsAmount}");
        }
        #endregion
    }
}
