using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General;

public abstract class BaseLoadableModel<TParam> : ILoadable<TParam>
{
    protected virtual void LoadParam(TParam? param)
    {
        throw new NotImplementedException();
    }

    public bool IsLoaded { get; protected set; } = false;

    public void Load(TParam? param)
    {
        if (IsLoaded)
        {
            throw new InvalidOperationException();
        }

        LoadParam(param);

        IsLoaded = true;
    }
}
