﻿using System;
using sones.Library.ErrorHandling;

namespace sones.GraphQL.ErrorHandling
{
    /// <summary>
    /// The grammar is not dumpable
    /// </summary>
    public sealed class NotADumpableGrammarException : AGraphQLException
    {
        public String Info { get; private set; }

        /// <summary>
        /// Create a new NotADumpableGrammarException exception
        /// </summary>
        /// <param name="myInfo"></param>
        public NotADumpableGrammarException(String myInfo)
        {
            Info = myInfo;
        }

        public override string ToString()
        {
            return Info;
        }

        public override ushort ErrorCode
        {
            get { return ErrorCodes.NotADumpableGrammar; }
        } 
    }
}