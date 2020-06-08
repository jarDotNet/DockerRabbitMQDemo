using System;

namespace OrderApi.Domain.Enumerations
{
    [Serializable]
    public enum eOrderState
    {
        Pending = 1,
        Paid = 2
    }
}
