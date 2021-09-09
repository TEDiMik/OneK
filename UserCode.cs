using System;
using System.Text.Json;

namespace ArchiveTask
{
    public class Archive
    {
        private bool permissionGetId = true;


        public Archive(string[] serializedOperations)
        {
            if (serializedOperations.Length == 0) { permissionGetId = false; return; }

            //Создать некий пустой словарь Dictinary куда впоследсвтии впишем пары ключ значения ID:TIME


            foreach (string operation in serializedOperations)
            {
                Console.WriteLine(operation);
            }

        }

        public Guid[] GetOperationIds(string time)
        {
            if (permissionGetId)
            {







                //Если небыло найдено для этого времени ни одной операции
                return new Guid[0];






            }
            else
            {

                return new Guid[0];
            }

        }
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {

            Person tom = new Person { Name = "Tom", Age = 35 };
            string json = JsonSerializer.Serialize<Person>(tom);
            Console.WriteLine(json);
            Person restoredPerson = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(restoredPerson.Age);





            /*
            string[] operation = new string[] {
                @"{'OperationId':'ab933cd2-3b07-4671-98c2-4f5cafdccaf3','Time':'2021-10-15T10:10:10+00:00'}" ,
                @"{'OperationId':'eedbd10a-7b5b-42ce-b2e8-973122eb939d','Time':'2020-01-23T17:25:33+05:00'}" ,
                @"{'OperationId':'08e8fcbe-4e53-45eb-9136-05f8206e7fbf','Time':'2020-12-11T23:15:18-01:00'}" ,
                @"{'OperationId':'a776a222-c3e0-426e-af24-022fd74b5446','Time':'2020-12-12T03:15:18+03:00'}" ,

            };


            Archive arch = new Archive(operation);
            arch.GetOperationIds("2020-12-12T05:15:18+05:00");
*/







        }

    }
}