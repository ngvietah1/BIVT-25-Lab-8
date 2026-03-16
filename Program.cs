using System;
using System.Runtime.CompilerServices;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human man = new Man("Vu", "Anh", 37, Jobs.sportsman);
            Human woman = new Woman("Le", "Anh", 34, Jobs.CEO);
            man.Work();
            woman.Work();
            man.Work();
            woman.Work();
            man.Print();
            woman.Print();
            
        }
    }
    public enum Jobs
    {
        sportsman=5000,
        CEO=20000,
        guard=3000,
        IT=6000,
        doctor=10000,
        worker=3500
    }
    public abstract class Human
    {
        private string _name;
        private string _surname;
        private int _age;
        private Jobs _job;
        protected int _salary;
        private int _id;
        private static int _ID;
        protected int _monthworking;
        public string Name => _name;
        public string Surname => _surname;
        public int Age => _age;
        public Jobs Job => _job;
        public int Salary => _salary;
        public int ID => _id;
        public int MonthWorking => _monthworking;
        static Human()
        {
            _ID = 1;
        }
        public Human(string name, string surname, int age, Jobs job)
        {
            _name = name;
            _surname = surname;
            _age = age;
            _job = job;
            _salary = 0;
            _id = _ID;
            _monthworking = 0;
            _ID++;
        }
        public abstract void Work();
        public virtual int Bonus
        {
            get
            {
                return _salary / 10;
            }
        }
        public void Print()
        {
            Console.WriteLine($"Name: {_name},\nSurname: {_surname},\nAge: {_age},\nSalary: {_salary},\nID: {_id},\nJob: {_job},\nMonthWorking: {_monthworking}");
        }
    }
    public class Man : Human
    {
        public Man(string name, string surname, int age, Jobs job) : base(name, surname, age, job) { }
        public override void Work()
        {
            _monthworking++;
            _salary += (int)Job + base.Bonus + Bonus;
        }
        public override int Bonus
        {
            get
            {
                return base.Bonus + 5;
            }
        }
    }
    public class Woman : Human
    {
        public Woman(string name, string surname, int age, Jobs job) : base(name, surname, age, job) { }
        public override void Work()
        {
            _monthworking++;
            _salary += (int)Job + Bonus + base.Bonus;
        }
        public override int Bonus
        {
            get
            {
                return base.Bonus + 10;
            }
        }
    }
}