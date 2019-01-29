﻿namespace CSBUnlimited.DapperWrapper.Core
{
    internal interface IReturnItem
    {
        /// <summary>
        /// Status defined by the SP
        /// </summary>
        long ReturnValue { get; set; }

        /// <summary>
        /// Returned parameters list
        /// </summary>
        IDbParameterList ReturnParametersCollection { get; set; }
    }
}