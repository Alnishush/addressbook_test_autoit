using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace addressbook_test_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            // 1. Запоминает старый список
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            // 2. Если группа 1, создаем еще 1 (невозможно удалить группу при кол-ве 1)
            if (oldGroups.Count == 1)
            {
                GroupData newGroup = new GroupData()    // Создает объект
                {
                    Name = "GroupToDelete"
                };
                app.Groups.Add(newGroup);               // Создает группу из объекта
                oldGroups = app.Groups.GetGroupList();  // Запоминает старый список
            }

            // 3. Запоминаем группу для удаления (первую в списке)
            //GroupData groupToRemove = oldGroups[0];

            // 4. Удаляем группу
            app.Groups.Remove(); // Удаляем группу с индексом 0

            // 5. Получаем новый список групп
            List<GroupData> newGroups = app.Groups.GetGroupList();

            //ClassicAssert.AreEqual(oldGroups.Count - +1, app.Groups.GetGroupCount()); // Проверяем колчичество групп
            // 6. Проверка: количество групп уменьшилось на 1
            ClassicAssert.That
                (newGroups.Count,       // фактическое значение
                Is.EqualTo              // Проверяет, равно ли фактическое значение ожидаемому
                (oldGroups.Count - 1)); // ожидаемое значение
        }
    }
}