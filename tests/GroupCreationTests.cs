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
            List<GroupData> oldGroups = app.Groups.GetGroupList(); // Запоминает старый список

            GroupData newGroup = new GroupData()                   // Создает объект
            {
                Name = "test"
            };

            app.Groups.Add(newGroup);                              // Создает группу из объекта
            
            List<GroupData> newGroups = app.Groups.GetGroupList(); // Запоминает новый список
            oldGroups.Add(newGroup);                               // Добавляет в старый список новую группу в памяти (не в базу данных и не в UI)
            oldGroups.Sort();
            newGroups.Sort();

            ClassicAssert.AreEqual(oldGroups, newGroups);          // Сравнивает списки
        }
    }
}
