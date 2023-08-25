using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Abstractions;

public interface IReferenceBookMapper : IModelMapper<Client, long>, IModelMapper<Product, long>
{
}
