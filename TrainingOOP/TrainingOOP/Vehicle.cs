using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TrainingOOP
{   //Тимофей

    /// <summary>
    /// Класс, задающий основные данные об автомобиле
    /// </summary>
    public class Vehicle
    {
        const string VIN_TOO_SHORT =
            "Введённый VIN слишком короткий. Необходимая длина - 17 символов";
        const string VIN_TOO_LONG =
            "Введённый VIN слишком длинный. Необходимая длина - 17 символов";
        const string GOSID_TOO_SHORT =
            "Введённый гос. ID слишком короткий. Необходимая длина - 6 символов";
        const string GOSID_TOO_LONG =
            "Введённый гос. ID слишком длинный. Необходимая длина - 6 символов";
        const string YEAR_INCORRECT =
            "Неверно введён год выпуска";
        const string DOOR_INCORRECT = 
            "Неверно введено количество дверей";
        const string MILEAGE_INCORRECT =
            "Неверно введён пробег";
        const string OWNERS_INCORRECT =
            "Неверно введено количество владельцев";
        const string BODY_INCORRECT =
            "Неверно введ`н тип кузова";
        const string ENGINETYPE_INCORRECT =
            "Неверно введён типа двигателя";
        const string USED_INCORRECT =
            "Неверно введена новизна автомобиля";
        const string CONDITION_INCORRECT =
            "Неверно введено состояние автомобиля";
        const string PTSTYPE_INCORRECT =
            "Неверно введён тип ПТС";

        public enum Used
        {
            новый,
            с_пробегом
        }
        public enum PTS
        {
            оригинал,
            дубликат
        }

        public enum SteeringWheelPosition
        {
            левый,
            правый
        }

        public enum Condition
        {
            Не_требует_ремонта,
            Битый_или_не_на_ходу,
        }

        public enum Transmission
        {
            механическая,
            автоматическая,
            роботизированная,
            вариативная
        }

        public enum DriveType
        {
            полный,
            передний,
            задний
        }

        public enum EngineType
        {
            бензин,
            дизель,
            электро,
            гибрид
        }

        public enum Body
        {
            седан,
            универсал,
            хэтчбэк,
            купе,
            лимузин,
            микроавтобус,
            минивэн,
            лифтбэк,
            кабриолет,
            пикап,
            фургон,
            внедорожник
        }
        Color color;
        string vin;
        string gosID;
        string brand;
        string model;
        int releaseYear;
        Body body;
        Type bodys = typeof(Body);
        int numberOfDoors;
        EngineType engineType;
        Type engines = typeof(EngineType);
        DriveType driveType;
        Type drives = typeof(DriveType);
        Transmission transmissionType;
        Type transmissions = typeof(Transmission);
        SteeringWheelPosition steeringWheel;
        Type steering = typeof(SteeringWheelPosition);
        int mileage;

        Used used;

        Condition condition;
        Type conditions = typeof(Condition);
        PTS pts;
        Type ptstypes = typeof(PTS);
        int numberOfOwners;


        public Color Getcolor 
        {
            get { return color; }
        }
        public Color Setcolor
        {
            set { color = Color.FromName(value.ToString());}
        }
        public string VIN 
        {
            get { return vin; }
            set { if (vin == null) vin = value; } 
        }
        public string GosID 
        {
            get { return gosID; }
            set { if (gosID == null) gosID = value; }
        }

        public string Brand 
        {
            get { return brand; }
            set { if (brand == null) brand = value; } 
        }
        public string Model
        {
            get { return model; }
            set { if (model == null) model = value; }
        }

        public int ReleaseYear
        {
            get { return releaseYear; }
            set 
            { if (value > 1890 || value < 2022) releaseYear = value;
                else throw new YearException(YEAR_INCORRECT);
            }
        }
        public Body GetBody 
        {
            get { return body; }
        }
        public Body SetBody
        {
            set { if (Enum.GetNames(bodys).Contains(value.ToString())) body = value;
                else throw new BodyException(BODY_INCORRECT);
            }
        }

        public int NumberOfDoors 
        {
            get {return numberOfDoors; }
            set {
                
                if (value > 1) numberOfDoors = value;
                else throw new DoorsException(DOOR_INCORRECT);
            } 
        }

        public EngineType GetEngineType 
        { 
            get { return engineType; }
        }
        public EngineType SetEngineType
        {
            set{ if (Enum.GetNames(engines).Contains(value.ToString())) engineType = value;
                else throw new EngineTypeException(ENGINETYPE_INCORRECT);
            }
        }

        public DriveType GetDriveType
        { 
            get { return driveType; }
        }
        public DriveType SetDriveType
        {
            set { if (Enum.GetNames(drives).Contains(value.ToString())) driveType = value; }
        }

        public Transmission GetTransmissionType
        {
            get { return transmissionType; }
        }
        public Transmission SetTransmissionType
        {
            set { if (Enum.GetNames(transmissions).Contains(value.ToString())) transmissionType = value; }
        }
        public SteeringWheelPosition GetSteeringWheelPosition
        {
            get { return steeringWheel; }
        }
        public SteeringWheelPosition SetSteeringWheelPosition
        {
            set { if (Enum.GetNames(steering).Contains(value.ToString())) steeringWheel = value; }
        }
        public int Mileage 
        {
            get {return mileage; }
            set {if (value > 0)
                {
                    mileage = value;
                    used = Used.с_пробегом;
                }
                else if (value == 0)
                {
                    mileage = value;
                    used = Used.новый;
                }
                else throw new MileageException(MILEAGE_INCORRECT);
            } 
        }
        public Used GetUsed
        { 
            get { return used; } 
        }

        public Condition GetCondition
        {
            get { return condition; }
        }
        public Condition SetCondition
        {
            set { if (Enum.GetNames(conditions).Contains(value.ToString()))
                {
                    condition = value;
                    if (condition == Condition.Не_требует_ремонта) used = Used.новый;
                    else used = Used.с_пробегом;
                }
                else throw new ConditionException(CONDITION_INCORRECT);
            }
        }
        public PTS GetPTS
        {
            get { return pts; }
        }
        public PTS SetPTS
        {
            set { if (Enum.GetNames(ptstypes).Contains(value.ToString())) pts = value;
                else throw new PTSException(PTSTYPE_INCORRECT);
            }
        }
        public int NumberOfOwners
        {
            get { return numberOfOwners; }
            set { if (value >= 0)
                {
                    numberOfOwners = value;
                    if (numberOfOwners == 0) used = Used.новый;
                    else used = Used.с_пробегом;
                }
                else throw new OwnersException(OWNERS_INCORRECT);
            } 
        }

    }

    [Serializable]
    internal class ConditionException : Exception
    {
        public ConditionException()
        {
        }

        public ConditionException(string message) : base(message)
        {
        }

        public ConditionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConditionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class PTSException : Exception
    {
        public PTSException()
        {
        }

        public PTSException(string message) : base(message)
        {
        }

        public PTSException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PTSException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class EngineTypeException : Exception
    {
        public EngineTypeException()
        {
        }

        public EngineTypeException(string message) : base(message)
        {
        }

        public EngineTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EngineTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class BodyException : Exception
    {
        public BodyException()
        {
        }

        public BodyException(string message) : base(message)
        {
        }

        public BodyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BodyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class OwnersException : Exception
    {
        public OwnersException()
        {
        }

        public OwnersException(string message) : base(message)
        {
        }

        public OwnersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OwnersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class MileageException : Exception
    {
        public MileageException()
        {
        }

        public MileageException(string message) : base(message)
        {
        }

        public MileageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MileageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class DoorsException : Exception
    {
        public DoorsException()
        {
        }

        public DoorsException(string message) : base(message)
        {
        }

        public DoorsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DoorsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class YearException : Exception
    {
        public YearException()
        {
        }

        public YearException(string message) : base(message)
        {
        }

        public YearException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected YearException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
