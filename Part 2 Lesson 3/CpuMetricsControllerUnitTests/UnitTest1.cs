using Moq;
using Part_2_Lesson_3;
using Part_2_Lesson_3.Controllers;
using System;
using Xunit;

namespace CpuMetricsControllerUnitTests
{
    public class CpuMetricsUnitTest
    {

        private CpuConectToRepository controller;
        private Mock<ICpuMetricsRepository> mock;

        public CpuMetricsUnitTest()
        {
            mock = new Mock<ICpuMetricsRepository>();

            controller = new CpuConectToRepository(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock.Setup(repository => repository.Create(It.IsAny<CpuMetrics>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller.Create(new CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetrics>()), Times.AtMostOnce());
        }

    }
}
