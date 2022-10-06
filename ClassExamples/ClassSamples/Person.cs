using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassSamples
{
    /// <summary>
    /// Класс, задающий общие свойства 
    /// и поведение личности
    /// </summary>
    public class Person
    {
       public enum Status
        {
            ребенок, школьник,
            студент, работник, пенсионер
        }
        //поля (все закрыты)
        string fam = "",  health = "";
        int age = 0, salary = 0;
        Status status = Status.работник;

        //Конструкторы класса
        public Person(){}
        public Person( string fam)
        {
            this.fam = fam;
        }
        public Person(string fam, int age)
        {
            this.fam = fam; this.age = age;
        }
        public Person(string fam, int age,
            string health, int zarplata, Status s)
        {
            this.fam = fam; this.age = age; status = s;
            this.health = health; salary = zarplata;
        }

        //методы - свойства
        /// <summary>
        ///стратегия: Read,Write-once (Чтение, запись при первом обращении)
        /// </summary>
        public string Fam
        {
            set { if (fam == "") fam = value; }
            get { return (fam); }
        }
        /// <summary>
        ///стратегия: Read-only(Только чтение)
        /// </summary>
        public Status GetStatus
        {
            get { return (status); }
        }
        /// <summary>
        ///стратегия: Read,Write (Чтение, запись)
        /// </summary>
        public int Age
        {
            set
            {
                age = value;
                //Изменение статуса
                if (age < 7) status = Status.ребенок;
                else if (age < 17) status = Status.школьник;
                else if (age < 22) status = Status.студент;
                else if (age < 65) status = Status.работник;
                else status = Status.пенсионер;
            }
            get { return (age); }
        }
        /// <summary>
        ///стратегия: Write-only (Только запись)
        /// </summary>
        public int Salary
        {
            set { salary = value; }
        }

        const int Child_Max = 20; //максимальное число детей
        Person[] children = new Person[Child_Max];
        int count_children = 0; //число детей
        /// <summary>
        /// Метод-свойство
        /// </summary>
        public int Count_children 
        { get { return count_children; } }
        /// <summary>
        /// Индексатор по массиву children
        /// </summary>
        /// <param name="i">индекс элемента в массиве</param>
        /// <returns>элемент с заданным индексом</returns>
        public Person this[int i] //индексатор
        {
            get
            {
                if (i >= 0 && i < count_children) return (children[i]);
                else return (children[0]);
            }
            set
            {
                if (i == count_children && i < Child_Max)
                { children[i] = value; count_children++; }
            }
        }


    }
}
