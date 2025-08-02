namespace CodeTest.Domain.Entities.Base
{
	public abstract class EntityBase
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
		public DateTime? DataAlteracao { get; set; }
		public bool Excluido { get; set; } = false;
	}
}
