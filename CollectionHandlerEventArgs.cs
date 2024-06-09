using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    //класс позволяет передавать информацию о изменениях в коллекции через события и уведомлять об этом журнал 
    public class CollectionHandlerEventArgs : EventArgs //Он определяет какую информацию получил журнал
    {
        public string TypeChange { get; set; } /// <summary>
                                               ///  указывает на тип изменения (например, добавление, удаление, обновление
                                               /// </summary>
        public object ChangedObject { get; set; } /// <summary>
                                                  /// содержит объект, который был изменен.
                                                  /// </summary>
                                                  /// <param name="typeChange"></param>
                                                  /// <param name="changedObject"></param>

        public CollectionHandlerEventArgs(string typeChange, object changedObject)
        {
            TypeChange = typeChange; //установка их в соответствующие свойства класса
            ChangedObject = changedObject;
        }
    }
}


