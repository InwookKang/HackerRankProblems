using System;
namespace HackerRank
{
    internal interface IUserInput
    {
        int intUserInput();
        string strUserInput();
        int[] intAryUserInput(int iSize);
    }
}
