namespace GameFramework.AcceptanceTesting
{
    public class AcceptanceTestBase
    {
        
    }
    
    public class AcceptanceTestBase<TAcceptanceTest> : AcceptanceTestBase
        where TAcceptanceTest : AcceptanceTestBase<TAcceptanceTest>
    {
        protected readonly PlayerActor Player = new PlayerActor();
        protected readonly InputActor Input = new InputActor();
        protected readonly CharacterActor Character = new CharacterActor();
        
        protected TAcceptanceTest Given(PlayerActor actor)
        {
            return (TAcceptanceTest)this;
        }

        protected TAcceptanceTest When(InputActor actor)
        {
            return (TAcceptanceTest)this;
        }

        protected TAcceptanceTest Then(CharacterActor actor)
        {
            return (TAcceptanceTest)this;
        }
    }
}