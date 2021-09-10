using System;
using System.Text.Json;
using System.Collections.Generic;

namespace ArchiveTask
{
    class FormatOperations
    {
        public string OperationId { get; set; }
        public string Time { get; set; }
    }

    public class Archive
    {
        private bool permissionGetId = true;


        public Archive(string[] serializedOperations)
        {
            if (serializedOperations.Length == 0) { permissionGetId = false; return; }

            //Создать некий пустой словарь Dictinary куда впоследсвтии впишем пары ключ значения ID:TIME
            Dictionary<string, string> operationDictionary = new Dictionary<string, string>(serializedOperations.Length);



            foreach (string operation in serializedOperations)
            {

                FormatOperations restoredOperation = JsonSerializer.Deserialize<FormatOperations>(operation);
                operationDictionary.Add(restoredOperation.OperationId, restoredOperation.Time);
                Console.WriteLine(restoredOperation.Time);

            }

            foreach (KeyValuePair<string, string> keyValue in operationDictionary)
            {
                Console.WriteLine(keyValue.Key + " : " + keyValue.Value.Split('T')[1]);

                GetUtcTime(keyValue.Value.Split('T')[0], keyValue.Value.Split('T')[1]);
            }

        }

        private string GetUtcTime(string date, string time)
        {
            int[] arrayDate = new int[3];
            int[] arrayTime = new int[3];

            for (int i = 0; i <= arrayDate.Length - 1; i++)
            {
                arrayDate[i] = Convert.ToInt32(date.Split('-')[i]);

            }

            for (int i = 0; i <= arrayTime.Length - 1; i++)
            {
                if (time.Contains('+'))
                {
                    arrayTime[i] = Convert.ToInt32(time.Split('+')[0].Split(':')[i]);
                }
                else
                {
                    arrayTime[i] = Convert.ToInt32(time.Split('-')[0].Split(':')[i]);
                }
            }

           // Console.WriteLine(arrayDate[2]);


            DateTime date1 = new DateTime(arrayDate[0], arrayDate[1],arrayDate[2],arrayTime[0], arrayTime[1],arrayTime[2]  );
            Console.WriteLine(date1);

/*
            if (time.Contains('+'))
            {
                Console.WriteLine(time.Split('+')[1]);
            }
            else
            {
                Console.WriteLine(time.Split('-')[1]);
            }
*/
            return "";
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




        static void Main(string[] args)
        {

            FormatOperations id1 = new FormatOperations { OperationId = "ab933cd2-3b07-4671-98c2-4f5cafdccaf3", Time = "2021-10-15T10:10:10+00:00" };
            FormatOperations id2 = new FormatOperations { OperationId = "eedbd10a-7b5b-42ce-b2e8-973122eb939d", Time = "2020-01-23T17:25:33+05:00" };
            FormatOperations id3 = new FormatOperations { OperationId = "08e8fcbe-4e53-45eb-9136-05f8206e7fbf", Time = "2020-12-11T23:15:18-01:00" };
            FormatOperations id4 = new FormatOperations { OperationId = "a776a222-c3e0-426e-af24-022fd74b5446", Time = "2020-12-12T03:15:18+03:00" };

            string jsonId1 = JsonSerializer.Serialize<FormatOperations>(id1);
            string jsonId2 = JsonSerializer.Serialize<FormatOperations>(id2);
            string jsonId3 = JsonSerializer.Serialize<FormatOperations>(id3);
            string jsonId4 = JsonSerializer.Serialize<FormatOperations>(id4);

            string[] serializedOper = new string[] { jsonId1, jsonId2, jsonId3, jsonId4 };

            /*
                        foreach (string operation in serializedOper)
                        {
                            Console.WriteLine(operation);
                        }

                        Console.WriteLine(serializedOper);
                        FormatOperations restoredFormatOperations = JsonSerializer.Deserialize<FormatOperations>(jsonId3);
                        Console.WriteLine(restoredFormatOperations.Time);

            */



            Archive arch = new Archive(serializedOper);
            arch.GetOperationIds("2020-12-12T05:15:18+05:00");



        }

    }
}