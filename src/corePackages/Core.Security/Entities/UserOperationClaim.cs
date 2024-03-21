using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class UserOperationClaim : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid OperatiobClaimId { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim()
    {
        
    }

    public UserOperationClaim(Guid id,Guid userId, Guid operatiobClaimId)
    {
        UserId = id;
        UserId = userId;
        OperatiobClaimId = operatiobClaimId;
    }
}
