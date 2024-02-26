using System;

namespace Inheritance
{
    //Base Class
    class Member
    {
        protected int _Id;
        protected string _FirstName;
        protected string _LastName;
        protected int _Age;

        // default constructor
        public Member()
        {
            _Id = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Age = 0;
        }
        //parameterized constructor
        public Member(int id, string firstName, string lastName, int age)
        {
            _Id = id;
            _FirstName = firstName;
            _LastName = lastName;
            _Age = age;
        }
        // Get and Set Methods
        public int getID() { return _Id; }
        public string getFirstName() { return _FirstName; }
        public string getLastName() { return _LastName; }
        public int getAge() { return _Age; }
        public void setID(int id) { _Id = id; }
        public void setFirstName(string firstName) { _FirstName = firstName; }
        public void setLastName(string lastName) { _LastName = lastName; }
        public void setAge(int age) { _Age = age; }

        public virtual void addChange()
        {
            Console.Write("ID=");
            setID(int.Parse(Console.ReadLine()));
            Console.Write("First Name=");
            setFirstName(Console.ReadLine());
            Console.Write("Last Name=");
            setLastName(Console.ReadLine());
            Console.Write("Age=");
            setAge(int.Parse(Console.ReadLine()));
        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"      ID: {getID()}");
            Console.WriteLine($"    Name: {getFirstName()} {getLastName()}");
            Console.WriteLine($"     Age: {getAge()}");
        }
    }
    class Club : Member
    {
        protected string _clubType;
        protected int _Pricepermonth;

        public Club()
            : base()
        {
            _clubType = string.Empty;
            _Pricepermonth = 20;
        }
        public Club(int id, string firstname, string lastname, int age, string club, int price)
            : base(id, firstname, lastname, age)
        {
            _clubType = club;
            _Pricepermonth = price;
        }
        public void setClub(string club) { _clubType = club; }
        public void setPrice(int price) { _Pricepermonth = price; }
        public string getClub() { return _clubType; }
        public int getPrice() { return _Pricepermonth; }
        public override void addChange()
        {
            base.addChange();
            Console.Write("Club=");
            setClub(Console.ReadLine());
            Console.Write("Price=");
            setPrice(int.Parse(Console.ReadLine()));
        }
        public override void print()
        {
            base.print();
            Console.WriteLine($"  Club: {getClub()}");
            Console.WriteLine($"Price: {getPrice()}");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many members do you want to enter?");
            int maxMember;
            while (!int.TryParse(Console.ReadLine(), out maxMember))
                Console.WriteLine("Please enter a whole number");
            // array of mem objects
            Member[] mem = new Member[maxMember];
            Console.WriteLine("How many Clubs do you want to enter?");
            int maxClubs;
            while (!int.TryParse(Console.ReadLine(), out maxClubs))
                Console.WriteLine("Please enter a whole number");
            // array of Manager objects
            Club[] club = new Club[maxClubs];

            int choice, rec, type;
            int memCounter = 0, clubCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Club or 2 for Member");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Club or 2 for Member");
                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (type == 1) //club
                            {
                                if (clubCounter <= maxClubs)
                                {
                                    club[clubCounter] = new Club(); // places an object in the array instead of null
                                    club[clubCounter].addChange();
                                    clubCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of CLubs have been added");

                            }
                            else //mem
                            {
                                if (memCounter <= maxMember)
                                {
                                    mem[memCounter] = new Member(); // places an object in the array instead of null
                                    mem[memCounter].addChange();
                                    memCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of members have been added");
                            }

                            break;
                        case 2: //Change
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;  // subtract 1 because array index begins at 0
                            if (type == 1) //club
                            {
                                while (rec > clubCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                club[rec].addChange();
                            }
                            else // mem
                            {
                                while (rec > memCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                mem[rec].addChange();
                            }
                            break;
                        case 3: // Print All
                            if (type == 1) //club
                            {
                                for (int i = 0; i < clubCounter; i++)
                                    club[i].print();
                            }
                            else // mem
                            {
                                for (int i = 0; i < memCounter; i++)
                                    mem[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }


        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}