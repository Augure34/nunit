// ***********************************************************************
// Copyright (c) 2012 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using NUnit.Engine.Services;

namespace NUnit.Engine.Internal
{
    /// <summary>
	/// Summary description for InternalTrace.
	/// </summary>
	public static class InternalTrace
	{
        private static bool initialized;
        private static InternalTraceLevel traceLevel;
        private static InternalTraceWriter traceWriter;

        public static void Initialize(string logName, InternalTraceLevel level)
        {
            if (!initialized)
            {
                traceLevel = level;

                if (traceWriter == null && traceLevel > InternalTraceLevel.Off)
                {
                    traceWriter = new InternalTraceWriter(logName);
                    traceWriter.WriteLine("InternalTrace: Initializing at level " + traceLevel.ToString());
                }

                initialized = true;
            }
        }

        public static Logger GetLogger(string name)
		{
			return new Logger(name, traceLevel, traceWriter);
		}

		public static Logger GetLogger( Type type )
		{
			return GetLogger(type.FullName);
		}
    }
}