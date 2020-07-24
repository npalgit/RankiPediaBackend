using Rankipedia.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rankipedia.Data.Query
{
    public interface IDropDownQueryProvider
    {
        Task<List<DropDown>> GetFirstDropDown();
        Task<List<DropDown>> GetSecondtDropDown(Guid id);
        Task<List<DropDown>> GetThirdDropDown(Guid id);
    }

    public class DropDownQueryProvider : IDropDownQueryProvider
    {
        Guid firstDropDownId1 = Guid.NewGuid();
        Guid firstDropDownId2 = Guid.NewGuid();
        Guid firstDropDownId3 = Guid.NewGuid();

        Guid secondDropDownId1 = Guid.NewGuid();
        Guid secondDropDownId2 = Guid.NewGuid();
        Guid secondDropDownId3 = Guid.NewGuid();
        Guid secondDropDownId4 = Guid.NewGuid();

        Guid thirdDropDownId1 = Guid.NewGuid();
        Guid thirdDropDownId2 = Guid.NewGuid();
        Guid thirdDropDownId4 = Guid.NewGuid();
        Guid thirdDropDownId5 = Guid.NewGuid();
        Guid thirdDropDownId6 = Guid.NewGuid();

        public DropDownQueryProvider()
        {
        }
        public async Task<List<DropDown>> GetFirstDropDown()
        {
            return new List<DTO.DropDown> {
                new DTO.DropDown{ Id = firstDropDownId1, Name = "f1"},
                new DTO.DropDown{ Id = firstDropDownId2, Name = "f2"},
                new DTO.DropDown{ Id = firstDropDownId3, Name = "f3"}
            };
        }
        public async Task<List<DropDown>> GetSecondtDropDown(Guid id)
        {
            return new List<DropDown> {
                new DropDown{Id = secondDropDownId1, Name = "s1", RefId = firstDropDownId1},
                new DropDown{Id = secondDropDownId2, Name = "s2", RefId = firstDropDownId2},
                new DropDown{Id = secondDropDownId3, Name = "s3", RefId = firstDropDownId2},
                new DropDown{Id = secondDropDownId4, Name = "s4", RefId = firstDropDownId3}
            }.Where(x => x.RefId == id).ToList();
        }
        public async Task<List<DropDown>> GetThirdDropDown(Guid id)
        {
            return new List<DropDown> {
                new DropDown{Id = thirdDropDownId1, Name = "t1", RefId = secondDropDownId1},
                new DropDown{Id = thirdDropDownId1, Name = "t2", RefId = secondDropDownId1},
                new DropDown{Id = thirdDropDownId1, Name = "t3", RefId = secondDropDownId4},
                new DropDown{Id = thirdDropDownId1, Name = "t4", RefId = secondDropDownId2},
                new DropDown{Id = thirdDropDownId1, Name = "t5", RefId = secondDropDownId2},
                new DropDown{Id = thirdDropDownId1, Name = "t6", RefId = secondDropDownId3},
            }.Where(x => x.RefId == id).ToList();
        }
    }
}
