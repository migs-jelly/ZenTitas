using System.Threading.Tasks;
using Domains.Bootstrap.Code.Visual.Config;

namespace Domains.Bootstrap.Code.Visual.Interfaces
{
    public interface IDomainService
    {
        Task LoadDomain(string domainName);
        Task LoadDomain(DomainConfig domainConfig);
    }
}