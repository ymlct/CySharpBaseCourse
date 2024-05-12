namespace L15Task1
{
    internal struct Worker
    {
        public string Name { get; private set; }
        
        public string Position { get; private set; }
        
        public int YearOfHiring { get; private set; }

        public Worker(string name, string position, int yearOfHiring)
        {
            Name = name;
            Position = position;
            YearOfHiring = yearOfHiring;
        }
    }
}