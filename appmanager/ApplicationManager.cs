using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_test_autoit
{
    public class ApplicationManager
    {
        private AutoItX3 aux;
        private GroupHelper groupHelper;

        public ApplicationManager()
        {
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {

        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
    }
}
