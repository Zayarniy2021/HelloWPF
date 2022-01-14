using System;

namespace WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public string Advise(string query)
        {
            Random rand = new Random();
            int N = rand.Next(1, 5);
            if (query == null || query == "" || !query.Contains("?"))
                return "Задайте вопрос";
            else
            {
                switch (N)
                {
                    case 1:
                        return "Скорее всего, да";
                    case 2:
                        return "Нужно подумать";
                    case 3:
                        return "Решай сам";
                    case 4:
                        return "Скорее, нет";
                    default:
                        return "Точно нет";
                }
            }
        }
    }
}
