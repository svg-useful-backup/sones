﻿#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sones.Networking.HTTP;
using System.IO;
using System.Diagnostics;
using sones.Library.LanguageExtensions;

#endregion

namespace sones.Plugins.GraphDS.RESTService
{
    public class GraphDSREST_Errors
    {
        #region Data

        private String _ServerID;

        #endregion

        #region Constructors

        public GraphDSREST_Errors(String myServerID)
        {
            _ServerID = myServerID;
        }

        #endregion

        #region BadRequest(myErrorMessage)

        public void Error400_BadRequest(String myErrorMessage)
        {

            var _Header = HTTPServer.HTTPContext.ResponseHeader;
            var _Content = Encoding.UTF8.GetBytes("Error 400 - Bad Request : " + myErrorMessage);

            _Header.HttpStatusCode = HTTPStatusCodes.BadRequest;
            _Header.CacheControl = "no-cache";
            _Header.ServerName = _ServerID;
            _Header.ContentLength = _Content.ULongLength();
            _Header.ContentType = GraphDSREST_Constants._TEXT_UTF8;

            HTTPServer.HTTPContext.WriteToResponseStream(_Header.ToBytes());
            HTTPServer.HTTPContext.WriteToResponseStream(_Content);

        }

        #endregion

        #region QueryFailed(myErrorMessage)

        public void Error400_QueryFailed(String myErrorMessage)
        {

            var _Header = HTTPServer.HTTPContext.ResponseHeader;
            var _Content = Encoding.UTF8.GetBytes("Error 400 - Query Failed : " + myErrorMessage);

            _Header.HttpStatusCode = HTTPStatusCodes.BadRequest;
            _Header.CacheControl = "no-cache";
            _Header.ServerName = _ServerID;
            _Header.ContentLength = _Content.ULongLength();
            _Header.ContentType = GraphDSREST_Constants._TEXT_UTF8;

            HTTPServer.HTTPContext.WriteToResponseStream(_Header.ToBytes());
            HTTPServer.HTTPContext.WriteToResponseStream(_Content);

        }

        #endregion

        #region Error404_NotFound(myStream)

        public void Error404_NotFound(Stream myCustom404Error)
        {

            var _Header = HTTPServer.HTTPContext.ResponseHeader;

            _Header.HttpStatusCode = HTTPStatusCodes.NotFound;
            _Header.CacheControl = "no-cache";
            _Header.ServerName = _ServerID;

            #region Send custom Error404page...

            if (myCustom404Error != null && myCustom404Error.Length > 0)
            {
                _Header.ContentType = GraphDSREST_Constants._HTML;
                _Header.ContentLength = (UInt64)myCustom404Error.Length;
            }

            #endregion

            #region ...or non-custom Error404page!

            else
            {
                _Header.ContentType = GraphDSREST_Constants._TEXT_UTF8;
                _Header.ContentLength = 0;
            }

            #endregion

            HTTPServer.HTTPContext.WriteToResponseStream(_Header.ToBytes());
            HTTPServer.HTTPContext.WriteToResponseStream(myCustom404Error);

        }

        #endregion

        #region checkAuthentication(mySettings)

        public Boolean checkAuthentication(GraphDSREST_Settings mySettings)
        {

            if (mySettings != null)
            {
                Debug.WriteLine("Currently not authentication mechanism was choosen!");
                return true;
            }

            else
                return false;

        }

        #endregion

        #region Print Error Messages internally

       /* public String PrintErrorToString(ResultType myResultType, IEnumerable<IError> myIErrors)
        {

            var Output = new StringBuilder();

            if (myResultType == ResultType.Successful)
            {
                Output.AppendLine("OK");
            }

            else
            {
                foreach (var aError in myIErrors)
                {
                    Output.AppendLine("ERROR!");
                    Output.AppendLine("Errorclass: " + aError.GetType().Name);
                    Output.AppendLine(aError.ToString());
                    Output.AppendLine(Environment.NewLine);
                }
                return Output.ToString();
            }

            return Output.ToString();
        }*/

        #endregion
    }
}