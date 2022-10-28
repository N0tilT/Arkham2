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
        #region exceptionconst 
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
        #endregion

        #region enum
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
        #endregion

        #region fields
        Color _color;
        string _vin;
        string _gosID;
        string _brand;
        string _model;
        int _releaseYear;
        Body _body;
        Type _bodys = typeof(Body);
        int _numberOfDoors;
        EngineType _engineType;
        Type _engines = typeof(EngineType);
        DriveType _driveType;
        Type _drives = typeof(DriveType);
        Transmission _transmissionType;
        Type _transmissions = typeof(Transmission);
        SteeringWheelPosition _steeringWheel;
        Type _steering = typeof(SteeringWheelPosition);
        int _mileage;

        Used _used;

        Condition _condition;
        Type _conditions = typeof(Condition);
        PTS _pts;
        Type _ptstypes = typeof(PTS);
        int _numberOfOwners;
        #endregion

        #region propirties
        public Color Getcolor 
        {
            get { return _color; }
        }
        public Color Setcolor
        {
            set { _color = Color.FromName(value.ToString());}
        }
        public string VIN 
        {
            get { return _vin; }
            set { if (_vin == null) _vin = value; } 
        }
        public string GosID 
        {
            get { return _gosID; }
            set { if (_gosID == null) _gosID = value; }
        }

        public string Brand 
        {
            get { return _brand; }
            set { if (_brand == null) _brand = value; } 
        }
        public string Model
        {
            get { return _model; }
            set { if (_model == null) _model = value; }
        }

        public int ReleaseYear
        {
            get { return _releaseYear; }
            set 
            { if (value > 1890 || value < 2022) _releaseYear = value;
                else throw new YearException(YEAR_INCORRECT);
            }
        }
        public Body GetBody 
        {
            get { return _body; }
        }
        public Body SetBody
        {
            set { if (Enum.GetNames(_bodys).Contains(value.ToString())) _body = value;
                else throw new BodyException(BODY_INCORRECT);
            }
        }

        public int NumberOfDoors 
        {
            get {return _numberOfDoors; }
            set {
                
                if (value > 1) _numberOfDoors = value;
                else throw new DoorsException(DOOR_INCORRECT);
            } 
        }

        public EngineType GetEngineType 
        { 
            get { return _engineType; }
        }
        public EngineType SetEngineType
        {
            set{ if (Enum.GetNames(_engines).Contains(value.ToString())) _engineType = value;
                else throw new EngineTypeException(ENGINETYPE_INCORRECT);
            }
        }

        public DriveType GetDriveType
        { 
            get { return _driveType; }
        }
        public DriveType SetDriveType
        {
            set { if (Enum.GetNames(_drives).Contains(value.ToString())) _driveType = value; }
        }

        public Transmission GetTransmissionType
        {
            get { return _transmissionType; }
        }
        public Transmission SetTransmissionType
        {
            set { if (Enum.GetNames(_transmissions).Contains(value.ToString())) _transmissionType = value; }
        }

        public SteeringWheelPosition GetSteeringWheelPosition
        {
            get { return _steeringWheel; }
        }
        public SteeringWheelPosition SetSteeringWheelPosition
        {
            set { if (Enum.GetNames(_steering).Contains(value.ToString())) _steeringWheel = value; }
        }
        public int Mileage 
        {
            get {return _mileage; }
            set {if (value > 0)
                {
                    _mileage = value;
                    _used = Used.с_пробегом;
                }
                else if (value == 0)
                {
                    _mileage = value;
                    _used = Used.новый;
                }
                else throw new MileageException(MILEAGE_INCORRECT);
            } 
        }
        public Used GetUsed
        { 
            get { return _used; } 
        }

        public Condition GetCondition
        {
            get { return _condition; }
        }
        public Condition SetCondition
        {
            set { if (Enum.GetNames(_conditions).Contains(value.ToString()))
                {
                    _condition = value;
                    if (_condition == Condition.Не_требует_ремонта) _used = Used.новый;
                    else _used = Used.с_пробегом;
                }
                else throw new ConditionException(CONDITION_INCORRECT);
            }
        }
        public PTS GetPTS
        {
            get { return _pts; }
        }
        public PTS SetPTS
        {
            set { if (Enum.GetNames(_ptstypes).Contains(value.ToString())) _pts = value;
                else throw new PTSException(PTSTYPE_INCORRECT);
            }
        }

        public int NumberOfOwners
        {
            get { return _numberOfOwners; }
            set { if (value >= 0)
                {
                    _numberOfOwners = value;
                    if (_numberOfOwners == 0) _used = Used.новый;
                    else _used = Used.с_пробегом;
                }
                else throw new OwnersException(OWNERS_INCORRECT);
            } 
        }
        #endregion
    }

#region exceptions
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
    #endregion

}
