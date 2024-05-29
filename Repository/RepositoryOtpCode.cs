

using Contracts;
using Entities.Models;

namespace Repository
{
    internal class RepositoryOtpCode : RepositoryBase<OtpCode>, IRepositoryOtpCode
    {
        public RepositoryOtpCode(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void CreateOtpCode(OtpCode otpCode)
        {
            Create(otpCode);
        }

        public OtpCode? getOtpCode(int optCodeId, bool trackChange)
        {
            return FindByCondition((otpCode) => otpCode.id == optCodeId, trackChange).SingleOrDefault();
        }

        public IEnumerable<OtpCode> getOtpCodeByUserId(int userId, bool trackChange)
        {
            return FindByCondition((otpCode) => otpCode.userId == userId, trackChange).ToList();
        }
    }
}
