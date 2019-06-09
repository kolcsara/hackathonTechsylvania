
using PinkyBankingForms.Models;

namespace PinkyBankingForms.Extensions
{
    public static class HashExtension
    {
        public static bool Compare(this Hash currentData, Hash incomingData)
        {
            if (currentData.UserID != incomingData.UserID
                || currentData.UserBiometricIDList.Count != incomingData.UserBiometricIDList.Count)
            {
                return false;
            }

            var index = 0;
            foreach(var element in currentData.UserBiometricIDList)
            {
                if (element != incomingData.UserBiometricIDList[index])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsAmountAvailable(this Hash currentData, Hash incomingData)
        {
            return currentData.Amount > incomingData.Amount;
        }
    }
}
