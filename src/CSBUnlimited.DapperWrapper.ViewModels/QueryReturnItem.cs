﻿using System.Collections.Generic;
using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    public class QueryReturnItem<T> : IReturnItem
    {
        /// <summary>
        /// Status defined by the SP
        /// </summary>
        public long ReturnValue { get; set; }

        /// <summary>
        /// Returned parameters list
        /// </summary>
        public IDbParameterList ReturnParametersCollection { get; set; }

        /// <summary>
        /// List of data items. 
        /// </summary>
        public IList<T> DataItemList { get; set; }

        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QueryReturnItem()
        {
            ReturnValue = -1;
            ReturnParametersCollection = new DbParameterList();
        }
    }
}