using System.Threading.Tasks;
using Domains.Bootstrap.Code.Core.Base;
using Domains.Bootstrap.Code.Visual.Config;

namespace Domains.Bootstrap.Code.Visual.Services
{
    public interface IDomainService : IBaseService
    {
        Task LoadDomain(string domainName);
        Task LoadDomain(DomainConfig domainConfig);
    }
}