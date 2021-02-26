namespace User.Domain.SeedWork {
    public interface IRepository<T> where T : Entity, IAggregateRoot {
        IUnitOfWork UnitOfWork { get; }
    }
}