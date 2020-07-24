using Rankipedia.Data.DTO;
using Rankipedia.Data.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rankipedia.Engine.Engines
{
    public interface IDropDownEngine
    {
        Task<List<DropDown>> GetFirstDropDown();
        Task<List<DropDown>> GetSecondtDropDown(Guid id);
        Task<List<DropDown>> GetThirdDropDown(Guid id);
    }
    public class DropDownEngine : IDropDownEngine
    {
        private readonly IDropDownQueryProvider _dropDownQueryProvider;
        public DropDownEngine(IDropDownQueryProvider dropDownQueryProvider)
        {
            _dropDownQueryProvider = dropDownQueryProvider;
        }

        public Task<List<DropDown>> GetFirstDropDown()
        {
            return _dropDownQueryProvider.GetFirstDropDown();
        }

        public Task<List<DropDown>> GetSecondtDropDown(Guid id)
        {
            return _dropDownQueryProvider.GetSecondtDropDown(id);
        }

        public Task<List<DropDown>> GetThirdDropDown(Guid id)
        {
            return _dropDownQueryProvider.GetThirdDropDown(id);
        }
    }
}
