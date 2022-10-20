using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IGenericServices
    {
        void AddEntry<T>(T entry) where T : class;
        void UpdateEntry<T>(T entry) where T : class;
        void DeleteEntry<T>(T entry) where T : class;
    }
}
