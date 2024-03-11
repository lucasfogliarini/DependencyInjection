using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
	public class GuidServiceInjectionTests
	{
		/// <summary>
		/// Este teste verifica se o serviço registrado como Scoped tem o mesmo valor apenas dentro do mesmo escopo
		/// </summary>
		[Fact]
		public void AddScoped_Should_Equal_OnlyInSameScope()
		{
			var serviceProvider = new ServiceCollection()
				.AddScoped<GuidService>()
				.BuildServiceProvider();

			GuidService guidService1;
			GuidService guidService2;

			using (var scope = serviceProvider.CreateScope())
			{
				guidService1 = scope.ServiceProvider.GetRequiredService<GuidService>();
				guidService2 = scope.ServiceProvider.GetRequiredService<GuidService>();
				Assert.Equal(guidService1.Guid, guidService2.Guid);
			}

			guidService2 = serviceProvider.GetRequiredService<GuidService>();
			Assert.NotEqual(guidService2.Guid, guidService1.Guid);
		}

		/// <summary>
		/// Este teste verifica se o serviço registrado como Singleton tem o mesmo valor durante todo o seu ciclo de vida
		/// </summary>
		[Fact]
		public void AddSingleton_Should_Equal_InAllLifeTime()
		{
			var serviceProvider = new ServiceCollection()
				.AddSingleton<GuidService>()
				.BuildServiceProvider();

			GuidService guidService1;
			GuidService guidService2;

			using (var scope = serviceProvider.CreateScope())
			{
				guidService1 = scope.ServiceProvider.GetRequiredService<GuidService>();
				guidService2 = scope.ServiceProvider.GetRequiredService<GuidService>();
				Assert.Equal(guidService1.Guid, guidService2.Guid);
			}

			guidService1 = serviceProvider.GetRequiredService<GuidService>();
			Assert.Equal(guidService1.Guid, guidService2.Guid);

			guidService2 = serviceProvider.GetRequiredService<GuidService>();
			Assert.Equal(guidService1.Guid, guidService2.Guid);
		}

		/// <summary>
		/// Este teste verifica se o serviço registrado como Transient nunca tem o mesmo valor, independentemente do escopo ou do ciclo de vida
		/// </summary>
		[Fact]
		public void AddTransient_Should_NotEqual_Ever()
		{
			var serviceProvider = new ServiceCollection()
				.AddTransient<GuidService>()
				.BuildServiceProvider();

			GuidService guidService1;
			GuidService guidService2;

			using (var scope = serviceProvider.CreateScope())
			{
				guidService1 = scope.ServiceProvider.GetRequiredService<GuidService>();
				guidService2 = scope.ServiceProvider.GetRequiredService<GuidService>();
				Assert.NotEqual(guidService1.Guid, guidService2.Guid);
			}

			guidService1 = serviceProvider.GetRequiredService<GuidService>();
			guidService2 = serviceProvider.GetRequiredService<GuidService>();
			Assert.NotEqual(guidService1.Guid, guidService2.Guid);
		}
	}
}