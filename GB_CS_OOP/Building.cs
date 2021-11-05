using System;
using System.Collections.Generic;
using System.Text;

namespace GB_CS_OOP
{
    /*
     * Реализовать класс для описания здания (уникальный номер здания, 
        высота, этажность, количество квартир, подъездов). 
        Поля сделать закрытыми, предусмотреть методы для заполнения 
        полей и получения значений полей для печати. 
        Добавить методы вычисления высоты этажа, количества квартир в подъезде, 
        количества квартир на этаже и т.д. 
        Предусмотреть возможность, чтобы уникальный номер здания генерировался программно. 
        Для этого в классе предусмотреть статическое поле, 
        которое бы хранило последний использованный номер здания, 
        и предусмотреть метод, который увеличивал бы значение этого поля.
    */

    public class Building
    {
        private static int lastBuildingNumber = 0;
        private int buildingNumber;
        private int height;
        private int floorCount;
        private int apartmentCount;
        private int entranceCount;

        public Building()
        {
            this.buildingNumber = GenerateNewBuildingNumber();
        }

        public Building(int height, int floorCount,
            int apartmentCount, int entranceCount)
        {
            this.buildingNumber = GenerateNewBuildingNumber();
            this.height = height;
            this.floorCount = floorCount;
            this.apartmentCount = apartmentCount;
            this.entranceCount = entranceCount;
        }

        private int GenerateNewBuildingNumber()
        {
            lastBuildingNumber = lastBuildingNumber + 1;
            return lastBuildingNumber;
        }

        public int GetBuildingNumber() => this.buildingNumber;
        public void SetBuildingNumber(int buildingNumber) =>
            this.buildingNumber = buildingNumber;

        public int GetHeight() => this.height;
        public void SetHeight(int height) =>
            this.height = height;

        public int GetFloorCount() => this.floorCount;
        public void SetFloorCount(int floorCount) =>
            this.floorCount = floorCount;

        public int GetApartmentCount() => this.apartmentCount;
        public void SetApartmentCount(int apartmentCount) =>
            this.apartmentCount = apartmentCount;

        public int GetEntranceCount() => this.entranceCount;
        public void SetEntranceCount(int entranceCount) =>
            this.entranceCount = entranceCount;


        public int GetFloorHeight() => this.height / this.floorCount;
        public int GetApartmentCountInEntrance() => this.apartmentCount / this.entranceCount;
        public int GetApartmentCountInFloor() => this.apartmentCount / this.floorCount;

        public override string ToString()
        {
            return $"Номенр дома: \t {buildingNumber} \nвысота: \t {height} \n" +
                $"количество этажей: \t {floorCount}\n" +
                $"количество квартир на этаже: \t {apartmentCount}\n" +
                $"количество подъездов: \t {entranceCount}";
        }
    }
}
