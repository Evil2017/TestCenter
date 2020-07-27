using System.Threading.Tasks;
using TestCenter.Util.Model;

namespace TestCenter.Business.AutoJob
{
    public interface IJobTask
    {
        Task<TData> Start();
    }
}
