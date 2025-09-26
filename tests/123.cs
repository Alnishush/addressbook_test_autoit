/*using System;
using System.ComponentModel.DataAnnotations.Schema;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [LinqToDB.Mapping.Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData> //Для сравнения
    {
        public GroupData() { }

        public bool Equals(GroupData other)             // Реализует сравнения. Реализация метода из интерфейса IEquatable<GroupData>
        {
            if (Object.ReferenceEquals(other, null))    // Если тот объект с которым сравниваем это null
            {
                return false;                           // возвращаем false (объект не равен null)
            }
            if (Object.ReferenceEquals(this, other))    // Если объект один и тот же
            {
                return true;                            // возвращаем true (объект равен самому себе)
            }
            return Name == other.Name;                  // Сравнивает объекты по полю Name. Возвращает true если имена групп одинаковые
        }

        public override int GetHashCode() // Сравнение элементов через хеш
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name
                + "\nheader=" + Header
                + "\nfooter=" + Footer;
        }

        public int CompareTo(GroupData other)           // Реализация метода из интерфейса IComparable<GroupData>. Позволяет сравнивать текущий объект с другим для определения порядка сортировки
        {
            if (Object.ReferenceEquals(other, null))   // Если other является null, возвращаем 1. Это означает, что текущий объект "больше" null (должен идти после null)
            {
                return 1;
            }
            return Name.CompareTo(other.Name);          // Сравнивает имена групп в лексикографическом порядке (алфавитно)
        }

        public GroupData(string name)
        {
            Name = name;
        }

        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }

        [LinqToDB.Mapping.Column(Name = "group_name")]
        public string Name { get; set; }

        [LinqToDB.Mapping.Column(Name = "group_header")]
        public string Header { get; set; }

        [LinqToDB.Mapping.Column(Name = "group_footer")]
        public string Footer { get; set; }

        [LinqToDB.Mapping.Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll() //метод получения полного списка групп
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts           // выбирает все контакты из таблицы Contacts
                        from gcr in db.GCR              // присоединяет таблицу связей "Group-Contact Relations"
                        where gcr.GroupId == this.Id    // фильтрует связи по ID текущей группы
                            && gcr.ContactId == c.Id    // соединяет контакты со связями по ID контакта
                        //.Where(p => p.ContactId == Id && p.ContactId == c.Id)// && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct()            // убирает дубликаты
                        .ToList();                      // возвращает список
            }
        }
    }
}
*/