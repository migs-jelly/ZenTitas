using System.Threading.Tasks;
using Domains.Global.Code.Visual.Config;
using Domains.Global.Code.Visual.Helpers;
using UnityEngine.AddressableAssets;

namespace Domains.Global.Code.Visual.Interfaces
{
    public interface IDomainService
    {
        Task LoadDomain(string domainName);
        Task LoadDomain(DomainConfig domainConfig);
    }
}