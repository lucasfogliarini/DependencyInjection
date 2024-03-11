namespace DependencyInjection
{
	public class GuidService
	{
        public Guid Guid { get; private set; } = Guid.NewGuid();
	}
}
