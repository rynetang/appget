﻿using AppGet.HostSystem;
using AppGet.Installers.Requirements.Specifications;
using AppGet.Manifest;
using FluentAssertions;
using NUnit.Framework;

namespace AppGet.Tests.Requirements.Specifications
{
    [TestFixture]
    public class OsArchitectureSpecificationFixture : TestBase<OsArchitectureSpecification>
    {
        [Test]
        public void should_be_true_when_type_is_x86()
        {
            Mocker.GetMock<IEnvInfo>()
                  .SetupGet(s => s.Is64BitOperatingSystem)
                  .Returns(true);

            Subject.IsRequirementSatisfied(new Installer
            {
                Architecture = ArchitectureTypes.x86
            }).Success.Should().BeTrue();

        }

        [Test]
        public void should_be_true_when_type_is_x64_on_x64_os()
        {
            Mocker.GetMock<IEnvInfo>()
                  .SetupGet(s => s.Is64BitOperatingSystem)
                  .Returns(true);

            Subject.IsRequirementSatisfied(new Installer
            {
                Architecture = ArchitectureTypes.x64
            }).Success.Should().BeTrue();
        }

        [Test]
        public void should_be_false_when_x64_on_x86_os()
        {
            Mocker.GetMock<IEnvInfo>()
                  .SetupGet(s => s.Is64BitOperatingSystem)
                  .Returns(false);

            Subject.IsRequirementSatisfied(new Installer
            {
                Architecture = ArchitectureTypes.x64
            }).Success.Should().BeFalse();
        }

    }
}
