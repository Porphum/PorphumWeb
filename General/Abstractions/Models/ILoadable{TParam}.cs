using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models;

public interface ILoadable<TParam>
{
    public bool IsLoaded { get; }

    public void Load(TParam param);
}
