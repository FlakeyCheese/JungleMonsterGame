using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleMonsterGame
{
    internal class Program
    {
        static Monster[] monsterArray = new Monster[20]; //initialise the monster array ***GLOBAL***MUST BE STATIC***
        static void Main(string[] args)
        {   string ln;
            
            StreamReader file = new StreamReader("../../resources/monsters.txt");//load from file
            {
                for (int i = 0; i < monsterArray.Length; i++)
                {                    
                        string tempName = file.ReadLine(); ;//add the attributes to the monster from the file
                        string tempdesc = file.ReadLine();
                        bool tempSafe = Convert.ToBoolean(file.ReadLine());
                        int tempSpeed = Convert.ToInt32((string)file.ReadLine());
                        int tempDamage = Convert.ToInt32((string)file.ReadLine());
                        monsterArray[i] = new Monster(tempName, tempdesc, tempSafe, tempSpeed, tempDamage);//create a new monster with basic attributes
                }
            }
            file.Close();//close the file streamReader
            
            //find dangerous monsters by searching the array//
            findMonster(5, 10, false);
            Console.ReadLine();
        }

        public static void findMonster(int maxSpeed, int maxDamage, bool isSafe)//FROM EXAM QUESTION
        {
            bool found = false;//have we found a monster that meets the criteria
            for (int i=0; i<monsterArray.Length;i++)
            {
                if (!monsterArray[i].GetIsSafe())//check the monster is not safe
                {
                    
                    if (monsterArray[i].GetMaxDamage() > maxDamage && monsterArray[i].GetMaxSpeed()>maxSpeed)//check matching criteria
                    {
                        found = true;//if the monster meets the 3 criteria then we set found to true
                        Console.WriteLine("Monster: " + monsterArray[i].GetItemName());
                        Console.WriteLine("Description: " + monsterArray[i].GetDescription());
                        Console.WriteLine("Is Safe = " + monsterArray[i].GetIsSafe());
                        Console.WriteLine("Damage = " + monsterArray[i].GetMaxDamage());
                        Console.WriteLine("Speed = " + monsterArray[i].GetMaxSpeed());
                        Console.WriteLine();
                    }
                }
            }
            if (found==false)
            { Console.WriteLine("No Dangerous Monsters found that meet the criteria"); }
        }
    }
    class GameItem
    {
        protected string itemName;
        protected string description;
        protected bool isSafe;

        public GameItem(string myitemName, string mydescription, bool myisSafe)
        {
            this.itemName = myitemName;
            this.description = mydescription;
            this.isSafe = myisSafe;
        }
        public string GetItemName()
        {
            return this.itemName;
        }
        public void SetItemName(string myitemName)
        { this.itemName = myitemName; }
        public string GetDescription()
            { return this.description; }
        public void SetDescription(string myDescription)
            { this.description = myDescription; }
        public bool GetIsSafe()
            { return this.isSafe; }
        public void SetIsSafe(bool myIsSafe)
        {
        this.isSafe = myIsSafe;
        }
       
    }
    class Monster : GameItem
    {
        private int speed;
        private int damage;
        public Monster(string myitemName, string mydescription, bool myisSafe, int myspeed, int mydamage) : base(myitemName, mydescription, myisSafe)
        {

            this.speed = myspeed;
            this.damage = mydamage;


        }
        
        public int GetMaxSpeed()
        {return this.speed;}
        public void SetMaxSpeed(int myspeed)
        { this.speed = myspeed; }
        public int GetMaxDamage()
            { return this.damage; }
        public void SetMaxDamage(int mydamage)
            { this.damage = mydamage; }
    }
}
