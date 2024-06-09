using ClassLibrary10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public class Journal
    {
        List<JournalEntry> jornal = new List<JournalEntry>();

        public void WrireRecord(object source, CollectionHandlerEventArgs args) //метод отвечает за запись изменений в журнал(ИСП В ПОДПИСКЕ) ОБРАБОТЧИК
        {
            JournalEntry element = new JournalEntry(((MyObservableCollection<BankCard>)source).CollectionName, args.TypeChange, args.ChangedObject.ToString());
            jornal.Add(element); //JournalEntry содержит информацию о имени коллекции, типе изменения и измененном объекте, и добавляется в список jornal.
        }

        public void PrintJornal()
        {
            if (jornal.Count == 0)
            {
                Console.WriteLine("Журнал пустой");
                return;
            }
            foreach (JournalEntry item in jornal)
            {
                Console.WriteLine(item);
            }

        }
    }
}
