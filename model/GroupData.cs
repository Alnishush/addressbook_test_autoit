using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_test_autoit
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData> //Для сравнения
    {
        public string Name { get; set; }

        public int CompareTo(GroupData other)           // Реализация метода из интерфейса IComparable<GroupData>. Позволяет сравнивать текущий объект с другим для определения порядка сортировки
        {
            if (Object.ReferenceEquals(other, null))    // Если other является null, возвращаем 1. Это означает, что текущий объект "больше" null (должен идти после null)
            {
                return 1;
            }
            return Name.CompareTo(other.Name);          // Сравнивает имена групп в лексикографическом порядке (алфавитно)
        }

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
    }
}
