using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace addressbook_test_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            // 1. Запоминает старый список
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            // 2. Создает объект
            GroupData newGroup = new GroupData()
            {
                Name = "NewGroup"
            };

            // 3. Создает группу из объекта
            app.Groups.Add(newGroup);

            // 4. Запоминает новый список
            List<GroupData> newGroups = app.Groups.GetGroupList();

            // 5. Проверка: количество групп увеличелось на 1
            ClassicAssert.That
                (newGroups.Count,       // фактическое значение
                Is.EqualTo              // Проверяет, равно ли фактическое значение ожидаемому
                (oldGroups.Count + 1)); // ожидаемое значение
        }
    }
}
