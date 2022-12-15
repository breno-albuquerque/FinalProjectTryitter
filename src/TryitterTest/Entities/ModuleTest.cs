using Tryitter.Entities;

namespace TryitterTest.Entities
{
    public class ModuleTest
    {
        private readonly int _moduleId = 1;
        private readonly string _title = "test";

        [Fact(DisplayName = "Deve instanciar a entidade")]
        public void shouldInstanceEntity()
        {
            var module = new Module
            {
                ModuleId = _moduleId,
                Title = _title,
            };

            module.ModuleId.Should().Be(_moduleId);
            module.Title.Should().Be(_title);
        }
    }
}