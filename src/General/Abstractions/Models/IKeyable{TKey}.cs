﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Abstractions.Models;

public interface IKeyable<TKey>
{
    public TKey Key { get; }
}
