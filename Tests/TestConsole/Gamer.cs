using System;

namespace TestConsole
{
    class Gamer
    {
        private string _Name;
        private DateTime _DayOfBirth;

        public string Name
        {
            get
            {
                return _Name ?? string.Empty;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException(nameof(value));
                _Name = value;
            }
        }
        
        public Gamer(string Name, DateTime DayOfBirth)
        {
            _Name = Name;
            _DayOfBirth = DayOfBirth;
        }

        //public void SetName(string value)
        //{
        //    _Name = value;
        //}

        //public string GetName()
        //{
        //    return _Name;
        //}


        protected int GetNameLenght()
        {
            return Name.Length;
        }

        public void SayYouName() => Console.WriteLine("My name is {0} - {1:dd:MM:yyyy HH:mm:ss}", _Name, _DayOfBirth);
        
    }
}
