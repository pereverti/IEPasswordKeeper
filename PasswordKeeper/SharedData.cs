using System;
using System.Runtime.InteropServices;
using AddinExpress.IE;
 
namespace PasswordKeeper
{
    [ComVisible(false)]
    public class SharedData : AddinExpress.IE.ADXIESharedMemory
    {
        public SharedData(string pageName)
            : base(pageName)
        {
        }
 
        public SharedData(string pageName, uint sizeInBytes)
            : base(pageName, sizeInBytes)
        {
        }
 
        public SharedData(string pageName, uint maxValueSizeInBytes, uint valueCount)
            : base(pageName, maxValueSizeInBytes, valueCount)
        {
        }
    }
}

