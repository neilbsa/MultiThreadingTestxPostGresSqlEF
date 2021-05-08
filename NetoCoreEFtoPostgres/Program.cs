using NetoCoreEFtoPostgres.context;
using NetoCoreEFtoPostgres.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetoCoreEFtoPostgres
{
    class Program
    {

        private static readonly int SomethingCount = 1000;
        private static readonly int SomethingChildCount = 1000;
        static void Main(string[] args)
        {
          


        List<Task> tasks = new List<Task>();

            var first= Task.Run( () => {

                string id = Task.CurrentId.ToString();
                using (SomethingContext cont = new SomethingContext())
                {

                    var randomNum = Guid.NewGuid().ToString();
                    Console.WriteLine("start: {0} id : {1}", DateTime.Now.ToString("hh:mm:ss"), id);
                    List<Task<SomethingModel>> tasksInner = new List<Task<SomethingModel>>();
                    for (int i = 0; i < SomethingCount; i++)
                    {
                    
                        tasksInner.Add(CreateModel(randomNum));
                    }

                    Task.WaitAll(tasksInner.ToArray());

                    foreach (var item in tasksInner)
                    {
                        cont.Somethings.Add(item.Result);
                    }
                    cont.SaveChanges();
                    Console.WriteLine("start: {0} id : {1}", DateTime.Now.ToString("hh:mm:ss"), id);

                }



            });


            tasks.Add(first);

            var second = Task.Run( () => {

                string id = Task.CurrentId.ToString();
                using (SomethingContext cont = new SomethingContext())
                {

                    var randomNum = Guid.NewGuid().ToString();
                    Console.WriteLine("start: {0} id : {1}", DateTime.Now.ToString("hh:mm:ss"), id);
                    List<Task<SomethingModel>> tasksInner = new List<Task<SomethingModel>>();
                    for (int i = 0; i < SomethingCount; i++)
                    {
                    
                        tasksInner.Add(CreateModel(randomNum));
                    }

                    Task.WaitAll(tasksInner.ToArray());

                    foreach (var item in tasksInner)
                    {
                        cont.Somethings.Add(item.Result);
                    }
                    cont.SaveChanges();
                    Console.WriteLine("start: {0} id : {1}", DateTime.Now.ToString("hh:mm:ss"), id);

                }



            });

            tasks.Add(second);
            var third = Task.Run( () => {

                string id = Task.CurrentId.ToString();
                using (SomethingContext cont = new SomethingContext())
                {

                    var randomNum = Guid.NewGuid().ToString();
                    Console.WriteLine("start: {0} id : {1}", DateTime.Now.ToString("hh:mm:ss"), id);
                    List<Task<SomethingModel>> tasksInner = new List<Task<SomethingModel>>();
                    for (int i = 0; i < SomethingCount; i++)
                    {
                      
                        tasksInner.Add(CreateModel(randomNum));
                    }

                    Task.WaitAll(tasksInner.ToArray());

                    foreach (var item in tasksInner)
                    {
                        cont.Somethings.Add(item.Result);
                    }
                    
                    cont.SaveChanges();
                    Console.WriteLine("start: {0} id : {1}", DateTime.Now.ToString("hh:mm:ss"), id);

                }



            });

            tasks.Add(third);

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("All is finish");
        }


        private static readonly SemaphoreSlim sem = new SemaphoreSlim(10);
        private async static Task<SomethingModel> CreateModel(string id)
        {


            await sem.WaitAsync();
            Console.WriteLine($"started : { id }");
            List<ChildSomethingModel> listModel = new List<ChildSomethingModel>();
            for (int i = 0; i < SomethingChildCount; i++)
            {
                listModel.Add(new ChildSomethingModel() {

                    Description = id,
                    name = id,
                    SampleDate = DateTime.Now,
                    Subsidiary = id
                } );
            }
         

            SomethingModel mod = new SomethingModel() {
                Description = id,
                name = id,
                SampleDate = DateTime.Now,
                Subsidiary = id

            };
            mod.childs = listModel;

          sem.Release();

           Console.WriteLine($"ended : { id }");
            return mod;

        }

      
    }
}
