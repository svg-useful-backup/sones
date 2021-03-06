/*
* sones GraphDB - Community Edition - http://www.sones.com
* Copyright (C) 2007-2011 sones GmbH
*
* This file is part of sones GraphDB Community Edition.
*
* sones GraphDB is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, version 3 of the License.
* 
* sones GraphDB is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with sones GraphDB. If not, see <http://www.gnu.org/licenses/>.
* 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sones.GraphQL.ErrorHandling;
using sones.GraphQL.GQL.Structure.Nodes.Expressions;
using sones.GraphQL.GQL.Structure.Nodes.Misc;

namespace sones.GraphQL.GQL.ErrorHandling
{
    public sealed class InvalidBinaryExpressionException : AGraphQLException
    {
		/// <summary>
		/// Initializes a new instance of the BinaryExpressionDefinition class.
		/// </summary>
		/// <param name="myBinaryExpression"></param>
		/// <param name="innerException">The exception that is the cause of the current exception, this parameter can be NULL.</param>
        public InvalidBinaryExpressionException(BinaryExpressionDefinition myBinaryExpression, Exception innerException = null) : base(innerException)
        {
            _msg = String.Format("The BinaryExpression is not valid: {0} {1} {2}", myBinaryExpression.Left.ToString(), myBinaryExpression.Operator, myBinaryExpression.Right.ToString());
        }
    }
}
