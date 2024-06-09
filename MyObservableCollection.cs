using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary10;
using ClassLibraryForHashTable;

namespace lab13
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

    public class MyObservableCollection<T> : MyCollection<T> where T : IInit, ICloneable, new()
    {
        public string CollectionName { get; set; }

        public int Count => base.Count;

        //public MyObservableCollection() : base() { }
        //public MyObservableCollection(params T[] coll) : base(coll) { }

        public MyObservableCollection(int length)
        {
            table = new Point<T>[length];
            for (int i = 0; i < length; i++)
            {
                T elem = new T();
                elem.RandomInit();
                var milliseconds = 300;
                Thread.Sleep(milliseconds);
                AddItem(elem);
            }
        }

        public T this[string name]  //Определяется индексатор, который позволяет получать и устанавливать элемент коллекции по указанному имени.
        {
            get
            {
                T searchName = default;
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i] != null)
                    {
                        if (table[i].Data is BankCard m && m.Name.Equals(name))
                            searchName = table[i].Data;
                        else if (table[i].Next != null)
                        {
                            Point<T> curr = table[i].Next;
                            while (curr != null)
                            {
                                if (curr.Data is BankCard m1 && m1.Name.Equals(name))
                                    searchName = curr.Data;
                                curr = curr.Next;
                            }
                        }
                    }
                }
                return searchName;
            }

            set
            {
                Point<T> item = FindName(name);
                if (item != null)
                {
                    Add(value);
                    Remove(item.Data);
                    OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs("Присвоение нового значения", value));
                }
                else throw new Exception($"Элемента с названием {name} нет в коллекции");
            }
        }

        public event CollectionHandler collectionCountChanged;  //событие которое возникает при изменении количества элементов в коллекции ИСП В ПОДПИСКЕ
        public event CollectionHandler collectionReferenceChanged; //возникает при изменении ссылки на элемент в коллекции.

        public void Add(T obj)
        {
            base.Add(obj);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs("Добавление", obj));
        }

        public void Remove(T obj)
        {
            bool isDeleted = base.Remove(obj);
            if (isDeleted) OnCollectionCountChanged(this, new CollectionHandlerEventArgs("Удаление", obj));
        }

        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args) //Генерация события
        {
            if (collectionCountChanged != null)
                collectionCountChanged(this, args);
        }

        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args) //Генерация события
        {
            if (collectionReferenceChanged != null)
                collectionReferenceChanged(this, args);
        }
    }
}
