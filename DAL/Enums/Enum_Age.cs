using System;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    [Flags]
    public enum Enum_Age
    {
        Under16,
        Under18,
        Under21,
        Under25

    }
}