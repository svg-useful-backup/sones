﻿using System;

namespace sones.Plugins.SonesGQL
{
    #region IGraphQLFunctionVersionCompatibility

    /// <summary>
    /// A static implementation of the compatible IQLFunction plugin versions. 
    /// Defines the min and max version for all IQLFunction implementations which will be activated used this IQLFunction.
    /// </summary>
    public static class IGQLFunctionVersionCompatibility
    {
        public static Version MinVersion
        {
            get { return new Version("2.0.0.0"); }
        }

        public static Version MaxVersion
        {
            get { return new Version("2.0.0.0"); }
        }
    }

    #endregion
    
    /// <summary>
    /// The interface for all GQL functions
    /// </summary>
    public interface IGQLFunction
    {
        /// <summary>
        /// Returns the name of the function
        /// </summary>
        String Name { get; }
    }
}