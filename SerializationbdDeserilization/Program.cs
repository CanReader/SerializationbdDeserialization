using System;
using Universe;

namespace Main
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////    Author: Canberk Pitirli
    ///////////    Version: 1.0v
    ///////////    Released date: 20//08/2020
    ///////////    
    ///////////    Application Name: Serialization/Deserialization
    ///////////    Purpose: Learning
    ///////////    Description: This application demonstrate that how to use Serialization and Deserialization in json and binary(dat) files. Firstly I created a Person named class and added some 
    ///////////    properties like Name, Surname, Age etc... Afterwards, I added serialize and Deserialize for hiding datas in folders so that application creates a folder named "People" and adds
    ///////////    people which you utialized Serialize method on them. I'll code my own serializor more different than other serializor in the future...
    //////////
    //////////     For more information: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    


    class Program
    {
        static void Main(string[] args)
        {
            Person Canberk = new Person("Canberk","Pitirli",19,89.0,1.86,"Scientist");
            Person Marcus = new Person
            {
                Name = "Marcus",
                Surname = "Person",
                Age = 38,
                Weight = 117.41,
                Height = 1.79,
                Job = "Game Programmer"
            };


            Marcus.Serialize();
            Marcus.Deserilaze();
            Canberk.Serialize();
            Canberk.Deserilaze();

            Console.ReadLine();
        }
    }
}
