using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Universe
{
    [Serializable]
    class Person : ISerializable
    {
        public string  Name{ get; set; }
        public string  Surname{ get; set; }
        public int     Age{ get; set; }
        public double  Weight{ get; set; }
        public double  Height{ get; set; }
        public string  Job { get; set; }

        IFormatter bf;

        public Person()
        {

        }
        public Person(string Name, string Surname, int Age,double Weight,double Height,string Job)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Weight = Weight;
            this.Height = Height;
            this.Job = Job;

        }

        public string[] Tostring()
        {
            Console.WriteLine("Name    = " + Name);
            Console.WriteLine("Surname = " + Surname);
            Console.WriteLine("Age     = " + Age.ToString());
            Console.WriteLine("Weight  = " + Weight.ToString());
            Console.WriteLine("Height  = " + Height.ToString());
            Console.WriteLine("Job     = " + Job);

            return new string[] {Name,Surname,Age.ToString(),Weight.ToString(),Height.ToString(),Job.ToString() };
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(Name, "Name");
            info.AddValue(Surname, "Surname");
            info.AddValue(Convert.ToString(Age), "Age");
            info.AddValue(Convert.ToString(Weight), "Weight");
            info.AddValue(Convert.ToString(Height), "Height");
            info.AddValue(Job, "Job");

            Console.WriteLine(info.FullTypeName);

        }

        public void Serialize()
        {

            Person Temporary;

            string JsonString;
             bf = new BinaryFormatter();

            //Json Serialize
            Stream JsonStream = File.Open(@"People\" + Name + " " + Surname + ".Json", FileMode.OpenOrCreate);
            var JsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            JsonString = JsonSerializer.Serialize(this,JsonOptions);
            StreamWriter sw = new StreamWriter(JsonStream);
            sw.WriteLine(JsonString);
            sw.Close();
            

            JsonStream.Close();

            //Binary Serialize
            Stream BinaryStream = File.Open(@"People\" + Name + " " + Surname + ".dat", FileMode.OpenOrCreate);
            bf.Serialize(BinaryStream,this);


            BinaryStream.Close();
            //Temporary.ToString();

            Console.WriteLine();
        }

        public void Deserilaze()
        {
            Console.WriteLine("          Beginning of the " + Name);

            Person Temporary = null;
            string TemporaryString = string.Empty;

            //Json deserialize
            Console.WriteLine();
            Console.WriteLine("  According to json file: \n");
            string Jsonpath = @"People\" + Name + " " + Surname + ".Json";
            if (File.Exists(Jsonpath))
            {
                try
                {

                TemporaryString = File.ReadAllText(Jsonpath);
                Temporary = JsonSerializer.Deserialize<Person>(TemporaryString);
            Temporary.Tostring(); // If you delete this line, Console doesn't write properties. I do not know why?
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occured while deserializing {0}  {1}.Json file, Error message is here \n {2}",Name,Surname,e.Message);
                }
            }
            else
            {
                Console.WriteLine("Failed to find " + Name + " " + Surname + ".Json");
            }

            //Binary Deserilization
            Console.WriteLine();
            Console.WriteLine("  According to the dat file: \n");
            string DatPath = @"People\" + Name + " " + Surname + ".Json";
            if (File.Exists(DatPath))
            {
                try
                {
                    using (FileStream BinaryStream = new FileStream(DatPath, FileMode.Open)) {
                        bf = new BinaryFormatter();
                    Temporary = (Person)bf.Deserialize(BinaryStream);
                        Temporary.Tostring();
                    }
                }
                catch (Exception k)
                {
                    Console.WriteLine("Oops looks like a error is occured because of unknown fucking error1!!!!! Anyways error message:\n {0}", k.Message);
                }
            }
            else
            {
                Console.WriteLine("Failed to find " + Name + " " + Surname + ".dat");
            }

            Console.WriteLine();
            Console.WriteLine("          End of the " + Name);
            Console.WriteLine();
        }


        }
    }


