using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Attribute to assign to fields and properties which should save in state

namespace DermaDesigner
{
    [AttributeUsage(AttributeTargets.Field |
       AttributeTargets.Property,
       AllowMultiple = false)]
    public class PackerAttrib : Attribute
    {
        public bool ShouldIgnore = false;
        public PackerAttrib()
        {
            
        }

        public PackerAttrib(bool ShouldIgnore)
        {
            this.ShouldIgnore = ShouldIgnore;

        }
    }
}
