﻿using System.Linq;

namespace Core.Persistence.Dynamic;

public class Sort
{
    public string Field { get; set; }
    public string Dir { get; set; } //asc desc


    public Sort()
    {

    }

    public Sort(string field, string dir)
    {
        Field = field;
        Dir = dir;
    }
}