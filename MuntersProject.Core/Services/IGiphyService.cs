using MuntersProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuntersProject.Core.Services
{
    public interface IGiphyService
    {
        Task<TrengingGif> GetAllTrengingGif();

        Task<TrengingGif> SearchGiphys(string searchText);
    }
}
