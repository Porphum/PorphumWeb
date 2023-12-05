using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query;
public enum ProductsParamType
{
    Limit = 0,
    Skip = 1,
    NameLike = 2,
    OfInGroupKey = 3
}
