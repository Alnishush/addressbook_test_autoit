

namespace addressbook_test_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();           // Создается пустой список для хранения объектов GroupData
            OpenGroupsDialogue();                                   // Открытие окна "Group editor"
            aux.Sleep(2000);                                        // Даем время окну полностью загрузиться
            // Получение количества групп
            string count = aux.ControlTreeView(                     // работа с TreeView контролом (иерархическое дерево)
                GROUPWINTITLE,                                      // заголовок окна с группами
                "",
                "WindowsForms10.SysTreeView32.app.0.2c908d51",      // ID TreeView контрола (поле с группами)
                "GetItemCount",                                     // команда получить количество элементов
                "#0",                                               // корневой узел дерева (все группы находятся на верхнем уровне)
                "");
            for (int i = 0; i < int.Parse(count); i++)              // Преобразует строку count в число
            {
                // Получение имени каждой группы
                string item = aux.ControlTreeView(
                    GROUPWINTITLE,
                    "",
                    "WindowsForms10.SysTreeView32.app.0.2c908d51",  // ID TreeView контрола (поле с группами)
                    "GetText",                                      // команда получить текст элемента
                    "#0|#" +i,                                      // путь к элементу: #0 - корневой узел; | - разделитель уровней; #i - i-й дочерний элемент (группа). Пример: "#0|#0" - первая группа, "#0|#1" - вторая группа
                    "");
                list.Add(new GroupData()                            // Создание объекта GroupData. Для каждого имени группы создается объект GroupData, Добавляется в список
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();                                  // Закрытие окна "Group editor"
            return list;                                            // Возврат результата
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");    // Кнопка "New"
            aux.Send(newGroup.Name);                                                        // Вводит название
            aux.Send("{ENTER}");                                                            // Нажимает enter
            CloseGroupsDialogue();                                                          // Закрытие окна "Group editor"
        }

        public void Remove()
        {
            OpenGroupsDialogue();
            aux.Send("{DOWN}");                                                                 // Нажимает стрелку вниз
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");        // Кнопка "Delete"
            aux.WinWait(DELETEGROUPWINTITLE);                                                   // Ждет когда откроется нужное окно
            aux.Send("{ENTER}");                                                                // Нажимает enter
            CloseGroupsDialogue();                                                              // Закрытие окна "Group editor"
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");        // Кнопка "Edit groups"
            aux.WinWait(GROUPWINTITLE);                                                     // Ждет когда откроется нужное окно
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");    // Кнопка "Close"
        }
    }
}