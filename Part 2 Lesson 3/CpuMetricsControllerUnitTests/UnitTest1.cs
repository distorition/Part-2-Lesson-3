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
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� CpuMetric ������
            mock.Setup(repository => repository.Create(It.IsAny<CpuMetrics>())).Verifiable();

            // ��������� �������� �� �����������
            var result = controller.Create(new CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetrics>()), Times.AtMostOnce());
        }

    }
}
