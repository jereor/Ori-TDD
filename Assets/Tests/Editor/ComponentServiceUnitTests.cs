using System.Linq;
using Components;
using GameFramework.ComponentService;
using NUnit.Framework;
using Moq;

namespace Tests.Editor
{
    public class ComponentServiceUnitTests
    {
        public class Create
        {
            [Test]
            public void initializes_component_list_as_empty()
            {
                ComponentService componentService = ComponentService.Create();
                
                Assert.That(componentService.ComponentList, Is.Empty);
            }
        }
        
        public class AddComponent
        {
            [Test]
            public void adds_component_to_component_list()
            {
                ComponentService componentService = ComponentService.Create();

                componentService.AddComponent(new Mock<Movement>().Object);

                bool componentFound = componentService.ComponentList.OfType<Movement>().FirstOrDefault() != null;
                Assert.That(componentFound);
            }

            [Test]
            public void does_not_add_duplicates_to_component_list()
            {
                ComponentService componentService = ComponentService.Create();
                
                componentService.AddComponent(new Mock<Movement>().Object);
                componentService.AddComponent(new Mock<Movement>().Object);
                
                Assert.That(componentService.ComponentList.OfType<Movement>().Count(), Is.EqualTo(1));
            }
        }
        
        public class GetComponent
        {
            [Test]
            public void returns_nothing_when_component_list_is_empty()
            {
                ComponentService componentService = ComponentService.Create();

                Movement movementComponent = componentService.GetComponent<Movement>();
                
                Assert.That(movementComponent, Is.Null);
            }
            
            [Test]
            public void does_not_get_components_that_are_not_on_the_component_list()
            {
                ComponentService componentService = ComponentService.Create();
                componentService.ComponentList.Add(new Mock<IInput>().Object);

                Movement movementComponent = componentService.GetComponent<Movement>();
                
                Assert.That(movementComponent, Is.Null);
            }
            
            [Test]
            public void gets_the_requested_component_from_component_list_when_component_is_on_the_list()
            {
                ComponentService componentService = ComponentService.Create();
                componentService.ComponentList.Add(new Mock<Movement>().Object);
                componentService.ComponentList.Add(new Mock<IInput>().Object);
                
                Movement movementComponent = componentService.GetComponent<Movement>();
                
                Assert.That(movementComponent, Is.Not.Null);
            }
            
        }
    }
}