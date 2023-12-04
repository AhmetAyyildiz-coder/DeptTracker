using Core.Persistence.Repositories;

namespace Domain.Entities;

public class PaymentPlan : Entity<int>
{
    /// <summary>
    /// Son tarih
    /// </summary>
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
}