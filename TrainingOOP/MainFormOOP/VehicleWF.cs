using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingOOP;

namespace MainFormOOP
{
    public partial class VehicleWF : Form
    {
        public VehicleWF()
        {
            InitializeComponent();
        }
        private Vehicle GetObject()
        {
            Vehicle vehicle1 = new Vehicle();
            vehicle1.Setcolor = Color.Black;
            vehicle1.VIN = "WAUYP64B01N141245";
            vehicle1.GosID = "х677кн";
            vehicle1.Brand = "BMW";
            vehicle1.Model = "X6 40d III(GO6)";
            vehicle1.ReleaseYear = 2022;
            vehicle1.SetBody = Vehicle.Body.внедорожник;
            vehicle1.NumberOfDoors = 5;
            vehicle1.NumberOfOwners = 1;
            vehicle1.SetCondition = Vehicle.Condition.Не_требует_ремонта;
            vehicle1.SetEngineType = Vehicle.EngineType.дизель;
            vehicle1.SetDriveType = Vehicle.DriveType.полный;
            vehicle1.SetTransmissionType = Vehicle.Transmission.автоматическая;
            vehicle1.SetSteeringWheelPosition = Vehicle.SteeringWheelPosition.левый;
            vehicle1.Mileage = 9620;
            return vehicle1;
        }

        private void ShowInfo_Click(object sender, EventArgs e)
        {
            PrintVehicleInfo(GetObject());
        }
        private void PrintVehicleInfo(Vehicle vehicle1)
        {
            VehicleInfo.Text = "КАРТОЧКА АВТОМОБИЛЯ:"+ Environment.NewLine + vehicle1.Brand + vehicle1.Model + vehicle1.GetUsed + Environment.NewLine +
                              "Год выпуска:" + vehicle1.ReleaseYear + Environment.NewLine +
                              "Пробег:" + vehicle1.Mileage + Environment.NewLine +
                              "Кузов:" + vehicle1.GetBody + vehicle1.NumberOfDoors + Environment.NewLine +
                              "Цвет:" + vehicle1.Getcolor + Environment.NewLine +
                              "Двигатель:" + vehicle1.GetEngineType + Environment.NewLine +
                              "КПП:" + vehicle1.GetTransmissionType + Environment.NewLine +
                              "Привод:" + vehicle1.GetDriveType + Environment.NewLine +
                              "Руль:" + vehicle1.GetSteeringWheelPosition + Environment.NewLine +
                              "Состояние:" + vehicle1.GetCondition + Environment.NewLine +
                              "Владельцы:" + vehicle1.NumberOfOwners + " владелец"+ Environment.NewLine +
                              "ПТС:" + vehicle1.GetPTS + Environment.NewLine +
                              "VIN:"+ vehicle1.VIN + Environment.NewLine +
                              "Гос.номер:"+ vehicle1.GosID;
        }
    }
}
