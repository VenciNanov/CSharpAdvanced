using System;

namespace _09.CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            AddCollection addcollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var element in input)
            {
                addcollection.Add(element);
                addRemoveCollection.Add(element);
                myList.Add(element);
            }

            Console.WriteLine(addcollection.AddIndexes);
            Console.WriteLine(addRemoveCollection.AddIndexes);
            Console.WriteLine(myList.AddIndexes);

            var elementToRemove = int.Parse(Console.ReadLine());
            for (int i = 0; i < elementToRemove; i++)
            {
                addRemoveCollection.Remove();
                myList.Remove();
            }

            Console.WriteLine(addRemoveCollection.RemovedElements);
            Console.WriteLine(myList.RemovedElements);
        }
    }
}
