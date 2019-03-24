using System;
using System.Collections.Generic;
namespace HackerRank
{
    public class TriesContactsApplication : AbsProblem, IProblem
    {

        public TriesContactsApplication() : base("Contacts Application")
        {
        }

        public void Begin()
        {
            do
            {
                int iUserNumInput = GetUserIntInput();
                string[] iUserStrArrayInput = GetUserAryStringInput();

                //Dictionary<string, string> dictInput = OrganizeEachInput(iUserStrArrayInput);


            } while (base.RunAgain());
        }

        public int FindContact(string strContact)
        {
            int iAnswer = 0;


            return iAnswer;
        }

        public void AddContact(string strContact)
        {

        }
    }
}
