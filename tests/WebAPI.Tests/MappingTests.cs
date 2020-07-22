using AutoMapper;
using NUnit.Framework;
using WebAPI.Infrastructure;

namespace WebAPI.Tests
{
    /// <summary>
    /// Класс, тестирующий AutoMapper.
    /// </summary>
    public class MappingTests
    {
        /// <summary>
        /// Конфигурация AutoMapper.
        /// </summary>
        private MapperConfiguration _config;

        /// <summary>
        /// Предварительная подготовка.
        /// </summary>
        [SetUp]
        public void Setup()
		{
			_config = new MapperConfiguration(cfg =>
            {
				cfg.AddProfile(new MappingProfile());
			});
		}

        /// <summary>
        /// .
        /// </summary>
        [Test]
        public void Test1()
        {
            _config.AssertConfigurationIsValid();
        }
    }
}