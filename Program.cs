using System.ComponentModel.Design;
using System.Threading.Channels;

namespace PhoneBookCrud;

internal class Program
{
    
    static void Main()
    {
        Menu();
    }
    static void Menu()
    {
        SystemService service = new SystemService();
        System system = new System();

        Menu2();
         void Menu2()
         {
            Console.WriteLine(@"1.Registratsiya
2.Id orqali ko'rish
3.Hammasini ko'rish
4.Id orqali o'chirish
5.Hammasini o'chirish");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Ism kiriting - ");
                    system.Name = Console.ReadLine();

                    Console.Write("PhoneNumber - ");
                    system.PhoneNumber = Console.ReadLine();

                    service.Registr(system);

                    Menu2();

                    break;

                case 2:
                    Console.Write("Id kiriting - ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    service.ViewById(id);
                    Menu2();
                    break;

                case 3:
                    service.ViewAll();
                    Menu2();
                    break;

                case 4:
                    Console.Write("Id kiriting - ");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    service.DeleteById(id2, system);
                    Menu2();
                    break;

                case 5:
                    service.DeleteAll();
                    Menu2();
                    break;

            }
         }
















    }
    


    
}




internal  class System
{

    public int Id =0;

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    

    

    
    
    
   

  
}


    




    internal class SystemService
    {
        System[] systems;

         int arrayCount=10;
        public SystemService()
        {
            systems = new System[arrayCount];
        }

        public void Registr(System system)
        {
            
            for(int i = 0; i < systems.Length; i++)
            {
                if (systems[i] is null)
                {

                    systems[i] = system;

                    system.Id = system.Id+1;

                    break;
                }
            }

        }
        public void View(int id,System system)
        {

            if (id == system.Id)
            {
                for(int i = 0;i < systems.Length;i++)
                {
                    Console.WriteLine($" Id - {system.Id} \n Name - {system.Name} \n Number - {system.PhoneNumber} ");
                    break;
                }
            }
        }

        public void ViewAll()
        {
            for (int i = 0; i < systems.Length; i++)
            {
                if (systems[i] is not null)
                {
                    Console.WriteLine($"{systems[i].Name} {systems[i].Id} {systems[i].PhoneNumber}");
                }
                break;
            }
        }
        public void ViewById(int id)
        {
            for (int i = 0; i < systems.Length; i++)
            {
                if (systems[i] is not null)
                {
                    if (systems[i].Id == id)
                    {
                        Console.WriteLine($"{systems[i].Name} {systems[i].PhoneNumber}");
                    }
                }
            }
        }
        public void DeleteById(int id,System system)
        {
            if (id == system.Id)
            {
                for(int i = 0; i<systems.Length ; i++)
                {
                    if (systems[i] is not null)
                    {
                        systems[i] = null;
                    }
                }
            }
            
        }
        public void DeleteAll()
        {
            for (int i = 0; i < systems.Length; i++)
            {
                systems[i] = null;
            }
        }
        

    }


   
   


    





