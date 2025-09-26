using AutoItX3Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_test_autoit
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";

        private AutoItX3 aux;
        private GroupHelper groupHelper; 

        public ApplicationManager()
        {
            aux = new AutoItX3();                                                                   // Создает объект AutoIt
            aux.Run(@"C:\tools\AppsForTesting\AddressbookNative\AddressBook.exe", "", aux.SW_SHOW); // Запуск приложения; aux.SW_SHOW - показывает приложение (без него запускается в скрытом режиме)
            aux.WinWait(WINTITLE);                                                                  // Ждет окно приложения
            aux.WinActivate(WINTITLE);                                                              // Активирует окно
            aux.WinWaitActive(WINTITLE);                                                            // Ждет активации окна

            groupHelper = new GroupHelper(this);                                                    // Создает хелпер для групп
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510"); // Остановка приложения (кнопка "Exit")
        }

        public AutoItX3 Aux { get { return aux; } }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
    }
}
