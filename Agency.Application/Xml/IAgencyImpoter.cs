using System.IO;
using System.Threading.Tasks;

namespace Agency.Application
{
    public interface IAgencyImpoter
    {
        Task ImportZipAsync(Stream stream);
    }
}
